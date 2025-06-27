
public class ListaDePrecios
{
    // Lista de precios
    public List<Precio> Precios { get; set; }

    // Constructor: inicializa la lista con los valores dados
    public ListaDePrecios()
    {
        Precios = new List<Precio>
        {
            new Precio(50),
            new Precio(75),
            new Precio(46),
            new Precio(22),
            new Precio(80),
            new Precio(65),
            new Precio(8)
        };
    }

    // Método que devuelve el precio más bajo
    public double ObtenerPrecioMinimo()
    {
        return Precios.Min(p => p.Valor);
    }

    // Método que devuelve el precio más alto
    public double ObtenerPrecioMaximo()
    {
        return Precios.Max(p => p.Valor);
    }

    // Método para mostrar todos los precios (opcional)
    public void MostrarPrecios()
    {
        Console.WriteLine("Lista de precios:");
        foreach (var precio in Precios)
        {
            Console.WriteLine($"- {precio.Valor}");
        }
    }
}
