
// Usaremos esta plantilla para crear un objeto cada vez que un libro sale o regresa a la biblioteca.
// Guarda toda la información sobre quién se llevó el libro, el día en que lo hizo y el día en que lo devolvió.

using System; // Necesitamos esto para poder usar el tipo de dato DateTime para las fechas.

public class Prestamo
{
    // Aquí guardamos el objeto "Libro" completo que se prestó.
    // De esta forma, tenemos acceso a toda la información del libro (su Id, su nombre, etc.).
    public Libro LibroPrestado { get; set; }

    // En esta propiedad guardamos el nombre de la persona que solicitó el libro.
    public string NombrePersona { get; set; }

    // Aquí registramos el día en que se realizó el préstamo.
    public DateTime FechaPrestamo { get; set; }

    // Esta propiedad guardará el día de la devolución.
    // El signo de interrogación (?) significa que este valor puede ser nulo (puede estar vacío).
    // Estará vacío mientras el libro no haya sido devuelto.
    public DateTime? FechaDevolucion { get; set; }

    // Aquí guardaremos la condición en la que se devolvió el libro, por ejemplo "Buen estado" o "Mal estado".
    public string EstadoLibroDevuelto { get; set; }
}