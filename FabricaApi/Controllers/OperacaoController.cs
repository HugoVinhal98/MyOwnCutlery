using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.DTOs;
using FabricaApi.Models;
using FabricaApi.Repo;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Controllers {

    [Route ("api/operacao")]
    [ApiController]
    [EnableCors ("MyPolicy")]

    public class OperacaoController : ControllerBase {
        private readonly FabricaContext _context;

        private OperacaoRepositorio Orepo;
        private TipoOperacaoRepositorio TOrepo;

        public OperacaoController (FabricaContext context) {
            _context = context;
            Orepo = new OperacaoRepositorio (_context);
            TOrepo = new TipoOperacaoRepositorio (_context);

            if (_context.Operacoes.Count () == 0) {
                // Create a new Operacao if collection is empty,
                // which means you can't delete all Operacoes.
                _context.Operacoes.Add (new Operacao { nome = new NomeOperacao { nome = "Operacao 1" }, tipoOpId = 1, duracao = new Duracao (2, 5) });
                _context.Operacoes.Add (new Operacao { nome = new NomeOperacao { nome = "Operacao 2" }, tipoOpId = 2, duracao = new Duracao (4, 5) });
                _context.Operacoes.Add (new Operacao { nome = new NomeOperacao { nome = "Operacao 3" }, tipoOpId = 1, duracao = new Duracao (9, 35) });
                _context.Operacoes.Add (new Operacao { nome = new NomeOperacao { nome = "Operacao 4" }, tipoOpId = 3, duracao = new Duracao (10, 34) });

                _context.SaveChanges ();
            }
        }

        // GET: api/Operacao
        [HttpGet]
        public List<OperacaoDTO> GetOperacoes () {

            IEnumerable<Operacao> lista = Orepo.SelectAll ();

            List<OperacaoDTO> listaFinal = new List<OperacaoDTO> ();

            foreach (Operacao p in lista) {
                long tipoOp = p.tipoOpId;
                TipoOperacao to = TOrepo.SelectById (tipoOp);
                OperacaoDTO dto = new OperacaoDTO{};
                dto = new OperacaoDTO { nomeTipoOp = to.nome.nome, nomeOperacao = p.nome.nome, duracao = p.duracao };
                listaFinal.Add (dto);
            }

            return listaFinal;
        }

        // GET: api/Operacao/Operacao 1
        [HttpGet ("{nome}")]
        public ActionResult<OperacaoDTO> GetOperacaoByNome (String nome) {

            long id = 0;

            List<Operacao> listaOperacoes = _context.Operacoes.ToList ();

            foreach (Operacao oper in listaOperacoes) {
                if (oper.nome.nome == nome) {
                    id = oper.Id;
                }
            }

            Operacao op = Orepo.SelectById (id);

            if (op == null) {
                return NotFound ();
            }

            long idTipoOp = op.tipoOpId;

            TipoOperacao t = TOrepo.SelectById (idTipoOp);

            OperacaoDTO dto = new OperacaoDTO { nomeTipoOp = t.nome.nome, nomeOperacao = op.nome.nome, duracao = op.duracao };

            return dto;

        }

        // POST: api/Operacao
        [HttpPost]
        public ActionResult<Operacao> PostOperacao (OperacaoDTO dto) {

            IEnumerable<Operacao> lista = Orepo.SelectAll ();

            long id = 0;

            List<TipoOperacao> listaTipoOperacoes = _context.tipoOperacoes.ToList ();

            foreach (TipoOperacao oper in listaTipoOperacoes) {
                if (oper.nome.nome == dto.nomeTipoOp) {
                    id = oper.Id;
                }
            }

            TipoOperacao to = TOrepo.SelectById (id);

            if (to == null) {
                return BadRequest ();
            }

            Operacao op = new Operacao { nome = new NomeOperacao { nome = dto.nomeOperacao }, tipoOpId = id, duracao = dto.duracao };

            //Verifica se existe alguma operacao igual a que se deseja inserir
            foreach (Operacao op1 in lista) {
                if (op.nome.nome == op1.nome.nome) {
                    return BadRequest ();
                }
            }

            return Ok (Orepo.Insert (op));

        }

    }

}