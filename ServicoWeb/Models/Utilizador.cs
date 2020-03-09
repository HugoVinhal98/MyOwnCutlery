using System;
using System.Collections.Generic;
using InterfaceGenerica.ValueObjects;

namespace ServicoWeb.Models {
    public class Utilizador {
        public long Id { get; set; }
        public NumeroUtilizador numeroUtilizador { get; set; }
        public string nome { get; set; }
        public Email email { get; set; }
        public Password password { get; set; }
        public TipoUtilizador tipoUtilizador { get; set; }
    }
}