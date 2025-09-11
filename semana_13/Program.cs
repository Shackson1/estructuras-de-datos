// Se define el espacio de nombres para organizar el código.
namespace GestorDeRevistas
{
    // Se importa la librería System para poder usar la clase Console.
    using System;

    // Declaración de la clase principal del programa.
    class Programa
    {
        // El método Main es el punto de entrada de la aplicación. Se ejecuta al iniciar el programa.
        static void Main(string[] args)
        {
            // Se crea una instancia del catálogo de revistas.
            // Esto llama al constructor de CatalogoRevistas y carga los datos.
            CatalogoRevistas miCatalogo = new CatalogoRevistas();
            bool continuar = true;

            // Bucle principal del menú. Se repetirá mientras la variable 'continuar' sea verdadera.
            while (continuar)
            {
                // Se limpia la consola y se muestra el menú de opciones al usuario.
                Console.Clear();
                Console.WriteLine("   Catálogo de Revistas");
                Console.WriteLine("1. Buscar un título de revista");
                Console.WriteLine("2. Salir");
                Console.Write("Por favor, seleccione una opción: ");

                // Se lee la opción que el usuario ingresa por teclado.
                string opcion = Console.ReadLine();

                // La estructura switch evalúa la opción ingresada por el usuario.
                switch (opcion)
                {
                    // Caso para la opción "1": Buscar revista.
                    case "1":
                        // Se pide al usuario que ingrese el título a buscar.
                        Console.Write("Ingrese el título de la revista a buscar: ");
                        string tituloABuscar = Console.ReadLine();

                        // Se llama al método de búsqueda del catálogo.
                        // El resultado (true o false) se guarda en la variable 'encontrado'.
                        bool encontrado = miCatalogo.BuscarTitulo(tituloABuscar);

                        // Se verifica el resultado de la búsqueda.
                        if (encontrado)
                        {
                            // Si es verdadero, se muestra el mensaje de éxito.
                            Console.WriteLine("\nResultado: ¡Encontrado!");
                        }
                        else
                        {
                            // Si es falso, se muestra el mensaje de que no se encontró.
                            Console.WriteLine("\nResultado: No encontrado.");
                        }
                        break;

                    // Caso para la opción "2": Salir del programa.
                    case "2":
                        // Se cambia el valor de 'continuar' a falso para salir del bucle while.
                        continuar = false;
                        Console.WriteLine("\nSaliendo del programa...");
                        break;

                    // Caso 'default': Se ejecuta si el usuario ingresa una opción no válida.
                    default:
                        Console.WriteLine("\nOpción no válida. Por favor, intente de nuevo.");
                        break;
                }

                // Esta sección se ejecuta después de cada acción (excepto salir).
                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    // Espera a que el usuario presione una tecla antes de continuar y limpiar la pantalla.
                    Console.ReadKey();
                }
            }
        }
    }
}