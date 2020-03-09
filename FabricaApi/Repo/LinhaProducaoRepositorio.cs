using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Repo {

    public class LinhaProducaoRepositorio : IRepositorio<LinhaProducao> {

        private FabricaContext _context;

        public LinhaProducaoRepositorio (FabricaContext context) {
            _context = context;
        }

        public IEnumerable<LinhaProducao> SelectAll () {

            IEnumerable<LinhaProducao> lista = _context.LinhasProducao
            .Include (d => d.descricao);

            return lista;

        }

        public LinhaProducao Insert (LinhaProducao lp) {

            _context.LinhasProducao.Add (lp);
            _context.SaveChanges ();

            return lp;
        }

        public void Update (LinhaProducao lp) {
            ////
        }

        public LinhaProducao Delete (long lp) {
            return null;
        }

        public LinhaProducao SelectById (long lp) {
            return null;
        }

    }
}