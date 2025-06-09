using System;

// Clase que representa un Rectángulo
public class Rectangulo
{
    // Atributos privados que representan la base y altura del rectángulo
    private double baseRect;
    private double altura;

    // Constructor que inicializa los valores de base y altura
    public Rectangulo(double baseRect, double altura)
    {
        this.baseRect = baseRect;
        this.altura = altura;
    }

    // CalcularArea devuelve el área del rectángulo como un valor double
    public double CalcularArea()
    {
        return baseRect * altura;
    }

    // CalcularPerimetro devuelve el perímetro del rectángulo como un valor double
    public double CalcularPerimetro()
    {
        return 2 * (baseRect + altura);
    }
}

// Clase que representa un Triángulo
public class Triangulo
{
    // Atributos privados que representan los lados del triángulo
    private double lado1;
    private double lado2;
    private double lado3;

    // Constructor que inicializa los lados del triángulo
    public Triangulo(double lado1, double lado2, double lado3)
    {
        this.lado1 = lado1;
        this.lado2 = lado2;
        this.lado3 = lado3;
    }

    // CalcularArea devuelve el área usando la fórmula de Herón
    public double CalcularArea()
    {
        double s = (lado1 + lado2 + lado3) / 2; // semiperímetro
        return Math.Sqrt(s * (s - lado1) * (s - lado2) * (s - lado3));
    }

    // CalcularPerimetro devuelve la suma de los lados del triángulo
    public double CalcularPerimetro()
    {
        return lado1 + lado2 + lado3;
    }
}

// Clase principal que prueba las figuras
class Programa
{
    static void Main(string[] args)
    {
        // Crear un rectángulo con base 5 y altura 3
        Rectangulo rect = new Rectangulo(5, 3);
        Console.WriteLine("Área del rectángulo: " + rect.CalcularArea());
        Console.WriteLine("Perímetro del rectángulo: " + rect.CalcularPerimetro());

        // Crear un triángulo con lados 3, 4 y 5
        Triangulo tri = new Triangulo(3, 4, 5);
        Console.WriteLine("Área del triángulo: " + tri.CalcularArea());
        Console.WriteLine("Perímetro del triángulo: " + tri.CalcularPerimetro());
    }
}
