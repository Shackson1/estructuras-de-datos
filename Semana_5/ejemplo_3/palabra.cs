public class Palabra
{
    // Propiedad que almacena la palabra original
    public string Texto { get; set; }

    // Constructor: recibe la palabra al crear el objeto
    public Palabra(string texto)
    {
        // Normalizamos la palabra a minúsculas
        Texto = texto.ToLower();
    }

    // Método que devuelve true si la palabra es un palíndromo
    public bool EsPalindromo()
    {
        // Convertimos la palabra a arreglo de caracteres y lo invertimos
        char[] caracteres = Texto.ToCharArray();
        Array.Reverse(caracteres);

        // Reconstruimos la palabra invertida
        string invertida = new string(caracteres);

        // Comparamos la palabra original con la invertida
        return Texto == invertida;
    }
}
