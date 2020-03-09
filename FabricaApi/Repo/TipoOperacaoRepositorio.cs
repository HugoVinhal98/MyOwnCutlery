using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Repo {

    public class TipoOperacaoRepositorio : IRepositorio<TipoOperacao> {

        private FabricaContext _context;

        public TipoOperacaoRepositorio (FabricaContext context) {
            _context = context;
        }

        public IEnumerable<TipoOperacao> SelectAll () {

            IEnumerable<TipoOperacao> lista = _context.tipoOperacoes
                .Include (d => d.ferramenta)
                .Include (d => d.tempoSetup);

            return lista;
        }

        public TipoOperacao SelectById (long id) {

            var op = _context.tipoOperacoes
                .Include (d => d.ferramenta)
                .Include (d => d.tempoSetup)
                .FirstOrDefault (d => d.Id == id);

            return op;
        }

        public TipoOperacao Insert (TipoOperacao op) {

            _context.tipoOperacoes.Add (op);
            _context.SaveChanges ();

            return op;
        }

        public TipoOperacao Delete (long id) {

            List<Operacao> lista = _context.Operacoes.ToList ();

            var op = _context.tipoOperacoes.Find (id);

            // Apaga todas as referencias de determinada operacao em TipoMaquinas_Operacao
            foreach (Operacao o in lista) {
                if (o.tipoOpId == id) {
                    _context.Operacoes.Remove (o);
                }
            }

            _context.tipoOperacoes.Remove (op);
            _context.SaveChanges ();

            return op;
        }

        public void Update (TipoOperacao p) {
            ////
        }

    }
}