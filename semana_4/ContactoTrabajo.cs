// Esta clase hereda de Contacto para modelar específicamente
// a los contactos de trabajo, es decir, aquellos asociados
// a tu vida laboral.
// Al ser un record, mantiene inmutabilidad y comparaciones por valor.
public record ContactoTrabajo : Contacto
{
    // Propiedad extra que solo aplica a contactos de trabajo:
    // almacena el nombre de la empresa donde trabaja la persona.
    public string Empresa { get; set; }

    // Constructor que recibe:
    //  - nombre, teléfono y correo (para pasárselos al record base)
    //  - empresa (valor extra para esta subclase)
    // Con la sintaxis ": base(...)" llamamos al constructor de Contacto.
    public ContactoTrabajo(
        string nombre,
        string telefono,
        string correo,
        string empresa)
        : base(nombre, telefono, correo)
    {
        // Aquí asignamos la empresa al campo correspondiente.
        Empresa = empresa;
    }

    // Sobrescribimos ToString() para incluir también
    // la información de la empresa cuando imprimimos el contacto.
    // Llamamos a base.ToString() para obtener:
    //   "ContactoTrabajo: Nombre | Teléfono | Correo"
    // y luego le añadimos "| Empresa: NombreEmpresa".
    public override string ToString()
        => base.ToString() + $" | Empresa: {Empresa}";
}
