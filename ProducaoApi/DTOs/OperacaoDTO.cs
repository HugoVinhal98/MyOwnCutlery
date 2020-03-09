using System.Collections.Generic;
using InterfaceGenerica.ValueObjects;

namespace ProducaoApi.DTOs
{
    public class OperacaoDTO
    {
        public long Id { get; set; }
        public long tipoOperacaoId { get; set; }
        public Duracao duracao { get; set; }
    }
} 