using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Repo {

    public class MaquinaRepositorio : IRepositorio<Maquina> {

        private FabricaContext _context;

        public MaquinaRepositorio (FabricaContext context) {
            _context = context;
        }

        public IEnumerable<Maquina> SelectAll () {

            IEnumerable<Maquina> maquinas = _context.Maquinas
                .Include (d => d.descricao)
                .Include (d => d.marca)
                .Include (d => d.modelo);
            return maquinas;

        }

        public IEnumerable<Maquina> SelectMaquinasTipoMaquina (long id) {

            IEnumerable<Maquina> maquinas = _context.Maquinas
                .Include (d => d.descricao)
                .Include (d => d.marca)
                .Include (d => d.modelo);

            List<Maquina> lista = new List<Maquina> ();

            foreach (Maquina m in maquinas) {
                if (m.tipoMaquina == id) {
                    lista.Add (m);
                }
            }

            return lista;

        }

        public Maquina SelectById (long id) {
            IEnumerable<Maquina> listaMaq = _context.Maquinas;

            foreach (Maquina m in listaMaq) {
                if (m.Id.Equals (id)) {
                    return m;
                }
            }

            return null;
        }

        public Maquina Insert (Maquina m) {

            _context.Maquinas.Add (m);
            _context.SaveChanges ();

            return m;
        }

        public void Update (Maquina m) {
            ////
        }

        public Maquina Delete (long id) {
            List<Maquina> lista = _context.Maquinas.ToList ();

            var m = _context.Maquinas.Find (id);

            _context.Maquinas.Remove (m);

            _context.SaveChanges ();

            return m;
        }

        public Maquina ChangeTipoMaquina (long id, TipoMaquina tipo) {
            long tipoM = 0;
            List<TipoMaquina> listaTM = _context.TipoMaquinas.ToList ();

            foreach (TipoMaquina tp in listaTM) {
                if (tp.descricao.descricao == tipo.descricao.descricao) {
                    tipoM = tp.Id;
                }
            }

            Maquina maq = _context.Maquinas.Find (id);

            maq.tipoMaquina = tipoM;

            _context.SaveChanges ();

            return maq;

        }

        public Maquina ChangeAtivada (long id) {
            List<TipoMaquina> listaTM = _context.TipoMaquinas.ToList ();

            Maquina maq = _context.Maquinas.Find (id);

            maq.ativa = !maq.ativa;

            _context.SaveChanges ();

            return maq;
        }
    }
}