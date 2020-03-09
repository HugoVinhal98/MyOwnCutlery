using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace InterfaceGenerica.ValueObjects
{
public class Duracao : ValueObject
{

    public int minutos { get; set; }
    public int segundos { get; set; }

    private Duracao() { }

    public Duracao(int min, int seg)
    {
        minutos = min;
        segundos = seg;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        // Using a yield return statement to return each element one at a time
        yield return minutos;
        yield return segundos;
    }
}
}