using Microsoft.EntityFrameworkCore;
using FabricaApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using InterfaceGenerica.ValueObjects;


namespace FabricaApi.DTOs
{
    public class ListaMaquinasOperacaoDTO
    {        

        public long idTipoMaquina { get; set; }

        public long idOperacao { get; set; }

    }
}