using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicoWeb.Models;
using ServicoWeb.Repo;

namespace ServicoWeb.Controllers {

    [Route ("api/utilizador")]
    [ApiController]
    public class UtilizadorController : ControllerBase {

        private readonly WebContext _context;

        UtilizadorRepositorio repo;

        public UtilizadorController (WebContext context) {

            _context = context;

            repo = new UtilizadorRepositorio (_context);

            if (_context.Utilizadores.Count () == 0) {
                // Create a new LinhaProducao if collection is empty,
                // which means you can't delete all Utilizadores.
                _context.Utilizadores.Add (new Utilizador { numeroUtilizador = new NumeroUtilizador { numeroUtilizador = 1150870 }, nome = "Francisco", email = new Email { email = "1150870@isep.ipp.pt" }, password = new Password { password = "123A321" }, tipoUtilizador = new TipoUtilizador { tipoUtilizador = "Administrador" } });
                _context.SaveChanges ();

            }

        }

        // GET: api/utilizador
        [HttpGet]
        public IEnumerable<Utilizador> GetUtilizadores () {

            IEnumerable<Utilizador> lista = repo.SelectAll ();
            return lista;
        }

        // POST: api/utilizador
        [HttpPost]
        public async Task<ActionResult<Utilizador>> PostUtilizador (Utilizador u) {

            return Ok (repo.Insert (u));

        }

    }

}