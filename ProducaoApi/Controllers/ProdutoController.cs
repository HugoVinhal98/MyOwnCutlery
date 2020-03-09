using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProducaoApi.DTOs;
using ProducaoApi.Models;
using ProducaoApi.Repo;

namespace ProducaoApi.Controllers {
    [Route ("api/Produto")]
    [ApiController]
    [EnableCors ("MyPolicy")]
    public class ProdutoController : ControllerBase {

        private readonly ProducaoContext _context;
        ProdutoRepositorio repo;

        public ProdutoController (ProducaoContext context) {
            _context = context;
            repo = new ProdutoRepositorio (_context);

            if (_context.Produtos.Count () == 0) {

                _context.Produtos.Add (new Produto { nome = new NomeProduto { nome = "ProdutoBase" },  descricao = new DescricaoProduto { descricao = "Produto por defeito" }, planoFabrico = new NomePlanoFabrico { nome = "PlanoFabrico1" } });

                _context.SaveChanges ();
                
            }
        }

        // GET: api/Produto
        [HttpGet]
        public IEnumerable<ProdutoDTO> GetProdutos () {

            IEnumerable<Produto> lista = repo.SelectAll ();

            return toDTO.ListaProdutosToDTO (lista);

        }

        // GET: api/Produto/ProdutoBase
        [HttpGet ("{nome}")]
        public ActionResult<ProdutoDTO> GetProdutoByNome (String nome) {

            long id = 0;

            List<Produto> listaProd = _context.Produtos.ToList ();

            foreach (Produto prod in listaProd) {
                if (prod.nome.nome == nome) {
                    id = prod.Id;
                }

            }

            Produto p = repo.SelectById (id);

            if (p == null) {
                return NotFound ();
            }

            return Ok (toDTO.ProdutoToProdutoDTO (p));

        }

        // POST: api/produto
        [HttpPost]
        public ActionResult<Produto> PostProduto (Produto produto) {
            return repo.Insert (produto);
        }

    }
}