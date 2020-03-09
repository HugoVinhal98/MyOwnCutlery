using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaApi.Models;
using InterfaceGenerica.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FabricaApi.Models {

    public class Maquina {

        public long Id { get; set; }

        public DescricaoMaquina descricao { get; set; }

        public Marca marca { get; set; }

        public Modelo modelo { get; set; }

        public int posicao { get; set; }

        public long tipoMaquina { get; set; }

        public bool ativa { get; set; }

    }

}