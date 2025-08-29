// Usamos el espacio de nombres System.Collections.Generic para poder utilizar la clase Dictionary.
using System.Collections.Generic;
// Usamos el espacio de nombres System.Text para poder utilizar la clase StringBuilder, que es eficiente para construir cadenas de texto.
using System.Text;


/// Esta clase se encarga de gestionar el diccionario de palabras y la lógica de traducción.
/// Contiene un diccionario privado que almacena los pares de palabras (español-inglés)
/// y los métodos para interactuar con él.

public class Traductor
{
    // Declaramos un diccionario privado para almacenar las palabras.
    // La clave (key) será la palabra en español y el valor (value) será su traducción al inglés.
    // Usar la palabra en español como clave hace que la búsqueda para la traducción sea muy rápida.
    private Dictionary<string, string> diccionarioDePalabras;

   
    /// Este es el constructor de la clase. Se ejecuta automáticamente cuando creamos un nuevo objeto Traductor.
    /// Su función es inicializar el diccionario y llenarlo con una lista base de palabras.
    
    public Traductor()
    {
        // Creamos una nueva instancia del diccionario.
        diccionarioDePalabras = new Dictionary<string, string>();

        // Agregamos la lista inicial de palabras al diccionario.
        // La palabra en español es la clave, y la palabra en inglés es el valor.
        diccionarioDePalabras.Add("tiempo", "time");
        diccionarioDePalabras.Add("persona", "person");
        diccionarioDePalabras.Add("año", "year");
        diccionarioDePalabras.Add("camino", "way");
        diccionarioDePalabras.Add("día", "day");
        diccionarioDePalabras.Add("cosa", "thing");
        diccionarioDePalabras.Add("hombre", "man");
        diccionarioDePalabras.Add("mundo", "world");
        diccionarioDePalabras.Add("vida", "life");
        diccionarioDePalabras.Add("mano", "hand");
        diccionarioDePalabras.Add("parte", "part");
        diccionarioDePalabras.Add("niño", "child");
        diccionarioDePalabras.Add("ojo", "eye");
        diccionarioDePalabras.Add("mujer", "woman");
        diccionarioDePalabras.Add("lugar", "place");
        diccionarioDePalabras.Add("trabajo", "work");
        diccionarioDePalabras.Add("semana", "week");
        diccionarioDePalabras.Add("caso", "case");
        diccionarioDePalabras.Add("punto", "point");
        diccionarioDePalabras.Add("gobierno", "government");
        diccionarioDePalabras.Add("empresa", "company");
    }

   
    /// Este método se encarga de traducir una frase completa del español al inglés.
    
    /// <param name="fraseOriginal">La frase en español que el usuario desea traducir.</param>
    /// <returns>Una cadena de texto con la frase traducida parcialmente.</returns>
    public string TraducirFrase(string fraseOriginal)
    {
        // Usamos StringBuilder para construir la frase traducida de manera eficiente.
        // Es mejor que concatenar strings con "+" repetidamente.
        StringBuilder fraseTraducida = new StringBuilder();

        // Dividimos la frase original en un arreglo de palabras, usando el espacio como separador.
        string[] palabras = fraseOriginal.Split(' ');

        // Recorremos cada palabra obtenida de la frase.
        foreach (string palabra in palabras)
        {
            // Para hacer la búsqueda insensible a mayúsculas y minúsculas, convertimos la palabra a minúsculas.
            // También removemos signos de puntuación comunes como la coma o el punto para encontrar la palabra limpia.
            string palabraLimpia = palabra.ToLower().TrimEnd('.', ',');

            // Comprobamos si nuestra palabra limpia existe como clave en el diccionario.
            if (diccionarioDePalabras.ContainsKey(palabraLimpia))
            {
                // Si la palabra existe, agregamos su traducción (el valor asociado a la clave) a nuestra frase final.
                fraseTraducida.Append(diccionarioDePalabras[palabraLimpia]);
            }
            else
            {
                // Si la palabra no se encuentra en el diccionario, simplemente agregamos la palabra original.
                fraseTraducida.Append(palabra);
            }

            // Agregamos un espacio después de cada palabra para separar la siguiente.
            fraseTraducida.Append(" ");
        }

        // Devolvemos la frase construida como una cadena de texto. Usamos Trim() para eliminar el último espacio sobrante.
        return fraseTraducida.ToString().Trim();
    }

   
    /// Este método permite añadir un nuevo par de palabras (español-inglés) al diccionario.
    
    /// <param name="palabraEnEspañol">La palabra en español que funcionará como clave.</param>
    /// <param name="palabraEnIngles">La traducción en inglés que funcionará como valor.</param>
    public void AgregarNuevaPalabra(string palabraEnEspañol, string palabraEnIngles)
    {
        // Antes de agregar, nos aseguramos de que la palabra no exista ya en el diccionario para evitar errores.
        // Convertimos a minúsculas para mantener consistencia en el diccionario.
        string clave = palabraEnEspañol.ToLower();
        string valor = palabraEnIngles.ToLower();

        if (!diccionarioDePalabras.ContainsKey(clave))
        {
            // Si no existe, la agregamos.
            diccionarioDePalabras.Add(clave, valor);
            System.Console.WriteLine("¡Palabra agregada con éxito!");
        }
        else
        {
            // Si ya existe, informamos al usuario.
            System.Console.WriteLine("Esta palabra ya se encuentra en el diccionario.");
        }
    }
}