
// Se encarga de mostrar el menú al usuario, leer lo que escribe y llamar
// a las funciones correspondientes de la clase Biblioteca.


class ProgramaPrincipal
{
    // El método Main es el punto de partida de cualquier aplicación de consola en C#.
    static void Main(string[] args)
    {
        // Creamos una "instancia" u "objeto" de nuestra clase Biblioteca.
        // A partir de ahora, "miBiblioteca" es nuestro centro de operaciones.
        var miBiblioteca = new Biblioteca();

        // Creamos unos cuantos libros de ejemplo para que el programa no empiece vacío.
        miBiblioteca.AgregarLibro("Cien años de soledad");
        miBiblioteca.AgregarLibro("El señor de los anillos: La comunidad del anillo");
        miBiblioteca.AgregarLibro("Don Quijote de la Mancha");
        miBiblioteca.AgregarLibro("1984");
        Console.WriteLine("\n--- ¡Bienvenido al Sistema de Gestión de la Biblioteca! ---");

        // Este bucle 'while (true)' se repetirá infinitamente, mostrando el menú
        // una y otra vez hasta que el usuario elija la opción de salir.
        while (true)
        {
            Console.WriteLine("\n¿Qué te gustaría hacer?");
            Console.WriteLine("1. Agregar un nuevo libro");
            Console.WriteLine("2. Prestar un libro");
            Console.WriteLine("3. Devolver un libro");
            Console.WriteLine("4. Mostrar libros prestados sin devolver");
            Console.WriteLine("5. Mostrar historial completo de préstamos");
            Console.WriteLine("6. Mostrar todos los libros de la biblioteca");
            Console.WriteLine("7. Salir");
            Console.Write("Elige una opción: ");

            // Leemos la opción que el usuario escribe.
            string opcion = Console.ReadLine();

            // Usamos una estructura 'switch' para ejecutar una acción diferente según la opción elegida.
            switch (opcion)
            {
                case "1":
                    ManejarAgregarLibro(miBiblioteca);
                    break;
                case "2":
                    ManejarPrestarLibro(miBiblioteca);
                    break;
                case "3":
                    ManejarDevolverLibro(miBiblioteca);
                    break;
                case "4":
                    MostrarLibrosPrestados(miBiblioteca);
                    break;
                case "5":
                    MostrarHistorialCompleto(miBiblioteca);
                    break;
                case "6":
                    MostrarCatalogoCompleto(miBiblioteca);
                    break;
                case "7":
                    Console.WriteLine("\nGracias por usar el sistema. ¡Hasta pronto!");
                    return; // 'return' aquí termina el método Main y, por lo tanto, el programa.
                default:
                    Console.WriteLine("\nOpción no válida. Por favor, elige un número del 1 al 7.");
                    break;
            }
        }
    }

    // Esta función guía al usuario para agregar un nuevo libro.
    static void ManejarAgregarLibro(Biblioteca biblioteca)
    {
        Console.Write("\nIntroduce el nombre del libro que quieres agregar: ");
        string nombreLibro = Console.ReadLine();

        // Verificamos que el usuario haya escrito algo.
        if (!string.IsNullOrWhiteSpace(nombreLibro))
        {
            biblioteca.AgregarLibro(nombreLibro);
        }
        else
        {
            Console.WriteLine("El nombre del libro no puede estar vacío.");
        }
    }

    // Esta función maneja toda la lógica para prestar un libro.
    static void ManejarPrestarLibro(Biblioteca biblioteca)
    {
        Console.Write("\nEscribe una o más palabras del título del libro a buscar: ");
        string busqueda = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(busqueda))
        {
            Console.WriteLine("Debes ingresar un texto para buscar.");
            return;
        }

        // Llamamos a la función de búsqueda de la biblioteca.
        var resultados = biblioteca.BuscarLibros(busqueda);

        // Si la lista de resultados está vacía...
        if (!resultados.Any()) // .Any() es una forma rápida de ver si una lista tiene al menos un elemento.
        {
            Console.WriteLine("No se encontraron libros que coincidan con tu búsqueda.");
            return;
        }

        Console.WriteLine("\nSe encontraron los siguientes libros:");
        // Mostramos los resultados en una lista numerada.
        for (int i = 0; i < resultados.Count; i++)
        {
            // Verificamos si el libro está disponible o ya fue prestado.
            string estado = resultados[i].EstaPrestado ? "[PRESTADO]" : "[DISPONIBLE]";
            Console.WriteLine($"{i + 1}. {resultados[i].Nombre} {estado}");
        }

        Console.Write("\nSelecciona el número del libro que quieres prestar (o 0 para cancelar): ");
        if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= resultados.Count)
        {
            // El usuario eligió un número válido. Obtenemos el libro correspondiente.
            // Restamos 1 porque las listas empiezan en el índice 0.
            var libroSeleccionado = resultados[seleccion - 1];

            // Revisamos de nuevo si el libro ya está prestado.
            if (libroSeleccionado.EstaPrestado)
            {
                Console.WriteLine("Este libro ya ha sido prestado. No se puede volver a prestar.");
                return;
            }

            Console.Write("Introduce el nombre de la persona que solicita el libro: ");
            string nombrePersona = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombrePersona))
            {
                // Si todo es correcto, llamamos a la función para prestar el libro.
                biblioteca.PrestarLibro(libroSeleccionado, nombrePersona);
            }
            else
            {
                Console.WriteLine("El nombre de la persona no puede estar vacío.");
            }
        }
        else
        {
            Console.WriteLine("Selección no válida o cancelada.");
        }
    }

    // Esta función maneja la devolución de un libro.
    static void ManejarDevolverLibro(Biblioteca biblioteca)
    {
        // Obtenemos la lista de libros que están actualmente prestados.
        var prestados = biblioteca.ObtenerLibrosPrestadosSinDevolver();

        if (!prestados.Any())
        {
            Console.WriteLine("\nNo hay libros prestados para devolver en este momento.");
            return;
        }

        Console.WriteLine("\nEstos son los libros prestados actualmente:");
        for (int i = 0; i < prestados.Count; i++)
        {
            Console.WriteLine($"{i + 1}. '{prestados[i].LibroPrestado.Nombre}' (prestado a: {prestados[i].NombrePersona})");
        }

        Console.Write("\nSelecciona el número del libro que quieres devolver (o 0 para cancelar): ");
        if (int.TryParse(Console.ReadLine(), out int seleccion) && seleccion > 0 && seleccion <= prestados.Count)
        {
            var prestamoSeleccionado = prestados[seleccion - 1];
            string estadoLibro;

            // Pedimos al usuario que indique el estado del libro.
            while (true)
            {
                Console.Write("¿El libro se devolvió en buen estado o mal estado? (escribe 'buen' o 'mal'): ");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta == "buen")
                {
                    estadoLibro = "Buen estado";
                    break;
                }
                else if (respuesta == "mal")
                {
                    estadoLibro = "Mal estado";
                    break;
                }
                else
                {
                    Console.WriteLine("Respuesta no válida. Por favor, escribe 'buen' o 'mal'.");
                }
            }
            
            // Finalmente, llamamos a la función para devolver el libro.
            biblioteca.DevolverLibro(prestamoSeleccionado, estadoLibro);
        }
        else
        {
            Console.WriteLine("Selección no válida o cancelada.");
        }
    }

    // Esta función muestra la lista de libros que no han sido devueltos.
    static void MostrarLibrosPrestados(Biblioteca biblioteca)
    {
        var prestados = biblioteca.ObtenerLibrosPrestadosSinDevolver();

        if (!prestados.Any())
        {
            Console.WriteLine("\nTodos los libros están en la biblioteca. No hay ninguno prestado.");
            return;
        }

        Console.WriteLine("\n--- Libros Prestados Sin Devolver ---");
        foreach (var prestamo in prestados)
        {
            Console.WriteLine($" - Título: {prestamo.LibroPrestado.Nombre}");
            Console.WriteLine($"   Prestado a: {prestamo.NombrePersona}");
            // Le damos formato a la fecha para que solo muestre día, mes y año.
            Console.WriteLine($"   Fecha de préstamo: {prestamo.FechaPrestamo:dd/MM/yyyy}"); 
        }
    }

    // Esta función muestra el historial completo de todos los préstamos.
    static void MostrarHistorialCompleto(Biblioteca biblioteca)
    {
        var historial = biblioteca.ObtenerHistorialDePrestamos();

        if (!historial.Any())
        {
            Console.WriteLine("\nNo se ha realizado ningún préstamo todavía.");
            return;
        }

        Console.WriteLine("\n--- Historial Completo de Préstamos ---");
        foreach (var prestamo in historial)
        {
            Console.WriteLine($"\n - Título: {prestamo.LibroPrestado.Nombre}");
            Console.WriteLine($"   Prestado a: {prestamo.NombrePersona}");
            // Le damos formato a la fecha para que solo muestre día, mes y año.
            Console.WriteLine($"   Fecha de préstamo: {prestamo.FechaPrestamo:dd/MM/yyyy}");
            
            // Si el libro ya fue devuelto, mostramos también la información de la devolución.
            if (prestamo.FechaDevolucion.HasValue) // .HasValue comprueba si una fecha nullable no está vacía.
            {
                // Le damos formato a la fecha de devolución de la misma manera.
                Console.WriteLine($"   Fecha de devolución: {prestamo.FechaDevolucion.Value:dd/MM/yyyy}");
                Console.WriteLine($"   Estado a la devolución: {prestamo.EstadoLibroDevuelto}");
                Console.WriteLine($"   ESTADO: DEVUELTO");
            }
            else
            {
                Console.WriteLine($"   ESTADO: AÚN PRESTADO");
            }
        }
    }
    
    // Esta función muestra todos los libros que existen en el catálogo de la biblioteca.
    static void MostrarCatalogoCompleto(Biblioteca biblioteca)
    {
        // Obtenemos la lista completa de libros desde la biblioteca.
        var catalogo = biblioteca.ObtenerCatalogoDeLibros();

        // Verificamos si hay libros para mostrar.
        if (!catalogo.Any())
        {
            Console.WriteLine("\nActualmente no hay libros registrados en la biblioteca.");
            return;
        }

        Console.WriteLine("\n--- Catálogo Completo de Libros ---");
        // Recorremos cada libro en el catálogo.
        foreach (var libro in catalogo)
        {
            // Determinamos el estado del libro para mostrarlo de forma clara.
            string estado = libro.EstaPrestado ? "[PRESTADO]" : "[DISPONIBLE]";
            // Imprimimos la información del libro en un formato ordenado.
            Console.WriteLine($" - ID: {libro.Id}, Título: {libro.Nombre}, Estado: {estado}");
        }
    }
}