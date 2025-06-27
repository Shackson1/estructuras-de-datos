// Esta clase representa a un estudiante que tiene una lista de asignaturas.
// También contiene los métodos para trabajar con esas asignaturas:
public class Estudiante
{
    // Lista de todas las asignaturas que cursa el estudiante
    public List<Asignatura> Asignaturas { get; set; }

    // Constructor: se ejecuta automáticamente al crear un estudiante.
    // Inicializa la lista con 5 asignaturas predefinidas.
    public Estudiante()
    {
        Asignaturas = new List<Asignatura>
        {
            new Asignatura("Matemáticas"),
            new Asignatura("Física"),
            new Asignatura("Química"),
            new Asignatura("Historia"),
            new Asignatura("Lengua")
        };
    }

    // Este método recorre todas las asignaturas y pide al usuario ingresar
    // la nota correspondiente para cada una.
    public void IngresarNotas()
    {
        foreach (var asignatura in Asignaturas)
        {
            // Muestra una pregunta en consola
            Console.Write($"¿Qué nota sacaste en {asignatura.Nombre}? ");

            // Lee lo que el usuario escribe en la consola
            string entrada = Console.ReadLine();
            double nota;

            // Verifica que el valor ingresado sea un número válido entre 0 y 10
            while (!double.TryParse(entrada, out nota) || nota < 0 || nota > 10)
            {
                Console.Write("Por favor, introduce una nota válida entre 0 y 10: ");
                entrada = Console.ReadLine();
            }

            // Si la entrada es válida, se guarda la nota en la asignatura
            asignatura.Nota = nota;
        }
    }

    // Este método genera una nueva lista que contiene solo las asignaturas reprobadas
    public List<Asignatura> ObtenerReprobadas()
    {
        // Lista vacía para almacenar asignaturas con nota < 7
        List<Asignatura> reprobadas = new List<Asignatura>();

        // Recorre todas las asignaturas del estudiante
        foreach (var asignatura in Asignaturas)
        {
            // Si no está aprobada (usamos el método de la clase Asignatura), la agregamos
            if (!asignatura.EstaAprobada())
            {
                reprobadas.Add(asignatura);
            }
        }

        return reprobadas; // Devuelve la lista de materias a repetir
    }

    // Este método muestra en pantalla las asignaturas reprobadas
    public void MostrarReprobadas()
    {
        // Obtenemos las asignaturas reprobadas usando el método anterior
        var reprobadas = ObtenerReprobadas();

        Console.WriteLine("\nDebes repetir las siguientes asignaturas:");

        // Si la lista está vacía, significa que el estudiante aprobó todo
        if (reprobadas.Count == 0)
        {
            Console.WriteLine("¡Felicidades! Has aprobado todas las asignaturas.");
        }
        else
        {
            // Si hay materias a repetir, las listamos con su nombre y nota
            foreach (var asignatura in reprobadas)
            {
                Console.WriteLine($"- {asignatura.Nombre} (Nota: {asignatura.Nota})");
            }
        }
    }
}
