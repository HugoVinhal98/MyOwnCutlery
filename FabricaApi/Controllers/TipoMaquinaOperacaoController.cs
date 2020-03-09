using System;
using System.Collections;
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
    [Route ("api/tiposMaquinaOperacao")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    public class TipoMaquinaOperacaoController : ControllerBase {
        private readonly FabricaContext _context;

        private OperacaoRepositorio ORepo;
        private TipoOperacaoRepositorio TORepo;
        TipoMaquinaOperacaoRepositorio TMORepo;

        public TipoMaquinaOperacaoController (FabricaContext context) {
            _context = context;

            ORepo = new OperacaoRepositorio (_context); //repooo
            TORepo = new TipoOperacaoRepositorio (_context); //repoo
            TMORepo = new TipoMaquinaOperacaoRepositorio (_context); //repo

            if (_context.TipoMaquinas_Operacao.Count () == 0) {
                // Create a new TipoMaquina_Operacao if collection is empty,
                // which means you can't delete all ListaMaquinasOperacao.
                _context.TipoMaquinas_Operacao.Add (new ListaMaquinasOperacao { idTipoMaquina = 1, idOperacao = 2 });
                _context.TipoMaquinas_Operacao.Add (new ListaMaquinasOperacao { idTipoMaquina = 2, idOperacao = 4 });
                _context.TipoMaquinas_Operacao.Add (new ListaMaquinasOperacao { idTipoMaquina = 3, idOperacao = 3 });
                _context.TipoMaquinas_Operacao.Add (new ListaMaquinasOperacao { idTipoMaquina = 4, idOperacao = 1 });
                _context.TipoMaquinas_Operacao.Add (new ListaMaquinasOperacao { idTipoMaquina = 4, idOperacao = 2 });
                _context.TipoMaquinas_Operacao.Add (new ListaMaquinasOperacao { idTipoMaquina = 3, idOperacao = 3 });
                _context.SaveChanges ();
            }

        }

        // GET: api/tiposMaquinaOperacao
        [HttpGet]
        public IEnumerable<ListaMaquinasOperacaoDTO> GetListaMaquinasOperacao () {
            IEnumerable<ListaMaquinasOperacao> lista = TMORepo.SelectAll ();

            return ToDTO.ListaMaquinasOperacaoToDTO (lista);
        }

        //GET: api/tiposMaquinaOperacao/Tipo 1
        [HttpGet ("{descricao}")]
        public IEnumerable<OperacaoDTO> GetOperacoesByDescricaoTipoMaquina (String descricao) {

            long id = 0;

            List<TipoMaquina> listaTipo = _context.TipoMaquinas.ToList ();

            foreach (TipoMaquina tm in listaTipo) {
                if (tm.descricao.descricao == descricao) {
                    id = tm.Id;
                }
            }

            IEnumerable<Operacao> operacaoL = TMORepo.SelectOperacoesByIdTM (id);

            List<OperacaoDTO> listaFinal = new List<OperacaoDTO> ();

            foreach (Operacao p in operacaoL) {
                long tipoOp = p.tipoOpId;
                TipoOperacao to = TORepo.SelectById (tipoOp);
                listaFinal.Add (ToDTO.OperacaoToOperacaoDTO (p, to));
            }

            IEnumerable<OperacaoDTO> l = listaFinal;

            return l;
        }

        // PUT: api/tiposMaquinaOperacao/Tipo 1
        [HttpPut ("{descricao}")]
        public ActionResult PutOperacoesInTipoMaquina (String descricao, List<NomeOperacaoDTO> l) {

            long id = 0;

            List<TipoMaquina> listaTipo = _context.TipoMaquinas.ToList ();

            foreach (TipoMaquina tm in listaTipo) {
                if (tm.descricao.descricao == descricao) {
                    id = tm.Id;
                }
            }

            List<Operacao> listaOperacao = _context.Operacoes.ToList ();
            List<Operacao> listaEnviada = new List<Operacao>();

            foreach (Operacao op in listaOperacao) {
                foreach (NomeOperacaoDTO dto in l) {
                    if (op.nome.nome == dto.nomeOperacao) {
                        listaEnviada.Add (op);
                    }
                }
            }

            //Verifica se as operações que estão a ser inseridas são validas
            foreach (Operacao op in listaEnviada) {
                long opId = op.Id;
                Operacao aux = ORepo.SelectById (opId);
                if (aux == null) {
                    return BadRequest ();
                }
            }
            TMORepo.UpdateOperacoesDeTM (id, listaEnviada);

            return Ok();
        }

    }
}