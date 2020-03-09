using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterfaceGenerica.ValueObjects
{
public class TipoUtilizador : ValueObject
{

    public string tipoUtilizador { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        // Using a yield return statement to return each element one at a time
        yield return tipoUtilizador;
    }
}
}