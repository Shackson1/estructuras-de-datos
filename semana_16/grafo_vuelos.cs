// Clase principal que representa el grafo de vuelos
// Implementa un grafo dirigido ponderado usando lista de adyacencia
public class GrafoVuelos
{
    // Diccionario que almacena la lista de adyacencia del grafo
    // Cada ciudad tiene una lista de conexiones de vuelo disponibles
    private Dictionary<string, List<ConexionVuelo>> listaAdyacencia;

    // Constructor que inicializa el grafo vacío
    public GrafoVuelos()
    {
        // Inicializamos el diccionario para almacenar las conexiones
        listaAdyacencia = new Dictionary<string, List<ConexionVuelo>>();
    }

    // Método para agregar una ciudad al grafo de forma silenciosa
    // Parámetro: nombreCiudad - El nombre de la ciudad a agregar
    public void AgregarCiudad(string nombreCiudad)
    {
        // Verificamos si la ciudad ya existe en el grafo
        if (!listaAdyacencia.ContainsKey(nombreCiudad))
        {
            // Si no existe, creamos una nueva lista vacía de conexiones
            listaAdyacencia[nombreCiudad] = new List<ConexionVuelo>();
        }
    }

    // Método para agregar una conexión de vuelo entre dos ciudades de forma silenciosa
    // Parámetro: ciudadOrigen - La ciudad desde donde sale el vuelo
    // Parámetro: ciudadDestino - La ciudad donde llega el vuelo
    // Parámetro: precio - El costo del vuelo
    public void AgregarVuelo(string ciudadOrigen, string ciudadDestino, decimal precio)
    {
        // Verificamos que ambas ciudades existan en el sistema
        if (!listaAdyacencia.ContainsKey(ciudadOrigen) || !listaAdyacencia.ContainsKey(ciudadDestino))
        {
            return; // Salimos silenciosamente si hay error
        }

        // Creamos la nueva conexión de vuelo
        ConexionVuelo nuevaConexion = new ConexionVuelo(ciudadDestino, precio);

        // Agregamos la conexión a la lista de la ciudad origen
        listaAdyacencia[ciudadOrigen].Add(nuevaConexion);
    }

    // Método para obtener la lista de ciudades disponibles en el sistema
    // Retorna: Lista de strings con los nombres de todas las ciudades
    public List<string> ObtenerListaCiudades()
    {
        return listaAdyacencia.Keys.ToList();
    }

    // Método para mostrar solo los vuelos directos desde una ciudad específica
    // Parámetro: ciudadOrigen - La ciudad desde la cual mostrar los vuelos
    public void MostrarVuelosDesde(string ciudadOrigen)
    {
        // Verificamos que la ciudad exista
        if (!listaAdyacencia.ContainsKey(ciudadOrigen))
        {
            Console.WriteLine("Error: La ciudad " + ciudadOrigen + " no existe en el sistema");
            return;
        }

        // Obtenemos la lista de vuelos desde esta ciudad
        List<ConexionVuelo> vuelosDisponibles = listaAdyacencia[ciudadOrigen];

        Console.WriteLine("VUELOS DIRECTOS:");
        if (vuelosDisponibles.Count == 0)
        {
            Console.WriteLine("   No hay vuelos directos disponibles desde " + ciudadOrigen);
        }
        else
        {
            foreach (var vuelo in vuelosDisponibles.OrderBy(v => v.PrecioVuelo))
            {
                Console.WriteLine("   " + ciudadOrigen + " -> " + vuelo.CiudadDestino + ": $" + vuelo.PrecioVuelo);
            }
        }
    }

    // Método para mostrar todos los destinos alcanzables con escalas desde una ciudad
    // Parámetro: ciudadOrigen - La ciudad desde la cual calcular destinos
    public void MostrarDestinosConEscalas(string ciudadOrigen)
    {
        // Verificamos que la ciudad exista
        if (!listaAdyacencia.ContainsKey(ciudadOrigen))
        {
            Console.WriteLine("Error: La ciudad " + ciudadOrigen + " no existe en el sistema");
            return;
        }

        // Obtenemos todas las ciudades del sistema
        var todasLasCiudades = listaAdyacencia.Keys.ToList();

        // Obtenemos los destinos directos para excluirlos de la lista de escalas
        var destinosDirectos = new HashSet<string>();
        foreach (var vuelo in listaAdyacencia[ciudadOrigen])
        {
            destinosDirectos.Add(vuelo.CiudadDestino);
        }

        // Lista para almacenar destinos con escalas
        var destinosConEscalas = new List<(string destino, decimal precio, List<string> ruta)>();

        // Calculamos rutas para cada ciudad destino posible
        foreach (string destino in todasLasCiudades)
        {
            // Saltamos la misma ciudad origen y los destinos directos
            if (destino == ciudadOrigen || destinosDirectos.Contains(destino))
                continue;

            // Calculamos la ruta más barata usando Dijkstra
            var ruta = CalcularRutaMasBarata(ciudadOrigen, destino);

            if (ruta.Count > 2) // Solo si hay escalas (más de 2 ciudades en la ruta)
            {
                decimal precioTotal = CalcularPrecioRuta(ruta);
                destinosConEscalas.Add((destino, precioTotal, ruta));
            }
        }

        // Mostramos los resultados ordenados por precio
        if (destinosConEscalas.Count == 0)
        {
            Console.WriteLine("   Todas las ciudades tienen vuelos directos disponibles");
        }
        else
        {
            destinosConEscalas.Sort((x, y) => x.precio.CompareTo(y.precio));

            foreach (var (destino, precio, ruta) in destinosConEscalas)
            {
                int escalas = ruta.Count - 2;
                string rutaTexto = string.Join(" -> ", ruta);
                string textoEscalas = escalas > 1 ? "escalas" : "escala";
                Console.WriteLine("   " + destino + ": $" + precio + " (" + escalas + " " + textoEscalas + ")");
                Console.WriteLine("      Ruta: " + rutaTexto);
            }
        }
    }

    // Método auxiliar para calcular la ruta más barata entre dos ciudades
    // Parámetro: origen - Ciudad de inicio
    // Parámetro: destino - Ciudad de llegada
    // Retorna: Lista de ciudades que forman el camino más barato
    private List<string> CalcularRutaMasBarata(string origen, string destino)
    {
        // Diccionario para almacenar las distancias mínimas (precios) desde el origen
        Dictionary<string, decimal> distancias = new Dictionary<string, decimal>();

        // Diccionario para almacenar el nodo anterior en el camino más corto
        Dictionary<string, string> nodosAnteriores = new Dictionary<string, string>();

        // Conjunto de nodos ya visitados
        HashSet<string> visitados = new HashSet<string>();

        // Lista de nodos por visitar, ordenada por distancia
        var colaPrioridad = new SortedSet<(decimal precio, string ciudad)>();

        // Inicializamos todas las distancias como infinito
        foreach (string ciudad in listaAdyacencia.Keys)
        {
            distancias[ciudad] = decimal.MaxValue;
            nodosAnteriores[ciudad] = null;
        }

        // La distancia a la ciudad origen es 0
        distancias[origen] = 0;
        colaPrioridad.Add((0, origen));

        // Algoritmo principal de Dijkstra
        while (colaPrioridad.Count > 0)
        {
            // Tomamos el nodo con menor distancia
            var nodoActual = colaPrioridad.Min;
            colaPrioridad.Remove(nodoActual);

            string ciudadActual = nodoActual.ciudad;
            decimal precioActual = nodoActual.precio;

            // Si ya visitamos este nodo, continuamos
            if (visitados.Contains(ciudadActual))
                continue;

            // Marcamos el nodo como visitado
            visitados.Add(ciudadActual);

            // Si llegamos al destino, terminamos
            if (ciudadActual == destino)
                break;

            // Examinamos todos los vecinos del nodo actual
            foreach (ConexionVuelo conexion in listaAdyacencia[ciudadActual])
            {
                string vecino = conexion.CiudadDestino;
                decimal nuevaDistancia = precioActual + conexion.PrecioVuelo;

                // Si encontramos un camino más barato, lo actualizamos
                if (nuevaDistancia < distancias[vecino])
                {
                    distancias[vecino] = nuevaDistancia;
                    nodosAnteriores[vecino] = ciudadActual;
                    colaPrioridad.Add((nuevaDistancia, vecino));
                }
            }
        }

        // Reconstruimos el camino desde el destino hasta el origen
        return ReconstruirCamino(origen, destino, nodosAnteriores, distancias);
    }

    // Método auxiliar para calcular el precio total de una ruta
    // Parámetro: ruta - Lista de ciudades que forman el camino
    // Retorna: Precio total del viaje
    private decimal CalcularPrecioRuta(List<string> ruta)
    {
        decimal precioTotal = 0;

        for (int i = 0; i < ruta.Count - 1; i++)
        {
            string ciudadActual = ruta[i];
            string ciudadSiguiente = ruta[i + 1];

            // Buscamos el precio del tramo específico
            foreach (var vuelo in listaAdyacencia[ciudadActual])
            {
                if (vuelo.CiudadDestino == ciudadSiguiente)
                {
                    precioTotal += vuelo.PrecioVuelo;
                    break;
                }
            }
        }

        return precioTotal;
    }

    // Método que implementa el algoritmo de Dijkstra para encontrar el vuelo más barato
    // Parámetro: ciudadOrigen - La ciudad desde donde queremos viajar
    // Parámetro: ciudadDestino - La ciudad a donde queremos llegar
    // Retorna: Lista de ciudades que forman el camino más barato
    public List<string> EncontrarVueloMasBarato(string ciudadOrigen, string ciudadDestino)
    {
        // Verificamos que ambas ciudades existan
        if (!listaAdyacencia.ContainsKey(ciudadOrigen) || !listaAdyacencia.ContainsKey(ciudadDestino))
        {
            Console.WriteLine("   Error: Una o ambas ciudades no existen en el sistema");
            return new List<string>();
        }

        return CalcularRutaMasBarata(ciudadOrigen, ciudadDestino);
    }

    // Método auxiliar para reconstruir el camino más barato
    // Parámetro: origen - Ciudad de inicio
    // Parámetro: destino - Ciudad de llegada
    // Parámetro: anteriores - Diccionario con los nodos anteriores
    // Parámetro: distancias - Diccionario con las distancias mínimas
    // Retorna: Lista de ciudades que forman el camino
    private List<string> ReconstruirCamino(string origen, string destino, 
        Dictionary<string, string> anteriores, Dictionary<string, decimal> distancias)
    {
        List<string> camino = new List<string>();

        // Si no hay camino al destino
        if (distancias[destino] == decimal.MaxValue)
        {
            return camino;
        }

        // Reconstruimos el camino desde el destino hacia el origen
        string ciudadActual = destino;
        while (ciudadActual != null)
        {
            camino.Add(ciudadActual);
            ciudadActual = anteriores[ciudadActual];
        }

        // Invertimos el camino para que vaya del origen al destino
        camino.Reverse();

        return camino;
    }

    // Método para mostrar las ciudades disponibles con numeración
    public void MostrarCiudadesDisponibles()
    {
        Console.WriteLine("CIUDADES DISPONIBLES:");

        var ciudades = listaAdyacencia.Keys.OrderBy(c => c).ToList();

        for (int i = 0; i < ciudades.Count; i++)
        {
            Console.WriteLine("   " + (i + 1) + ". " + ciudades[i]);
        }
    }

    // Método para mostrar todas las conexiones del grafo (para uso interno o depuración)
    public void MostrarTodasLasConexiones()
    {
        Console.WriteLine("\nTODAS LAS CONEXIONES DE VUELO");

        foreach (var ciudad in listaAdyacencia)
        {
            Console.WriteLine("\nDesde " + ciudad.Key + ":");

            if (ciudad.Value.Count == 0)
            {
                Console.WriteLine("  No hay vuelos disponibles");
            }
            else
            {
                foreach (var vuelo in ciudad.Value)
                {
                    Console.WriteLine("  -> " + vuelo);
                }
            }
        }
    }
}
