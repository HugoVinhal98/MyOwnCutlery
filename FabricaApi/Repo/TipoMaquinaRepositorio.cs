using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Repo {

    public class TipoMaquinaRepositorio : IRepositorio<TipoMaquina> {

        private FabricaContext _context;

        public TipoMaquinaRepositorio (FabricaContext context) {
            _context = context;
        }

        public IEnumerable<TipoMaquina> SelectAll () {

            IEnumerable<TipoMaquina> lista = _context.TipoMaquinas;

            return lista;

        }

        public TipoMaquina SelectById (long id) {

            TipoMaquina tm = _context.TipoMaquinas.Find(id);

            return tm;

        }

        public TipoMaquina Insert (TipoMaquina tp) {

            _context.TipoMaquinas.Add (tp);
            _context.SaveChanges ();

            return tp;
        }

        public TipoMaquina Delete (long id) {

            List<ListaMaquinasOperacao> lista = _context.TipoMaquinas_Operacao.ToList ();

            var tp = _context.TipoMaquinas.Find (id);

            foreach (ListaMaquinasOperacao lmo in lista) {
                if (lmo.idTipoMaquina == id) {
                    _context.TipoMaquinas_Operacao.Remove (lmo);
                }
            }

            _context.TipoMaquinas.Remove (tp);
            _context.SaveChanges ();

            return tp;
        }

        public void Update (TipoMaquina tp) {
            ////
        }

    }
}