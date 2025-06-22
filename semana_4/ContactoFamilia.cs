// Esta clase hereda de Contacto para modelar específicamente
// a los miembros de la familia. Es un record, así que mantiene
// inmutabilidad y comparaciones por valor, además de heredar
// Nombre, Teléfono y Correo.
public record ContactoFamilia : Contacto
{
    // Propiedad adicional que solo aplicará a contactos familiares:
    // indica la relación (por ejemplo, “Hermano”, “Madre”, “Tía”).
    public string Parentesco { get; set; }

    // Constructor que recibe:
    //  - nombre, teléfono y correo (para pasárselos al record base)
    //  - parentesco (solo para esta clase)
    public ContactoFamilia(
        string nombre,
        string telefono,
        string correo,
        string parentesco)
        : base(nombre, telefono, correo) // Llamada al constructor de Contacto
    {
        // Aquí inicializamos el Parentesco con el valor que nos pasan
        Parentesco = parentesco;
    }

    // Sobrescribimos ToString() para incluir también el parentesco
    // Al llamar base.ToString() obtenemos algo como:
    // "ContactoFamilia: Juan | 555-1234 | juan@ejemplo.com"
    // y luego agregamos " | Parentesco: Hermano"
    public override string ToString()
        => base.ToString() + $" | Parentesco: {Parentesco}";
}
