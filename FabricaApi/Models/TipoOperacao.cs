using System.Collections.Generic;
using InterfaceGenerica.ValueObjects;


namespace FabricaApi.Models

{

    public class TipoOperacao {

        public long Id { get; set; }

        public NomeTipoOperacao nome { get; set; }

        public Ferramenta ferramenta { get; set; }

        public TempoSetup tempoSetup { get; set; }

    }
    
}