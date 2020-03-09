using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Repo {

    public class LinhaProducaoMaquinaRepositorio : IRepositorio<LinhaProducaoMaquina> {

        private FabricaContext _context;

        public LinhaProducaoMaquinaRepositorio (FabricaContext context) {
            _context = context;
        }

        public IEnumerable<LinhaProducaoMaquina> SelectAll () {

            IEnumerable<LinhaProducaoMaquina> lista = _context.LinhasProducaoMaquina;

            return lista;

        }

        public LinhaProducaoMaquina Insert (LinhaProducaoMaquina lmp) {

            _context.LinhasProducaoMaquina.Add (lmp);
            _context.SaveChanges ();

            return lmp;
        }

        public void DefinirMaquinasDeLP (long id, List<Maquina> l) {

            List<LinhaProducaoMaquina> linhaProducaoMaquinaLista = _context.LinhasProducaoMaquina.ToList ();
            List<Maquina> listMaquinas = _context.Maquinas.ToList();

            List<long> listaIdsMaquina = new List<long> ();

            foreach (Maquina maquina in l) {
                // Não inserir duplicados
                if (!(listaIdsMaquina.Contains (maquina.Id))) {
                    listaIdsMaquina.Add (maquina.Id);
                }
            }

            foreach(Maquina m in listMaquinas) {
                foreach (Maquina m2 in l) {
                    if (m.Id == m2.Id) {
                        m.posicao = m2.posicao;
                    }
                }
            }

            List<long> listaLinhaProdMaq = new List<long> ();

            foreach (LinhaProducaoMaquina lm in linhaProducaoMaquinaLista) {
                if (lm.idLinhaProducao == id) {
                    listaLinhaProdMaq.Add (lm.idMaquina);
                }
            }

            foreach (long idOpInput in listaIdsMaquina) {
                if (!listaLinhaProdMaq.Contains (idOpInput)) {
                    // REMOVE FROM DB WITH idOpInput
                    LinhaProducaoMaquina objectLPM = new LinhaProducaoMaquina ();
                    objectLPM.idLinhaProducao = id;
                    objectLPM.idMaquina = idOpInput;
                    _context.LinhasProducaoMaquina.Add (objectLPM);
                }
            }

            foreach (long idOpDb in listaLinhaProdMaq) {
                if (!listaIdsMaquina.Contains (idOpDb)) {
                    // ADD TO DB WITH idOpDb
                    LinhaProducaoMaquina toRemove = null;
                    foreach (LinhaProducaoMaquina lm in linhaProducaoMaquinaLista) {
                        if (lm.idLinhaProducao == id && lm.idMaquina == idOpDb) {
                            toRemove = lm;
                        }
                    }
                    _context.LinhasProducaoMaquina.Remove (toRemove);
                }
            }

            _context.SaveChanges ();

        }

        public void Update (LinhaProducaoMaquina lmp) {
            ////
        }

        public LinhaProducaoMaquina Delete (long lmp) {
            return null;
        }

        public LinhaProducaoMaquina SelectById (long lmp) {
            return null;
        }

    }
}