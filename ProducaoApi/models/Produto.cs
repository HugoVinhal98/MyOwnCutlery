using Microsoft.EntityFrameworkCore;
using ProducaoApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;


namespace ProducaoApi.Models
{
    public class Produto
    {
        public long Id { get; set; }  //primary key
        
        public NomeProduto nome { get; set; } // value object com o nome do produto

        public DescricaoProduto descricao { get; set; } // value object com a descrição do produto

        public NomePlanoFabrico planoFabrico { get; set; }
    }
}