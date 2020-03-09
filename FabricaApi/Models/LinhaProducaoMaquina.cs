using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Models {

    public class LinhaProducaoMaquina {

        public long Id { get; set; }
        
        public long idLinhaProducao { get; set; }

        public long idMaquina { get; set; }

        public LinhaProducaoMaquina () {

        }

    }

}