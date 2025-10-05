// Clase principal del programa que contiene el método Main
class Program
{
    // Método principal que inicia la ejecución del programa
    static void Main(string[] args)
    {
        Console.WriteLine("SISTEMA DE BUSQUEDA DE VUELOS BARATOS");
        Console.WriteLine("Implementacion usando Grafos - Ciudades de Ecuador\n");

        // Creamos una nueva instancia del grafo de vuelos
        GrafoVuelos sistemaVuelos = new GrafoVuelos();

        // Cargamos silenciosamente los datos de prueba
        CargarDatosDePrueba(sistemaVuelos);

        // Iniciamos la interfaz interactiva del usuario
        InterfazUsuario(sistemaVuelos);

        Console.WriteLine("\nGRACIAS POR USAR EL SISTEMA");
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }

    // Método que maneja la interacción con el usuario
    static void InterfazUsuario(GrafoVuelos sistema)
    {
        while (true)
        {
            // Mostramos las ciudades disponibles con números
            sistema.MostrarCiudadesDisponibles();

            // Solicitamos el número de la ciudad de partida
            Console.WriteLine("\nIngrese el NUMERO de su ciudad de PARTIDA (o 0 para salir):");
            string entrada = Console.ReadLine().Trim();

            // Intentamos convertir la entrada a número
            if (!int.TryParse(entrada, out int numeroCiudad))
            {
                Console.WriteLine("\nError: Por favor ingrese un numero valido.\n");
                continue;
            }

            // Verificamos si el usuario quiere salir
            if (numeroCiudad == 0)
            {
                break;
            }

            // Obtenemos el nombre de la ciudad basado en el número
            string ciudadSeleccionada = ObtenerCiudadPorNumero(sistema, numeroCiudad);

            if (ciudadSeleccionada == null)
            {
                Console.WriteLine("\nError: El numero ingresado no corresponde a ninguna ciudad.\n");
                continue;
            }

            // Mostramos todas las conexiones disponibles desde la ciudad seleccionada
            MostrarConexionesDesde(sistema, ciudadSeleccionada);

            // Preguntamos si quiere consultar otra ciudad
            Console.WriteLine("\nDesea consultar otra ciudad? (s/n):");
            string respuesta = Console.ReadLine().Trim().ToLower();

            if (respuesta != "s" && respuesta != "si")
            {
                break;
            }

            Console.WriteLine();
        }
    }

    // Método para obtener el nombre de la ciudad basado en el número seleccionado
    static string ObtenerCiudadPorNumero(GrafoVuelos sistema, int numero)
    {
        var ciudades = sistema.ObtenerListaCiudades();

        // Verificamos que el número esté en el rango válido
        if (numero < 1 || numero > ciudades.Count)
        {
            return null;
        }

        // Ordenamos las ciudades para mantener consistencia
        ciudades.Sort();

        // Devolvemos la ciudad correspondiente (restamos 1 porque los arrays empiezan en 0)
        return ciudades[numero - 1];
    }

    // Método que muestra todas las conexiones disponibles desde una ciudad específica
    static void MostrarConexionesDesde(GrafoVuelos sistema, string ciudadOrigen)
    {
        Console.WriteLine();
        Console.WriteLine("VUELOS DISPONIBLES DESDE " + ciudadOrigen.ToUpper());
        Console.WriteLine();

        // Mostramos todas las conexiones directas disponibles desde la ciudad
        sistema.MostrarVuelosDesde(ciudadOrigen);

        // Adicionalmente, mostramos información sobre destinos con escalas
        Console.WriteLine("\nDESTINOS CON POSIBLES ESCALAS:");
        sistema.MostrarDestinosConEscalas(ciudadOrigen);
    }

    // Método que carga datos de prueba con ciudades ecuatorianas y sus conexiones
    // Este método ahora trabaja silenciosamente sin mostrar mensajes al usuario
    static void CargarDatosDePrueba(GrafoVuelos sistema)
    {
        // Agregamos las principales ciudades de Ecuador al sistema
        sistema.AgregarCiudad("Quito");           // Capital del país
        sistema.AgregarCiudad("Guayaquil");       // Ciudad más poblada
        sistema.AgregarCiudad("Cuenca");          // Capital cultural
        sistema.AgregarCiudad("Manta");           // Puerto principal
        sistema.AgregarCiudad("Loja");            // Sur del país
        sistema.AgregarCiudad("Ambato");          // Centro del país
        sistema.AgregarCiudad("Machala");         // Capital bananera
        sistema.AgregarCiudad("Esmeraldas");      // Costa norte

        // Agregamos las conexiones de vuelo con precios
        // Desde Quito (capital) a otras ciudades principales
        sistema.AgregarVuelo("Quito", "Guayaquil", 120.50m);
        sistema.AgregarVuelo("Quito", "Cuenca", 95.75m);
        sistema.AgregarVuelo("Quito", "Manta", 110.00m);
        sistema.AgregarVuelo("Quito", "Loja", 140.25m);
        sistema.AgregarVuelo("Quito", "Esmeraldas", 85.50m);

        // Desde Guayaquil a otras ciudades
        sistema.AgregarVuelo("Guayaquil", "Quito", 125.00m);
        sistema.AgregarVuelo("Guayaquil", "Cuenca", 89.90m);
        sistema.AgregarVuelo("Guayaquil", "Manta", 75.25m);
        sistema.AgregarVuelo("Guayaquil", "Machala", 65.00m);
        sistema.AgregarVuelo("Guayaquil", "Loja", 115.50m);

        // Desde Cuenca a otras ciudades
        sistema.AgregarVuelo("Cuenca", "Quito", 98.75m);
        sistema.AgregarVuelo("Cuenca", "Guayaquil", 92.00m);
        sistema.AgregarVuelo("Cuenca", "Loja", 55.25m);
        sistema.AgregarVuelo("Cuenca", "Machala", 78.50m);

        // Desde Manta a otras ciudades
        sistema.AgregarVuelo("Manta", "Quito", 108.00m);
        sistema.AgregarVuelo("Manta", "Guayaquil", 72.75m);
        sistema.AgregarVuelo("Manta", "Esmeraldas", 95.00m);

        // Desde Loja a otras ciudades
        sistema.AgregarVuelo("Loja", "Cuenca", 52.50m);
        sistema.AgregarVuelo("Loja", "Guayaquil", 118.25m);
        sistema.AgregarVuelo("Loja", "Machala", 89.75m);

        // Desde Ambato a otras ciudades
        sistema.AgregarVuelo("Ambato", "Quito", 45.50m);
        sistema.AgregarVuelo("Ambato", "Guayaquil", 105.00m);
        sistema.AgregarVuelo("Ambato", "Cuenca", 75.25m);

        // Desde Machala a otras ciudades
        sistema.AgregarVuelo("Machala", "Guayaquil", 62.50m);
        sistema.AgregarVuelo("Machala", "Loja", 87.00m);
        sistema.AgregarVuelo("Machala", "Cuenca", 82.25m);

        // Desde Esmeraldas a otras ciudades
        sistema.AgregarVuelo("Esmeraldas", "Quito", 88.75m);
        sistema.AgregarVuelo("Esmeraldas", "Manta", 92.50m);

        // Agregamos algunas conexiones indirectas para demostrar el algoritmo
        sistema.AgregarVuelo("Quito", "Ambato", 42.00m);
        sistema.AgregarVuelo("Ambato", "Machala", 135.50m);
    }
}
