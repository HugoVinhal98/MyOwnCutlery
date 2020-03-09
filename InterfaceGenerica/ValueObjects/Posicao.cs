using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterfaceGenerica.ValueObjects
{
public class Posicao : ValueObject
{

    public string posicao { get; set; }
    

    protected override IEnumerable<object> GetAtomicValues()
    {
        // Using a yield return statement to return each element one at a time
        yield return posicao;
    }
}
}