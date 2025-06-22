// Clase que maneja toda la lógica de la agenda:
// almacena contactos en un vector general y en una matriz por categoría,
// y ofrece métodos para CRUD, listados, orden y búsqueda.
public class Agenda
{
    // Capacidad máxima fija para contactos
    private const int Max = 100;

    // 1) Vector (array unidimensional) para almacenar todos los contactos
    private readonly Contacto[] _todos = new Contacto[Max];
    // Contador de cuántos contactos hay en el vector
    private int _total = 0;

    // 2) Matriz (array bidimensional) para separar contactos por categoría:
    //    filas = 0: Random, 1: Familia, 2: Trabajo
    //    columnas = posiciones hasta Max
    private readonly Contacto?[,] _porCategoria = new Contacto?[3, Max];
    // Contador de cuántos contactos hay en cada fila/categoría
    private readonly int[] _conteoPorCat = new int[3];

    // 3) Definimos las 3 categorías con nuestro struct Categoria
    private readonly Categoria[] _categorias =
    {
        new Categoria(0, "Random"),
        new Categoria(1, "Familia"),
        new Categoria(2, "Trabajo")
    };

    // =====================
    // Método Agregar()
    // =====================
    // Pide datos al usuario, determina la categoría,
    // crea el objeto Contacto adecuado y lo guarda
    public void Agregar()
    {
        // Leemos nombre, teléfono y correo
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Teléfono: ");
        string tel = Console.ReadLine() ?? "";
        Console.Write("Correo: ");
        string corr = Console.ReadLine() ?? "";

        // Pedimos la categoría con 0,1 o 2; si falla, usamos Random (0)
        Console.Write("Tipo [0=Random,1=Familia,2=Trabajo]: ");
        bool ok = int.TryParse(Console.ReadLine(), out int catId);
        if (!ok || catId < 0 || catId > 2)
            catId = 0;

        // Creamos el contacto según la categoría elegida:
        //  - Familia pide además parentesco
        //  - Trabajo pide además empresa
        //  - Random no pide nada extra
        Contacto c = catId switch
        {
            1 => new ContactoFamilia(
                    nombre, tel, corr,
                    LeerValor("Parentesco: ")),
            2 => new ContactoTrabajo(
                    nombre, tel, corr,
                    LeerValor("Empresa: ")),
            _ => new ContactoRandom(nombre, tel, corr)
        };

        // 1) Insertamos en el vector general si hay espacio
        if (_total < Max)
            _todos[_total++] = c;

        // 2) Insertamos en la matriz en la fila de la categoría
        int idx = _conteoPorCat[catId]++;
        if (idx < Max)
            _porCategoria[catId, idx] = c;

        // Confirmamos al usuario
        Console.WriteLine($"[OK] Agregado a {_categorias[catId]}: {c}");
    }

    // =====================
    // Método Eliminar()
    // =====================
    // Pide un nombre y elimina todas las coincidencias
    public void Eliminar()
    {
        Console.Write("Nombre a eliminar: ");
        string bus = Console.ReadLine() ?? "";
        int antes = _total;

        // 1) Vector: compactamos los que NO coinciden
        int j = 0;
        for (int i = 0; i < _total; i++)
        {
            if (!_todos[i].Nombre.Equals(bus, StringComparison.OrdinalIgnoreCase))
            {
                _todos[j++] = _todos[i];
            }
        }
        _total = j;

        // 2) Matriz: limpiamos cada fila y ajustamos conteos
        for (int cat = 0; cat < 3; cat++)
        {
            int k = 0;
            // Recorremos solo hasta el conteo actual de esa fila
            for (int i = 0; i < _conteoPorCat[cat]; i++)
            {
                var cell = _porCategoria[cat, i];
                // Si no es null y no coincide, lo mantenemos
                if (cell != null &&
                    !cell.Nombre.Equals(bus, StringComparison.OrdinalIgnoreCase))
                {
                    _porCategoria[cat, k++] = cell;
                }
            }
            // Actualizamos cuántos quedan en esa fila
            _conteoPorCat[cat] = k;
            // Limpiamos el resto de posiciones sobrantes
            for (int i = k; i < Max; i++)
            {
                _porCategoria[cat, i] = null;
            }
        }

        // Informamos cuántos se eliminaron
        Console.WriteLine($"Se eliminaron {antes - _total} contacto(s).");
    }

    // =====================
    // Métodos Mostrar…
    // =====================
    // MostrarTodos: imprime todos los del vector
    public void MostrarTodos()
        => MostrarListado(_todos.Take(_total),
                         _total, "Todos");

    // MostrarRandom: imprime solo fila 0 de la matriz
    public void MostrarRandom()
        => MostrarListado(
               _porCategoria
                 .OfType<Contacto>()
                 .Where((_, i) => i < _conteoPorCat[0]),
               _conteoPorCat[0],
               "Random");

    // MostrarFamilia: fila 1 de la matriz
    public void MostrarFamilia()
        => MostrarListado(
               _porCategoria
                 .OfType<Contacto>()
                 .Skip(_conteoPorCat[0])
                 .Take(_conteoPorCat[1]),
               _conteoPorCat[1],
               "Familia");

    // MostrarTrabajo: fila 2 de la matriz
    public void MostrarTrabajo()
        => MostrarListado(
               _porCategoria
                 .OfType<Contacto>()
                 .Skip(_conteoPorCat[0] + _conteoPorCat[1])
                 .Take(_conteoPorCat[2]),
               _conteoPorCat[2],
               "Trabajo");

    // =====================
    // Método Ordenar()
    // =====================
    // Ordena el vector general por Nombre (alfabéticamente)
    public void Ordenar()
    {
        Array.Sort(_todos, 0, _total,
            Comparer<Contacto>.Create((a, b)
                => string.Compare(
                    a.Nombre, b.Nombre,
                    StringComparison.OrdinalIgnoreCase)));
        Console.WriteLine("Vector ordenado alfabéticamente.");
    }

    // =====================
    // Método BuscarPorNombre()
    // =====================
    // Busca la primera coincidencia en el vector general
    public void BuscarPorNombre()
    {
        Console.Write("Nombre a buscar: ");
        string bus = Console.ReadLine() ?? "";
        for (int i = 0; i < _total; i++)
        {
            if (_todos[i].Nombre.Equals(bus, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Encontrado: " + _todos[i]);
                return;
            }
        }
        Console.WriteLine("No se encontró el contacto.");
    }

    // =====================
    // Método auxiliar MostrarListado()
    // =====================
    // Toma una secuencia de Contacto, un conteo y un título,
    // imprime un encabezado con el título y la cantidad,
    // y luego lista cada elemento numerado.
    private void MostrarListado(
        IEnumerable<Contacto> seq,
        int count,
        string titulo)
    {
        Console.WriteLine($"\n--- {titulo} ({count}) ---");
        if (count == 0)
        {
            Console.WriteLine("  (ninguno)");
            return;
        }
        int i = 1;
        foreach (var c in seq)
        {
            Console.WriteLine($"{i++}. {c}");
        }
    }

    // =====================
    // Método auxiliar LeerValor()
    // =====================
    // Simplifica la lectura de un dato extra (parentezco o empresa)
    private static string LeerValor(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }
}
