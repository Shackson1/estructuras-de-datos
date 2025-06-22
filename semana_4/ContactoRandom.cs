// Esta clase define contactos “random” o genéricos,
// es decir, aquellos que no pertenecen a ninguna categoría especial.
// Al ser un record, hereda automáticamente igualdad por valor,
// ToString(), y demás comportamientos útiles.
public record ContactoRandom : Contacto
{
    // Constructor que recibe los datos básicos de un contacto:
    // - nombre
    // - teléfono
    // - correo
    // Luego los pasa al constructor de la clase base (Contacto)
    public ContactoRandom(string nombre, string telefono, string correo)
        : base(nombre, telefono, correo)
    {
        // No necesitamos inicializar nada más,
        // porque Contacto base ya almacena nombre, teléfono y correo.
    }
}
