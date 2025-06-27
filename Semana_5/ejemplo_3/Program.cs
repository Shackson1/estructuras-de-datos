
class Program
{
    static void Main()
    {
        // Paso 1: Solicitar una palabra al usuario
        Console.Write("Ingresa una palabra: ");
        string entrada = Console.ReadLine();

        // Paso 2: Crear un objeto de la clase Palabra
        Palabra palabra = new Palabra(entrada);

        // Paso 3: Usar el método para verificar si es palíndromo
        if (palabra.EsPalindromo())
        {
            Console.WriteLine(" Es un palíndromo.");
        }
        else
        {
            Console.WriteLine(" No es un palíndromo.");
        }
    }
}

