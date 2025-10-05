// Clase que representa una ciudad en el sistema de vuelos
// Esta clase almacena la información básica de cada destino
public class Ciudad
{
    // Propiedad que almacena el nombre de la ciudad
    public string NombreCiudad { get; set; }

    // Constructor que inicializa una nueva ciudad con su nombre
    // Parámetro: nombreCiudad - El nombre de la ciudad a crear
    public Ciudad(string nombreCiudad)
    {
        NombreCiudad = nombreCiudad;
    }

    // Método que devuelve la representación en texto de la ciudad
    // Esto permite mostrar el nombre de la ciudad de forma simple
    public override string ToString()
    {
        return NombreCiudad;
    }
}
