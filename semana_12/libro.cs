
// Una clase es como un molde o una plantilla que usamos para crear "objetos".
// En este caso, cada objeto que creemos a partir de esta clase representará un libro de la biblioteca.

public class Libro
{
    // Esta es una "propiedad" para guardar el número de identificación único de cada libro.
    // Así, aunque tengamos dos libros con el mismo nombre, podemos distinguirlos.
    public int Id { get; set; }

    // Esta propiedad guarda el título o nombre del libro.
    public string Nombre { get; set; }

    // Esta propiedad nos ayuda a saber si el libro está disponible en la estantería o si alguien se lo ha llevado.
    // Es un valor booleano, lo que significa que solo puede ser 'verdadero' (true) o 'falso' (false).
    public bool EstaPrestado { get; set; }
}