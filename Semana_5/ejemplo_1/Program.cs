//Escribir un programa que almacene en una lista los números del 1 al 10 y
// los muestre por pantalla en orden inverso separados por comas.

// Paso 1: Crear una lista de enteros vacía
List<int> numeros = new List<int>();

// Paso 2: Agregar los números del 1 al 10 a la lista
// Usamos un bucle for que recorra del 1 al 10
for (int i = 1; i <= 10; i++)
{
    numeros.Add(i); // Agregamos cada número a la lista
}

// Paso 3: Mostrar los números en orden inverso, separados por comas
// Creamos una cadena para almacenar los números invertidos
string salida = "";

// Usamos un bucle que empiece desde el último elemento de la lista hasta el primero
for (int i = numeros.Count - 1; i >= 0; i--)
{
    salida += numeros[i]; // Agregamos el número actual a la cadena

    // Agregamos una coma si no es el último número (el primero en la lista original)
    if (i != 0)
    {
        salida += ", ";
    }
}

// Paso 4: Mostramos la salida en la consola
Console.WriteLine("Números en orden descendente:");
Console.WriteLine(salida);

