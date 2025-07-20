// Administra el historial de navegación usando una pila (Stack)


public class Historial
{
    private Stack<Pagina> pilaHistorial;

    public Historial()
    {
        pilaHistorial = new Stack<Pagina>();
    }

    // Agrega una nueva página al historial
    public void VisitarPagina(string url)
    {
        Pagina nueva = new Pagina(url);
        pilaHistorial.Push(nueva);
        Console.WriteLine($"Visitando: {url}");
    }

    // Regresa a la página anterior (pop de la pila)
    public void Retroceder()
    {
        if (pilaHistorial.Count > 1)
        {
            // Elimina la página actual
            pilaHistorial.Pop();
            Console.WriteLine($"Retrocediendo a: {pilaHistorial.Peek()}");
        }
        else if (pilaHistorial.Count == 1)
        {
            Console.WriteLine("Estás en la primera página. No se puede retroceder más.");
        }
        else
        {
            Console.WriteLine("No hay páginas en el historial.");
        }
    }

    // Muestra la página actual
    public void PaginaActual()
    {
        if (pilaHistorial.Count > 0)
        {
            Console.WriteLine($"Página actual: {pilaHistorial.Peek()}");
        }
        else
        {
            Console.WriteLine("No hay páginas visitadas.");
        }
    }

    // Muestra todo el historial
    public void MostrarHistorial()
    {
        Console.WriteLine("\nHistorial de navegación:");
        foreach (var pagina in pilaHistorial)
        {
            Console.WriteLine($"- {pagina}");
        }
    }
}
