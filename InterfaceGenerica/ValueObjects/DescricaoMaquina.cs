using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterfaceGenerica.ValueObjects
{
public class DescricaoMaquina : ValueObject
{
    
    public string descricao { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        // Using a yield return statement to return each element one at a time
        yield return descricao;
    }
}
}