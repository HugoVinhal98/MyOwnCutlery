using Microsoft.EntityFrameworkCore;
using ProducaoApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;


namespace ProducaoApi.DTOs
{
    public class ProdutoDTO
    {        

        public string nome { get; set; }

        public string descricao { get; set; }

        public string planoFabrico { get; set; }

    }
}