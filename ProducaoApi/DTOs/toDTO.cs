using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProducaoApi.DTOs;
using ProducaoApi.Models;

namespace ProducaoApi.DTOs {

    public static class toDTO {

        public static ProdutoDTO ProdutoToProdutoDTO (Produto produto) {

            ProdutoDTO dto;
            dto = new ProdutoDTO { nome = produto.nome.nome, descricao = produto.descricao.descricao, planoFabrico = produto.planoFabrico.nome };

            return dto;

        }

        public static IEnumerable<ProdutoDTO> ListaProdutosToDTO (IEnumerable<Produto> lista) {

            List<ProdutoDTO> listaFinal = new List<ProdutoDTO> ();

            foreach (Produto p in lista) {
                listaFinal.Add (toDTO.ProdutoToProdutoDTO (p));
            }

            IEnumerable<ProdutoDTO> l = listaFinal;
            return l;
            
        }
    }
}