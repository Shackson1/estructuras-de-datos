// Esta estructura (struct) define las categorías posibles
// para clasificar contactos en la agenda: Random, Familia o Trabajo.
public struct Categoria
{
    // Id numérico que identifica la categoría:
    // 0 = Random, 1 = Familia, 2 = Trabajo
    public int Id { get; }

    // Nombre legible de la categoría, p. ej. "Random", "Familia", "Trabajo"
    public string Nombre { get; }

    // Constructor que inicializa ambos campos (Id y Nombre)
    public Categoria(int id, string nombre)
    {
        // Asignamos el identificador
        Id     = id;
        // Asignamos el nombre descriptivo
        Nombre = nombre;
    }

    // Sobrescribimos ToString() para que al imprimir una Categoria
    // solo muestre su Nombre, sin 'Categoria: ' ni el Id.
    public override string ToString() => Nombre;
}
