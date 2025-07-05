using System;

// Clase que implementa una lista enlazada de números reales con operaciones básicas

public class ListaNumeros
{
    private Nodo? head; // Referencia al primer nodo de la lista

    public ListaNumeros()
    {
        head = null;
    }

    // Agrega un nuevo nodo al final de la lista
    public void Agregar(double dato)
    {
        Nodo nuevo = new Nodo(dato);

        if (head == null)
        {
            head = nuevo;
        }
        else
        {
            Nodo actual = head;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    // Calcula el promedio de todos los datos almacenados en la lista
    public double CalcularPromedio()
    {
        double suma = 0;
        int contador = 0;
        Nodo? actual = head;

        while (actual != null)
        {
            suma += actual.Dato;
            contador++;
            actual = actual.Siguiente;
        }

        if (contador == 0)
            return 0;

        return suma / contador;
    }

    // Muestra los datos de la lista
    public void MostrarLista(string titulo)
    {
        Console.WriteLine($"\n{titulo}:");

        if (head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo? actual = head;
        while (actual != null)
        {
            Console.Write(actual.Dato + " ");
            actual = actual.Siguiente;
        }

        Console.WriteLine(); // Salto de línea
    }

    // Permite recorrer externamente la lista
    public Nodo? ObtenerHead()
    {
        return head;
    }
}
