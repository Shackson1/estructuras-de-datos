using System;

// Clase que administra el menú de operaciones del sistema de estacionamiento
public class Menu
{
    // Lista enlazada que contiene los vehículos registrados
    private ListaVehiculos lista;

    // Constructor que inicializa la lista de vehículos (con tres predefinidos)
    public Menu()
    {
        lista = new ListaVehiculos();
    }

    // Método principal que muestra el menú de opciones al usuario
    public void Mostrar()
    {
        int opcion; // Variable para almacenar la opción seleccionada por el usuario

        // Ciclo do-while que mantiene el menú activo hasta que el usuario decida salir
        do
        {
            // Muestra el menú en consola
            Console.WriteLine("\n Estacionamiento área de tecnologías");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar vehículo por placa");
            Console.WriteLine("3. Ver vehículos por año");
            Console.WriteLine("4. Ver todos los vehículos registrados");
            Console.WriteLine("5. Eliminar vehículo registrado");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            // Lee la opción del usuario desde consola y la convierte a entero
            opcion = int.Parse(Console.ReadLine()!);

            // Ejecuta la opción seleccionada por el usuario usando una estructura switch
            switch (opcion)
            {
                case 1:
                    AgregarVehiculo(); // Llama al método para agregar un nuevo vehículo
                    break;
                case 2:
                    BuscarVehiculo(); // Llama al método para buscar un vehículo por placa
                    break;
                case 3:
                    VerPorAño(); // Llama al método para mostrar vehículos por año
                    break;
                case 4:
                    lista.VerTodosLosVehiculos(); // Muestra todos los vehículos registrados
                    break;
                case 5:
                    EliminarVehiculo(); // Elimina un vehículo por placa
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa..."); // Mensaje de salida
                    break;
                default:
                    Console.WriteLine("Opción inválida."); // Mensaje para opción incorrecta
                    break;
            }

        } while (opcion != 0); // Repite el menú mientras no se elija salir
    }

    // Método privado para agregar un vehículo nuevo a la lista
    private void AgregarVehiculo()
    {
        // Solicita al usuario ingresar los datos del vehículo
        Console.Write("Placa: ");
        string placa = Console.ReadLine()!;
        Console.Write("Marca: ");
        string marca = Console.ReadLine()!;
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine()!;
        Console.Write("Año: ");
        int año = int.Parse(Console.ReadLine()!);
        Console.Write("Precio: ");
        double precio = double.Parse(Console.ReadLine()!);

        // Agrega el vehículo a la lista enlazada
        lista.AgregarVehiculo(placa, marca, modelo, año, precio);

        Console.WriteLine("Vehículo agregado correctamente.");
    }

    // Método privado para buscar un vehículo por su número de placa
    private void BuscarVehiculo()
    {
        Console.Write("Ingrese la placa del vehículo a buscar: ");
        string placa = Console.ReadLine()!;

        // Llama al método de búsqueda en la lista enlazada
        Vehiculo? vehiculo = lista.BuscarPorPlaca(placa);

        // Si se encuentra el vehículo, se muestran sus datos
        if (vehiculo != null)
            Console.WriteLine($"Vehículo encontrado: Placa: {vehiculo.Placa}, Marca: {vehiculo.Marca}, Modelo: {vehiculo.Modelo}, Año: {vehiculo.Año}, Precio: ${vehiculo.Precio}");
        else
            Console.WriteLine("Vehículo no encontrado."); // Si no se encuentra, se informa
    }

    // Método privado para mostrar todos los vehículos registrados de un año específico
    private void VerPorAño()
    {
        Console.Write("Ingrese el año: ");
        int año = int.Parse(Console.ReadLine()!);

        // Llama al método que muestra los vehículos según el año
        lista.VerVehiculosPorAño(año);
    }

    // Método privado para eliminar un vehículo del registro por su placa
    private void EliminarVehiculo()
    {
        Console.Write("Ingrese la placa del vehículo a eliminar: ");
        string placa = Console.ReadLine()!;

        // Llama al método que elimina el vehículo en la lista
        lista.EliminarVehiculo(placa);
    }
}
