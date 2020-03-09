using System;
using System.Collections.Generic;
using FabricaApi.Models;
using ProducaoApi.DTOs;

namespace ProducaoApi.DTOs
{
    public class PlanoFabricoDTO
    {

        public string nome { get; set; }

        public List<string> listaOperacoes { get; set; }

    }
}