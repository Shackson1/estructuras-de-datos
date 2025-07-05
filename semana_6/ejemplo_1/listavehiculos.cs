using System;

// Clase que representa una lista enlazada para almacenar vehículos
public class ListaVehiculos
{
    // Nodo inicial de la lista enlazada (referencia al primer vehículo)
    private Vehiculo? head;

    // Constructor: inicializa la lista con tres vehículos predefinidos
    public ListaVehiculos()
    {
        head = null;

        // Agrega 3 vehículos de ejemplo al crear la lista
        AgregarVehiculo("ABC123", "Toyota", "Corolla", 2020, 15000);
        AgregarVehiculo("XYZ789", "Hyundai", "Elantra", 2022, 18000);
        AgregarVehiculo("LMN456", "Kia", "Sportage", 2019, 20000);
    }

    // Método público para agregar un nuevo vehículo a la lista (al inicio)
    public void AgregarVehiculo(string placa, string marca, string modelo, int año, double precio)
    {
        // Crea un nuevo nodo con los datos del vehículo
        Vehiculo nuevo = new Vehiculo(placa, marca, modelo, año, precio);

        // El nuevo nodo apunta al nodo actual (head)
        nuevo.Siguiente = head;

        // El nuevo nodo se convierte en el nuevo head de la lista
        head = nuevo;
    }

    // Método que permite buscar un vehículo en la lista por su placa
    public Vehiculo? BuscarPorPlaca(string placa)
    {
        Vehiculo? actual = head;

        // Recorre la lista nodo por nodo
        while (actual != null)
        {
            // Compara la placa del nodo actual con la placa buscada (ignorando mayúsculas/minúsculas)
            if (actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                return actual; // Vehículo encontrado

            // Avanza al siguiente nodo
            actual = actual.Siguiente;
        }

        // Si no se encontró ningún nodo con la placa buscada
        return null;
    }

    // Muestra todos los vehículos que coincidan con un año específico
    public void VerVehiculosPorAño(int año)
    {
        Vehiculo? actual = head;
        bool encontrado = false; // Bandera para saber si hubo coincidencias

        while (actual != null)
        {
            if (actual.Año == año)
            {
                MostrarVehiculo(actual); // Muestra el vehículo si coincide el año
                encontrado = true;
            }
            actual = actual.Siguiente;
        }

        if (!encontrado)
            Console.WriteLine("No se encontraron vehículos del año " + año);
    }

    // Muestra todos los vehículos registrados en la lista
    public void VerTodosLosVehiculos()
    {
        Vehiculo? actual = head;

        // Si la lista está vacía, se notifica
        if (actual == null)
        {
            Console.WriteLine("No hay vehículos registrados.");
            return;
        }

        // Recorre y muestra cada vehículo
        while (actual != null)
        {
            MostrarVehiculo(actual);
            actual = actual.Siguiente;
        }
    }

    // Elimina un vehículo de la lista según su placa
    public void EliminarVehiculo(string placa)
    {
        Vehiculo? actual = head;      // Nodo actual
        Vehiculo? anterior = null;    // Nodo anterior (para mantener referencia en caso de eliminación)

        while (actual != null)
        {
            // Si se encuentra el vehículo con la placa buscada
            if (actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                if (anterior == null)
                    head = actual.Siguiente; // Si es el primer nodo, se cambia el head
                else
                    anterior.Siguiente = actual.Siguiente; // Se salta el nodo actual

                Console.WriteLine($"Vehículo con placa {placa} eliminado.");
                return; // Salida después de eliminar
            }

            // Avanza al siguiente nodo
            anterior = actual;
            actual = actual.Siguiente;
        }

        // Si se recorrió toda la lista sin encontrar el vehículo
        Console.WriteLine("Vehículo no encontrado.");
    }

    // Método auxiliar privado para imprimir los datos de un vehículo
    private void MostrarVehiculo(Vehiculo veh)
    {
        Console.WriteLine($"Placa: {veh.Placa}, Marca: {veh.Marca}, Modelo: {veh.Modelo}, Año: {veh.Año}, Precio: ${veh.Precio}");
    }
}
