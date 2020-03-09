using System.Collections.Generic;
using InterfaceGenerica.ValueObjects;

namespace FabricaApi.DTOs {

    public class MaquinaDTO {

        public string descricao { get; set; }

        public string marca { get; set; }

        public string modelo { get; set; }

        public string descTipoMaquina { get; set; }

        public bool ativa { get; set; }

    }

}