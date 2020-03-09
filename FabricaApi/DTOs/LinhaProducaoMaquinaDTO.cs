using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.DTOs {

    public class LinhaProducaoMaquinaDTO {

        public long idLinhaProducao { get; set; }

        public long idMaquina { get; set; }

    }
}