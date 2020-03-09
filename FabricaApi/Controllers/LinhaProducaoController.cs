using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using FabricaApi.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace FabricaApi.Controllers {

    [Route ("api/linhaproducao")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class LinhaProducaoController : ControllerBase {

        private readonly FabricaContext _context;

        LinhaProducaoRepositorio repo;

        public LinhaProducaoController (FabricaContext context) {

            _context = context;

            repo = new LinhaProducaoRepositorio(_context);

            if (_context.LinhasProducao.Count () == 0) {
                // Create a new LinhaProducao if collection is empty,
                // which means you can't delete all LinhasProducao.
                _context.LinhasProducao.Add(new LinhaProducao {descricao = new DescricaoLinhaProducao {descricao = "Linha 1"}} );
                _context.LinhasProducao.Add(new LinhaProducao {descricao = new DescricaoLinhaProducao {descricao = "Linha 2"}} );
                _context.SaveChanges ();

            }

        }

        // GET: api/linhaproducao
        [HttpGet]
        public IEnumerable<LinhaProducao> GetLinhasProducao () {

            IEnumerable<LinhaProducao> lista = repo.SelectAll();
            return lista;
        }

        // POST: api/linhaproducao
        [HttpPost]
        public async Task<ActionResult<LinhaProducao>> PostLinhaProducao (LinhaProducao lp) {

            List<LinhaProducao> listaLinhasProducao = _context.LinhasProducao.ToList ();

            foreach (LinhaProducao linhaP in listaLinhasProducao) {
                if (linhaP.descricao.Equals (lp.descricao)) {
                    return BadRequest();
                }
            }

            return Ok(repo.Insert(lp));

        }

    }
 
}