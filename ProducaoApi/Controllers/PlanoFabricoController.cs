using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProducaoApi.DTOs;
using ProducaoApi.Models;
using ProducaoApi.Repo;

namespace ProducaoApi.Controllers {
    [Route ("api/PlanoFabrico")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    public class PlanoFabricoController : ControllerBase {

        private readonly ProducaoContext _context;
        PlanoFabricoRepositorio repo;

        public PlanoFabricoController (ProducaoContext context) {

            _context = context;
            repo = new PlanoFabricoRepositorio (_context);

            if (_context.PlanosFabrico.Count () == 0) {

                List<Operacao> lo1 = new List<Operacao> ();
                List<Operacao> lo2 = new List<Operacao> ();
                List<Operacao> lo3 = new List<Operacao> ();

                Operacao op1 = new Operacao { nome = "Operacao 1" };
                Operacao op2 = new Operacao { nome = "Operacao 2" };
                Operacao op3 = new Operacao { nome = "Operacao 3" };
                Operacao op4 = new Operacao { nome = "Operacao 4" };
                Operacao op5 = new Operacao { nome = "Operacao 5" };
                Operacao op6 = new Operacao { nome = "Operacao 6" };
                Operacao op7 = new Operacao { nome = "Operacao 7" };
                Operacao op8 = new Operacao { nome = "Operacao 8" };
                Operacao op9 = new Operacao { nome = "Operacao 9" };

                lo1.Add(op1);
                lo1.Add(op2);
                lo1.Add(op3);

                lo2.Add(op4);
                lo2.Add(op5);
                lo2.Add(op6);

                lo3.Add(op7);
                lo3.Add(op8);
                lo3.Add(op9);

                _context.PlanosFabrico.Add (new PlanoFabrico { nome = new NomePlanoFabrico { nome = "PlanoFabrico1" }, listaOperacoes = lo1 });
                _context.PlanosFabrico.Add (new PlanoFabrico { nome = new NomePlanoFabrico { nome = "PlanoFabrico2" }, listaOperacoes = lo2 });
                _context.PlanosFabrico.Add (new PlanoFabrico { nome = new NomePlanoFabrico { nome = "PlanoFabrico3" }, listaOperacoes = lo3 });

                _context.SaveChanges ();

            }

        }

        // GET: api/PlanoFabrico
        [HttpGet]
        public IEnumerable<PlanoFabrico> GetPlanoFabrico () {

            IEnumerable<PlanoFabrico> lista = repo.SelectAll ();

            return lista;

        }

        // GET: api/PlanoFabrico/PlanoFabrico1
        [HttpGet ("{nome}")]
        public ActionResult<PlanoFabricoDTO> GetPlanoFabricoByNome (String nome) {

            long id = 0;

            List<PlanoFabrico> listaPF = _context.PlanosFabrico.ToList ();

            foreach (PlanoFabrico p in listaPF) {
                if (p.nome.nome == nome) {
                    id = p.Id;
                }

            }

            PlanoFabrico pf = repo.SelectById (id);

            if (pf == null) {
                return NotFound ();
            }

            PlanoFabricoDTO dto;

            List<string> listaOp = new List<String> ();

            foreach (Operacao no in pf.listaOperacoes) {
                listaOp.Add (no.nome);
            }

            dto = new PlanoFabricoDTO { nome = pf.nome.nome, listaOperacoes = listaOp };

            return Ok (dto);

        }

    }
}