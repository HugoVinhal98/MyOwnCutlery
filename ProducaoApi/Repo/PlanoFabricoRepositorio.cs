using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProducaoApi.Models;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProducaoApi.Repo
{
    public class PlanoFabricoRepositorio : IRepositorio<PlanoFabrico>
    {
        private ProducaoContext _context;

        public PlanoFabricoRepositorio(ProducaoContext context) {
            _context = context;
        }

        public PlanoFabrico Insert(PlanoFabrico pf){
            _context.PlanosFabrico.Add(pf);
            _context.SaveChanges();
            return pf;
        }

        public PlanoFabrico SelectById(long id){
            var pf = _context.PlanosFabrico
            .Include(d => d.listaOperacoes)
            .FirstOrDefault(d => d.Id == id);

            return pf;
        }

        public IEnumerable<PlanoFabrico> SelectAll(){
            IEnumerable<PlanoFabrico> listaPf = _context.PlanosFabrico
            .Include(d => d.listaOperacoes);
            return listaPf;
        }   

        public void Update(PlanoFabrico pf){
            ////
        }

        public PlanoFabrico Delete(long id){
            return null;
        }
    }
}
