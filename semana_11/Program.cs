// Usamos el espacio de nombres System para acceder a funcionalidades básicas de la consola como Console.WriteLine y Console.ReadLine.
using System;

/// <summary>
/// Esta es la clase principal del programa, donde todo comienza.
/// Se encarga de mostrar el menú al usuario, leer sus entradas y coordinar las acciones
/// con la clase Traductor.
/// </summary>
public class Programa
{
    /// <summary>
    /// El método Main es el punto de entrada de nuestra aplicación.
    /// </summary>
    static void Main(string[] args)
    {
        // Creamos una instancia de nuestra clase Traductor para poder usar sus métodos.
        // Este objeto "traductor" contendrá el diccionario y la lógica para manejarlo.
        Traductor miTraductor = new Traductor();

        // Creamos una variable para almacenar la opción que elija el usuario en el menú.
        string opcionSeleccionada;

        // Iniciamos un bucle "do-while" que se ejecutará al menos una vez y continuará
        // mientras el usuario no elija la opción "0" para salir.
        do
        {
            // Mostramos el menú de opciones en la consola.
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.WriteLine("==============================================");
            Console.Write("Seleccione una opción: ");

            // Leemos la opción que el usuario ingresa por teclado.
            opcionSeleccionada = Console.ReadLine();

            // Usamos una estructura "switch" para ejecutar el código correspondiente a la opción elegida.
            switch (opcionSeleccionada)
            {
                // Caso 1: El usuario quiere traducir una frase.
                case "1":
                    Console.Write("Por favor, ingrese la frase a traducir: ");
                    // Leemos la frase que escribe el usuario.
                    string fraseParaTraducir = Console.ReadLine();
                    // Llamamos al método de nuestro objeto traductor para que haga el trabajo.
                    string resultadoTraduccion = miTraductor.TraducirFrase(fraseParaTraducir);
                    // Mostramos el resultado.
                    Console.WriteLine("Traducción (parcial): " + resultadoTraduccion);
                    break;

                // Caso 2: El usuario quiere agregar una nueva palabra.
                case "2":
                    Console.Write("Ingrese la palabra en español: ");
                    string palabraEsp = Console.ReadLine();
                    Console.Write("Ingrese la palabra en inglés: ");
                    string palabraIng = Console.ReadLine();
                    // Llamamos al método para agregar la nueva palabra al diccionario del traductor.
                    miTraductor.AgregarNuevaPalabra(palabraEsp, palabraIng);
                    break;

                // Caso 0: El usuario quiere salir del programa.
                case "0":
                    Console.WriteLine("¡Hasta luego! Gracias por usar el traductor.");
                    break;

                // Opción por defecto: Se ejecuta si el usuario ingresa un número o texto no válido.
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }

        } while (opcionSeleccionada != "0"); // La condición para que el bucle continúe.
    }
}