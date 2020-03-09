using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Repo {

    public class OperacaoRepositorio : IRepositorio<Operacao> {

        private FabricaContext _context;

        public OperacaoRepositorio (FabricaContext context) {
            _context = context;
        }

        public IEnumerable<Operacao> SelectAll () {

            IEnumerable<Operacao> lista = _context.Operacoes
                .Include (d => d.duracao);

            return lista;
        }

        public Operacao SelectById (long id) {

            var op = _context.Operacoes
                .Include (d => d.duracao)
                .FirstOrDefault (d => d.Id == id);

            return op;
        }

        public Operacao Insert (Operacao op) {

            _context.Operacoes.Add (op);
            _context.SaveChanges ();

            return op;
        }

        public Operacao Delete (long id) {

            List<ListaMaquinasOperacao> lista = _context.TipoMaquinas_Operacao.ToList ();

            var op = _context.Operacoes.Find (id);

            // Apaga todas as referencias de determinada operacao em TipoMaquinas_Operacao
            foreach (ListaMaquinasOperacao lmo in lista) {
                if (lmo.idOperacao == id) {
                    _context.TipoMaquinas_Operacao.Remove (lmo);
                }
            }

            _context.Operacoes.Remove (op);
            _context.SaveChanges ();

            return op;
        }

        public void Update (Operacao p) {
            ////
        }

    }
}