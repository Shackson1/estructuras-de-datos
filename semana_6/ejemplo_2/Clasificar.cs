
// Clase encargada de clasificar los datos de una lista según el promedio

public class Clasificador
{
    private ListaNumeros listaPrincipal;           // Lista con todos los datos
    private ListaNumeros listaMenoresIguales;      // Datos <= promedio
    private ListaNumeros listaMayores;             // Datos > promedio

    public Clasificador()
    {
        listaPrincipal = new ListaNumeros();
        listaMenoresIguales = new ListaNumeros();
        listaMayores = new ListaNumeros();

        // Carga inicial con datos predefinidos
        double[] datosIniciales = { 4.5, 7.2, 3.1, 9.8, 6.0, 5.5, 2.3 };
        foreach (double d in datosIniciales)
        {
            listaPrincipal.Agregar(d);
        }
    }

    // Ejecuta el proceso completo: calcula promedio y clasifica los datos
    public void Ejecutar()
    {
        // Mostrar lista principal
        listaPrincipal.MostrarLista("a) Datos cargados en la lista principal");

        // Calcular promedio
        double promedio = listaPrincipal.CalcularPromedio();
        Console.WriteLine($"b) Promedio de los datos: {promedio:F2}");

        // Recorrer lista y clasificar
        Nodo? actual = listaPrincipal.ObtenerHead();
        while (actual != null)
        {
            if (actual.Dato <= promedio)
                listaMenoresIguales.Agregar(actual.Dato);
            else
                listaMayores.Agregar(actual.Dato);

            actual = actual.Siguiente;
        }

        // Mostrar resultados
        listaMenoresIguales.MostrarLista("c) Datos menores o iguales al promedio");
        listaMayores.MostrarLista("d) Datos mayores al promedio");
    }
}
