// Clase que representa un vehículo individual como un nodo de una lista enlazada
public class Vehiculo
{
    // Propiedad para la placa del vehículo (clave única)
    public string Placa { get; set; }

    // Propiedad para la marca del vehículo (ej. Toyota, Ford)
    public string Marca { get; set; }

    // Propiedad para el modelo del vehículo (ej. Corolla, Mustang)
    public string Modelo { get; set; }

    // Propiedad para el año de fabricación del vehículo
    public int Año { get; set; }

    // Propiedad para el precio del vehículo
    public double Precio { get; set; }

    // Propiedad que apunta al siguiente nodo (vehículo) en la lista enlazada
    public Vehiculo? Siguiente { get; set; }

    // Constructor que inicializa un nuevo objeto Vehiculo con sus datos
    public Vehiculo(string placa, string marca, string modelo, int año, double precio)
    {
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;

        // Inicialmente, el nodo no apunta a ningún otro (fin de la lista)
        Siguiente = null;
    }
}
