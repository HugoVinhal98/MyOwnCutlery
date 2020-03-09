using System.Collections.Generic;
using InterfaceGenerica.ValueObjects;

namespace FabricaApi.Models {

    public class Operacao {

        public long Id { get; set; } //Primary Key

        public NomeOperacao nome { get; set; }

        public long tipoOpId { get; set; } //Entity 

        public Duracao duracao { get; set; } //Value Object

    }
}