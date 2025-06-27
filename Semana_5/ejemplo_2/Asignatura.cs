// Esta clase representa una materia (asignatura) que tiene:
// - un nombre (por ejemplo: Matemáticas)
// - una nota numérica asociada

public class Asignatura
{
    // Propiedad pública que almacena el nombre de la asignatura
    public string Nombre { get; set; }

    // Propiedad pública que almacena la nota del estudiante en esa asignatura
    public double Nota { get; set; }

    // Constructor: se llama cuando se crea una nueva asignatura.
    // Inicializa el nombre y pone la nota en 0.
    public Asignatura(string nombre)
    {
        Nombre = nombre;
        Nota = 0;
    }

    // Método que devuelve true si la nota es mayor o igual a 7.
    // Esto nos indica si la materia está aprobada.
    public bool EstaAprobada()
    {
        return Nota >= 7.0;
    }
}
