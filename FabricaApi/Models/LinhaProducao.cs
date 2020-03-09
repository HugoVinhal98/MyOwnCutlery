using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Models {

    public class LinhaProducao {

        public long Id { get; set; }

        public DescricaoLinhaProducao descricao { get; set; }

    }

}