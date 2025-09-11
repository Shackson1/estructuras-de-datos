// Se define el espacio de nombres para organizar el código.
namespace GestorDeRevistas
{
    // Se importa la librería para poder usar colecciones como List<T>.
    using System.Collections.Generic;

    // Declaración de la clase que manejará el catálogo de revistas.
    public class CatalogoRevistas
    {
        // Se declara una lista privada para almacenar los títulos de las revistas.
        // 'private' asegura que solo se pueda acceder a esta lista desde dentro de esta clase.
        private List<string> titulos;

        // Este es el constructor de la clase. Se ejecuta automáticamente cuando se crea un objeto de tipo CatalogoRevistas.
        public CatalogoRevistas()
        {
            // Se inicializa la lista de títulos.
            titulos = new List<string>();

            // Se llama al método para cargar y ordenar los títulos iniciales.
            CargarDatosIniciales();
        }

        // Método privado para poblar el catálogo con 10 revistas conocidas y ordenarlas.
        private void CargarDatosIniciales()
        {
            // Se agregan 10 títulos de revistas populares a la lista.
            titulos.Add("National Geographic");
            titulos.Add("Time");
            titulos.Add("Vogue");
            titulos.Add("Forbes");
            titulos.Add("The New Yorker");
            titulos.Add("Scientific American");
            titulos.Add("Sports Illustrated");
            titulos.Add("Rolling Stone");
            titulos.Add("Cosmopolitan");
            titulos.Add("People");

            // Es fundamental ordenar la lista para que la búsqueda binaria funcione.
            // El método Sort() ordena los elementos de la lista alfabéticamente.
            titulos.Sort();
        }

        // Método público que permite buscar un título en el catálogo.
        // Recibe como parámetro el título que se desea encontrar.
        public bool BuscarTitulo(string titulo)
        {
            // Llama al método de búsqueda binaria de la clase Buscador y devuelve su resultado (true o false).
            // Le pasa la lista de títulos y el título a buscar.
            return Buscador.BusquedaBinariaIterativa(titulos, titulo);
        }
    }
}