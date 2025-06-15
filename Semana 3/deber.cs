using System;

public class Estudiante
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string[] Telefonos { get; set; }

    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        Id = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;

        if (telefonos.Length == 3)
        {
            Telefonos = telefonos;
        }
        else
        {
            throw new ArgumentException("Debe ingresar exactamente 3 números de teléfono.");
        }
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("\n--- Información del Estudiante ---");
        Console.WriteLine("ID: " + Id);
        Console.WriteLine("Nombres: " + Nombres);
        Console.WriteLine("Apellidos: " + Apellidos);
        Console.WriteLine("Dirección: " + Direccion);
        Console.WriteLine("Teléfonos:");
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
        }
    }
}

public class Programa_1
{
    public static void Main()
    {
        Console.WriteLine("--- Registro de Estudiante ---");

        // Captura de ID
        Console.Write("Ingrese el ID del estudiante: ");
        int id = int.Parse(Console.ReadLine()!); // Se asegura de que no sea null

        // Captura de nombres, apellidos y dirección (no nulos)
        Console.Write("Ingrese los nombres: ");
        string nombres = Console.ReadLine()!;

        Console.Write("Ingrese los apellidos: ");
        string apellidos = Console.ReadLine()!;

        Console.Write("Ingrese la dirección: ");
        string direccion = Console.ReadLine()!;

        // Captura de 3 teléfonos
        string[] telefonos = new string[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingrese el teléfono {i + 1}: ");
            telefonos[i] = Console.ReadLine()!;
        }

        // Creación del objeto y presentación de datos
        Estudiante estudiante = new Estudiante(id, nombres, apellidos, direccion, telefonos);
        estudiante.MostrarInformacion();
    }
}
