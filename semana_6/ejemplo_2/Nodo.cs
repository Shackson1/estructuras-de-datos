
// Representa un nodo de lista enlazada que almacena un número real

public class Nodo
{
    public double Dato { get; set; }           // Valor almacenado en el nodo
    public Nodo? Siguiente { get; set; }       // Referencia al siguiente nodo

    public Nodo(double dato)
    {
        Dato = dato;
        Siguiente = null; // Por defecto, el nodo no apunta a ningún otro
    }
}
