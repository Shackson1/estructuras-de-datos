public class Curso
{
    // Lista de asignaturas del curso
    public List<Asignatura> Asignaturas { get; set; }

    // Constructor que inicializa las asignaturas predefinidas
    public Curso()
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

    // Método para mostrar todas las asignaturas por pantalla
    public void MostrarAsignaturas()
    {
        Console.WriteLine("Asignaturas del curso:");

        foreach (var asignatura in Asignaturas)
        {
            Console.WriteLine($"- {asignatura.Nombre}");
        }
    }
}
