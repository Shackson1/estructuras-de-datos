// Se define el espacio de nombres para organizar el código.
namespace GestorDeRevistas
{
    // Se importa la librería para poder usar colecciones como List<T>.
    using System.Collections.Generic;

    // Se declara una clase estática. Esto significa que no se puede crear una instancia de ella
    // y sus métodos se llaman directamente desde la clase.
    public static class Buscador
    {
        // Método de búsqueda binaria iterativa. Es más eficiente que una búsqueda lineal
        // en listas grandes y ordenadas, y evita el riesgo de desbordamiento de pila de la recursividad.
        // Recibe la lista ordenada y el título a buscar.
        public static bool BusquedaBinariaIterativa(List<string> catalogo, string tituloBuscado)
        {
            // Se inicializa el índice izquierdo en la primera posición de la lista (0).
            int izquierda = 0;
            // Se inicializa el índice derecho en la última posición de la lista.
            int derecha = catalogo.Count - 1;

            // El bucle se ejecuta mientras el sub-arreglo de búsqueda sea válido (izquierda <= derecha).
            while (izquierda <= derecha)
            {
                // Se calcula el índice del medio para dividir el rango de búsqueda.
                // Esto evita buscar en toda la lista, reduciendo el trabajo a la mitad en cada paso.
                int medio = izquierda + (derecha - izquierda) / 2;

                // Se compara el título buscado con el título en la posición media.
                // String.Compare devuelve:
                // < 0 si el título buscado es alfabéticamente anterior.
                // = 0 si son iguales.
                // > 0 si el título buscado es alfabéticamente posterior.
                int comparacion = string.Compare(tituloBuscado, catalogo[medio], System.StringComparison.OrdinalIgnoreCase);

                // Si 'comparacion' es 0, los títulos son iguales y hemos encontrado la revista.
                if (comparacion == 0)
                {
                    return true; // Encontrado.
                }

                // Si el título buscado es alfabéticamente anterior al del medio,
                // descartamos la mitad derecha de la búsqueda.
                if (comparacion < 0)
                {
                    derecha = medio - 1;
                }
                // Si el título buscado es alfabéticamente posterior al del medio,
                // descartamos la mitad izquierda de la búsqueda.
                else
                {
                    izquierda = medio + 1;
                }
            }

            // Si el bucle termina, significa que el título no está en la lista.
            return false; // No encontrado.
        }
    }
}