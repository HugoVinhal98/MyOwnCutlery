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
    public class ProdutoRepositorio : IRepositorio<Produto>
    {
        private ProducaoContext _context;

        public ProdutoRepositorio(ProducaoContext context) {
            _context = context;
        }

        public Produto Insert(Produto produto){
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public Produto SelectById(long id){
            var produto = _context.Produtos
            .FirstOrDefault(d => d.Id == id);

            return produto;
        }

        public IEnumerable<Produto> SelectAll(){
            IEnumerable<Produto> produtos = _context.Produtos;

            return produtos;
        }   

        public void Update(Produto p){
            ////
        }

        public Produto Delete(long id){
            ////
            Produto fake = new Produto();
            return fake;
        }
    }
}
