
// Esta clase es el corazón de nuestra aplicación. Se encarga de gestionar todo:
// tiene las listas de libros, el historial de préstamos y las funciones para que todo funcione.


public class Biblioteca
{
    // Esta es la lista donde guardaremos todos los libros que pertenecen a la biblioteca.
    private List<Libro> catalogoDeLibros = new List<Libro>();

    // Esta es la lista que funcionará como el historial completo de la biblioteca.
    // Aquí guardaremos cada préstamo que se haya realizado.
    private List<Prestamo> historialDePrestamos = new List<Prestamo>();

    // Esta estructura es un "Diccionario", una herramienta muy potente para búsquedas rápidas.
    // Funciona con un sistema de 'clave' y 'valor'.
    // La 'clave' será una palabra (en minúsculas) del título de un libro.
    // El 'valor' será una lista de todos los libros que contienen esa palabra en su título.
    // Ejemplo: si un libro se llama "El gran Gatsby", el diccionario guardará:
    // "el" -> [libro de Gatsby]
    // "gran" -> [libro de Gatsby]
    // "gatsby" -> [libro de Gatsby]
    // Esto nos permite encontrar libros de forma muy eficiente aunque el usuario no escriba el título completo.
    private Dictionary<string, List<Libro>> indiceDeBusquedaPorPalabra = new Dictionary<string, List<Libro>>();

    // Usamos esta variable para asegurarnos de que cada libro nuevo tenga un Id único.
    // Cada vez que agregamos un libro, usamos este número y luego lo aumentamos en uno.
    private int proximoIdLibro = 1;

    // Esta función se encarga de añadir un nuevo libro a nuestra biblioteca.
    public void AgregarLibro(string nombreDelLibro)
    {
        // Creamos un nuevo objeto "Libro" usando nuestra plantilla.
        var nuevoLibro = new Libro
        {
            Id = proximoIdLibro,
            Nombre = nombreDelLibro,
            EstaPrestado = false // Un libro nuevo siempre está disponible.
        };

        // Añadimos el libro recién creado a nuestro catálogo general.
        catalogoDeLibros.Add(nuevoLibro);

        // Actualizamos nuestro diccionario de búsqueda para que este nuevo libro pueda ser encontrado.
        ActualizarIndiceDeBusqueda(nuevoLibro);

        // Incrementamos el contador para que el próximo libro tenga un Id diferente.
        proximoIdLibro++;

        Console.WriteLine($"\nEl libro '{nombreDelLibro}' ha sido agregado con éxito.");
    }

    // Esta es una función interna (privada) que descompone el título de un libro en palabras
    // y las agrega al diccionario de búsqueda para que sea fácil de encontrar.
    private void ActualizarIndiceDeBusqueda(Libro libro)
    {
        // Definimos los caracteres que separan las palabras (espacios, comas, etc.).
        char[] separadores = { ' ', ',', '.', ';', ':', '-' };
        // Convertimos el título a minúsculas y lo dividimos en palabras.
        var palabras = libro.Nombre.ToLower().Split(separadores, StringSplitOptions.RemoveEmptyEntries);

        // Recorremos cada palabra que encontramos en el título.
        foreach (var palabra in palabras)
        {
            // Si la palabra no existe todavía en nuestro índice de búsqueda...
            if (!indiceDeBusquedaPorPalabra.ContainsKey(palabra))
            {
                // ...la agregamos como una nueva clave con una lista vacía.
                indiceDeBusquedaPorPalabra[palabra] = new List<Libro>();
            }
            // Finalmente, añadimos el libro actual a la lista correspondiente a esa palabra.
            indiceDeBusquedaPorPalabra[palabra].Add(libro);
        }
    }

    // Esta función busca libros basándose en el texto que introduce el usuario.
    public List<Libro> BuscarLibros(string textoDeBusqueda)
    {
        // Usamos un HashSet para guardar los resultados. Esta estructura evita que se añadan libros duplicados
        // si, por ejemplo, el usuario busca "gran gatsby" y el libro coincide con ambas palabras.
        var librosEncontrados = new HashSet<Libro>();

        // Dividimos el texto del usuario en palabras individuales.
        char[] separadores = { ' ', ',', '.', ';', ':', '-' };
        var palabrasBuscadas = textoDeBusqueda.ToLower().Split(separadores, StringSplitOptions.RemoveEmptyEntries);

        // Por cada palabra que el usuario escribió...
        foreach (var palabra in palabrasBuscadas)
        {
            // ...revisamos si esa palabra existe como clave en nuestro índice de búsqueda.
            if (indiceDeBusquedaPorPalabra.ContainsKey(palabra))
            {
                // Si existe, obtenemos la lista de libros asociada a esa palabra.
                var librosConEsaPalabra = indiceDeBusquedaPorPalabra[palabra];
                // Agregamos todos esos libros a nuestro conjunto de resultados.
                foreach (var libro in librosConEsaPalabra)
                {
                    librosEncontrados.Add(libro);
                }
            }
        }

        // Convertimos el HashSet a una Lista y la devolvemos.
        return librosEncontrados.ToList();
    }

    // Esta función se encarga de registrar el préstamo de un libro.
    public void PrestarLibro(Libro libroAPrestar, string nombrePersona)
    {
        // Marcamos el libro como "prestado" para que no se pueda prestar de nuevo.
        libroAPrestar.EstaPrestado = true;

        // Creamos un nuevo objeto de tipo "Prestamo" para guardar los detalles.
        var nuevoPrestamo = new Prestamo
        {
            LibroPrestado = libroAPrestar,
            NombrePersona = nombrePersona,
            FechaPrestamo = DateTime.Now.Date, // La fecha actual (sin la hora).
            FechaDevolucion = null, // Se deja vacío porque aún no se ha devuelto.
            EstadoLibroDevuelto = "" // Se deja vacío por la misma razón.
        };

        // Añadimos este nuevo préstamo a nuestro historial.
        historialDePrestamos.Add(nuevoPrestamo);

        Console.WriteLine($"\nSe ha prestado el libro '{libroAPrestar.Nombre}' a {nombrePersona}.");
    }

    // Esta función nos devuelve una lista de todos los préstamos de libros que aún no han sido devueltos.
    public List<Prestamo> ObtenerLibrosPrestadosSinDevolver()
    {
        // Usamos LINQ para filtrar la lista del historial.
        // Nos quedamos solo con aquellos préstamos donde la fecha de devolución está vacía (es nula).
        return historialDePrestamos.Where(p => p.FechaDevolucion == null).ToList();
    }

    // Esta función actualiza el estado de un libro y un préstamo cuando se devuelve.
    public void DevolverLibro(Prestamo prestamoADevolver, string estadoDelLibro)
    {
        // Primero, marcamos el libro como disponible de nuevo en nuestro catálogo.
        prestamoADevolver.LibroPrestado.EstaPrestado = false;

        // Después, actualizamos la información del préstamo en el historial.
        prestamoADevolver.FechaDevolucion = DateTime.Now.Date; // Registramos la fecha de devolución (sin la hora).
        prestamoADevolver.EstadoLibroDevuelto = estadoDelLibro; // Registramos la condición del libro.

        Console.WriteLine($"\nEl libro '{prestamoADevolver.LibroPrestado.Nombre}' ha sido devuelto.");
    }

    // Esta función simplemente nos devuelve el historial completo de préstamos.
    public List<Prestamo> ObtenerHistorialDePrestamos()
    {
        return historialDePrestamos;
    }

    // Esta función nos devuelve una lista con todos los libros registrados en la biblioteca.
    public List<Libro> ObtenerCatalogoDeLibros()
    {
        // Simplemente devuelve la lista completa que tenemos guardada.
        return catalogoDeLibros;
    }
}