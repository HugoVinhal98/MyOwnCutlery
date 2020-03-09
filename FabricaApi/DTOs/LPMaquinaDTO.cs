using Microsoft.EntityFrameworkCore;
using FabricaApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;


namespace FabricaApi.DTOs
{
    public class LPMaquinaDTO
    {        
        
        public string descricao { get; set; }

        public int posicao { get; set; }
        
    }
}