using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicoWeb.Models;

namespace ServicoWeb.Repo {

    public class UtilizadorRepositorio : IRepositorio<Utilizador> {

        private WebContext _context;

        public UtilizadorRepositorio (WebContext context) {
            _context = context;
        }

        public IEnumerable<Utilizador> SelectAll () {

            IEnumerable<Utilizador> lista = _context.Utilizadores;

            return lista;

        }

        public Utilizador Insert (Utilizador u) {

            if (u.password.isValid () && u.email.isValid() && u.numeroUtilizador.isValid()) {
                _context.Utilizadores.Add (u);
                _context.SaveChanges ();

                return u;
            }

            return null;

        }

        public void Update (Utilizador u) {
            ////
        }

        public Utilizador Delete (long numeroUtilizador) {
            return null;
        }

        public Utilizador SelectById (long numeroUtilizador) {
            return null;
        }

    }
}