// Este record define el modelo base para todos los contactos.
// Es inmutable, lo que significa que una vez creado no se pueden cambiar
// sus propiedades (Nombre, Teléfono, Correo).
// Al declararlo como abstract record, permitimos que otras clases
// (o records) hereden de él y añadan campos o comportamientos.
public abstract record Contacto(string Nombre, string Telefono, string Correo);
