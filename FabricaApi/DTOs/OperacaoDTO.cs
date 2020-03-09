using Microsoft.EntityFrameworkCore;
using FabricaApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;


namespace FabricaApi.DTOs
{
    public class OperacaoDTO
    {        
        
        public string nomeTipoOp { get; set; }

        public string nomeOperacao { get; set; }

        public Duracao duracao { get; set; }
        
    }
}