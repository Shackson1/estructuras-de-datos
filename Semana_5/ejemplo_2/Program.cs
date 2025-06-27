
// Esta clase contiene el método Main, que es el punto de inicio de cualquier programa en C#
class Program
{
    static void Main()
    {
        // Creamos un objeto de tipo Estudiante
        // Esto inicializa automáticamente su lista de asignaturas
        Estudiante estudiante = new Estudiante();

        // Llamamos al método para pedir las notas al usuario
        estudiante.IngresarNotas();

        // Llamamos al método que muestra las materias reprobadas
        estudiante.MostrarReprobadas();
    }
}
