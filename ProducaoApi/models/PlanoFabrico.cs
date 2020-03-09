using System;
using System.Collections.Generic;
using ProducaoApi.DTOs;
using InterfaceGenerica.ValueObjects;

namespace ProducaoApi.Models
{
    public class PlanoFabrico
    {
        
        public long Id { get; set; }

        public NomePlanoFabrico nome { get; set; }

        public List<Operacao> listaOperacoes { get; set; }

    }
}