// Clase que representa una conexión de vuelo entre dos ciudades
// Esta clase funciona como la arista del grafo que conecta dos vértices (ciudades)
public class ConexionVuelo
{
    // Propiedad que almacena la ciudad de destino del vuelo
    public string CiudadDestino { get; set; }

    // Propiedad que almacena el precio del vuelo en dólares
    public decimal PrecioVuelo { get; set; }

    // Constructor que crea una nueva conexión de vuelo
    // Parámetro: ciudadDestino - La ciudad a la que llega el vuelo
    // Parámetro: precioVuelo - El costo del vuelo en dólares
    public ConexionVuelo(string ciudadDestino, decimal precioVuelo)
    {
        CiudadDestino = ciudadDestino;
        PrecioVuelo = precioVuelo;
    }

    // Método que devuelve la información del vuelo en formato texto
    // Muestra el destino y el precio de forma legible
    public override string ToString()
    {
        return $"Destino: {CiudadDestino}, Precio: ${PrecioVuelo}";
    }
}

