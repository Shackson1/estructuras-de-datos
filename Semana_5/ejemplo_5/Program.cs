
// Crear objeto de la clase ListaDePrecios
ListaDePrecios lista = new ListaDePrecios();

// Mostrar todos los precios (opcional)
lista.MostrarPrecios();

// Obtener y mostrar el precio más bajo y el más alto
double menor = lista.ObtenerPrecioMinimo();
double mayor = lista.ObtenerPrecioMaximo();

Console.WriteLine($"\n Precio menor: {menor}");
Console.WriteLine($" Precio mayor: {mayor}");

