
// Esta clase contiene el método Main, que es el punto de entrada de la aplicación.
// Aquí es donde mostramos el menú y llamamos a los métodos de la clase Agenda
// según la opción que el usuario elija.
class Program
{
    static void Main()
    {
        // Creamos una instancia de Agenda para usar todos sus métodos
        var agenda = new Agenda();
        // Bandera para controlar cuándo salir del bucle del menú
        bool salir = false;

        // Bucle infinito hasta que salir sea true
        while (!salir)
        {
            // Mostramos el menú de opciones
            Console.WriteLine("\n--- AGENDA TELEFÓNICA ---");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Eliminar contacto");
            Console.WriteLine("3. Mostrar todos");
            Console.WriteLine("4. Mostrar Random");
            Console.WriteLine("5. Mostrar Familia");
            Console.WriteLine("6. Mostrar Trabajo");
            Console.WriteLine("7. Ordenar contactos");
            Console.WriteLine("8. Buscar por nombre");
            Console.WriteLine("9. Salir");
            Console.Write("Opción: ");

            // Leemos la respuesta del usuario (puede ser null, por eso ?? "")
            string opcion = Console.ReadLine() ?? "";

            // Dependiendo de lo que haya escrito el usuario,
            // llamamos al método correspondiente de la agenda
            switch (opcion)
            {
                case "1":
                    // Llamamos a Agregar(), que pregunta datos y categoría
                    agenda.Agregar();
                    break;

                case "2":
                    // Llamamos a Eliminar(), que quita por nombre
                    agenda.Eliminar();
                    break;

                case "3":
                    // Muestra todos los contactos del vector general
                    agenda.MostrarTodos();
                    break;

                case "4":
                    // Muestra solo los contactos “random”
                    agenda.MostrarRandom();
                    break;

                case "5":
                    // Muestra solo los contactos de Familia
                    agenda.MostrarFamilia();
                    break;

                case "6":
                    // Muestra solo los contactos de Trabajo
                    agenda.MostrarTrabajo();
                    break;

                case "7":
                    // Ordena alfabéticamente el vector general
                    agenda.Ordenar();
                    break;

                case "8":
                    // Busca un contacto por nombre y lo muestra
                    agenda.BuscarPorNombre();
                    break;

                case "9":
                    // Cambiamos la bandera para salir del bucle y terminamos
                    salir = true;
                    Console.WriteLine("gracias por utilizar el porgrama");
                    break;

                default:
                    // Si la opción no está entre 1 y 9, avisamos al usuario
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}



