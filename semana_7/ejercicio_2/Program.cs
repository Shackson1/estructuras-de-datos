
    // Clase que representa una torre (una pila de discos)
    public class Torre
    {
        public Stack<int> Discos { get; private set; }  // Pila de discos
        public string Nombre { get; private set; }       // Nombre identificador de la torre

        public Torre(string nombre)
        {
            Nombre = nombre;
            Discos = new Stack<int>();
        }

        // Método para mover un disco a otra torre y mostrar el movimiento
        public void MoverDiscoA(Torre destino)
        {
            int disco = Discos.Pop(); // Sacar disco superior de esta torre
            destino.Discos.Push(disco); // Colocar disco en la torre destino
            Console.WriteLine($"Mover disco {disco} de {Nombre} a {destino.Nombre}");
        }
    }

    // Clase que contiene la lógica de la solución recursiva
    public class HanoiSolver
    {
        // Método recursivo que resuelve el problema
        public void Resolver(int n, Torre origen, Torre auxiliar, Torre destino)
        {
            if (n == 1)
            {
                origen.MoverDiscoA(destino);
            }
            else
            {
                Resolver(n - 1, origen, destino, auxiliar);     // Mover n-1 discos a la torre auxiliar
                origen.MoverDiscoA(destino);                    // Mover el disco mayor a la torre destino
                Resolver(n - 1, auxiliar, origen, destino);     // Mover n-1 discos desde la auxiliar a destino
            }
        }
    }

    // Clase principal
    class Program
    {
        static void Main(string[] args)
        {
            int cantidadDiscos = 3; // Puedes cambiar la cantidad de discos aquí

            // Crear tres torres: A (origen), B (auxiliar), C (destino)
            Torre torreA = new Torre("A");
            Torre torreB = new Torre("B");
            Torre torreC = new Torre("C");

            // Cargar los discos en la torre A (el más grande al fondo)
            for (int i = cantidadDiscos; i >= 1; i--)
            {
                torreA.Discos.Push(i);
            }

            // Mostrar estado inicial
            Console.WriteLine("Resolviendo Torres de Hanoi con " + cantidadDiscos + " discos:\n");

            // Resolver el problema
            HanoiSolver solver = new HanoiSolver();
            solver.Resolver(cantidadDiscos, torreA, torreB, torreC);

            Console.WriteLine("\n¡Resuelto!");
            Console.ReadKey();
        }
    }

