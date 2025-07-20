
// Simula el comportamiento de navegación con botón "Atrás"

class Program
{
    static void Main(string[] args)
    {
        Historial historial = new Historial();

        // Simula la navegación por varias páginas
        historial.VisitarPagina("https://pagina1.com");
        historial.VisitarPagina("https://pagina2.com");
        historial.VisitarPagina("https://pagina3.com");
        historial.VisitarPagina("https://pagina4.com");

        historial.PaginaActual();  // Muestra la página actual
        historial.MostrarHistorial(); // Muestra todo el historial

        // Simula el botón atrás
        Console.WriteLine("\n-- Retrocediendo una vez --");
        historial.Retroceder();
        historial.PaginaActual();

        Console.WriteLine("\n-- Retrocediendo otra vez --");
        historial.Retroceder();
        historial.PaginaActual();

        // Fin
        historial.MostrarHistorial();
    }
}
