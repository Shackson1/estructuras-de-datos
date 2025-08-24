using System;
using System.Collections.Generic;

namespace CampaniaVacunacion
{
    class ProgramaPrincipal
    {
        static void Main(string[] args)
        {
            // Crear una nueva campaña de vacunación
            var campaña = new CampanaVacunacion();

            // Generar un total de 500 ciudadanos con nombres automáticos
            campaña.GenerarCiudadanos(500);

            // Vacunar aleatoriamente: 75 solo con Pfizer y 75 solo con AstraZeneca
            // El resto se asigna entre "ambas dosis" y "no vacunados"
            campaña.VacunarAleatoriamente(75, 75);

            // Obtener el conjunto de ciudadanos que no se vacunaron
            var noVacunados = campaña.ObtenerNoVacunados();

            // Obtener el conjunto de ciudadanos con ambas dosis
            var conAmbasDosis = campaña.ObtenerConAmbasDosis();

            // Obtener el conjunto de ciudadanos que solo recibieron Pfizer
            var soloPfizer = campaña.ObtenerSoloPfizer();

            // Obtener el conjunto de ciudadanos que solo recibieron AstraZeneca
            var soloAstraZeneca = campaña.ObtenerSoloAstraZeneca();

            // Mostrar en consola únicamente el total de cada grupo
            Console.WriteLine($"Ciudadanos que no se han vacunado:    {noVacunados.Count}");
            Console.WriteLine($"Ciudadanos con AMBAS dosis:           {conAmbasDosis.Count}");
            Console.WriteLine($"Ciudadanos SOLO Pfizer:               {soloPfizer.Count}");
            Console.WriteLine($"Ciudadanos SOLO AstraZeneca:          {soloAstraZeneca.Count}");

            // Menú interactivo para que el usuario pueda ver los nombres de cada grupo
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("¿Qué lista de nombres desea ver?");
                Console.WriteLine("  1 - Ciudadanos que no se han vacunado");
                Console.WriteLine("  2 - Ciudadanos con AMBAS dosis");
                Console.WriteLine("  3 - Ciudadanos SOLO Pfizer");
                Console.WriteLine("  4 - Ciudadanos SOLO AstraZeneca");
                Console.WriteLine("  0 - Salir");
                Console.Write("Digite el número de la opción: ");

                // Leer la opción del usuario y limpiar espacios en blanco
                var input = Console.ReadLine()?.Trim();
                Console.WriteLine();

                // Si el usuario digita 0, salir del menú y finalizar el programa
                if (input == "0")
                {
                    break;
                }
                // Si el usuario elige opción 1, mostrar nombres de no vacunados
                else if (input == "1")
                {
                    ImprimirNombres("Ciudadanos que no se han vacunado", noVacunados);
                }
                // Opción 2: mostrar nombres de ciudadanos con ambas dosis
                else if (input == "2")
                {
                    ImprimirNombres("Ciudadanos con AMBAS dosis", conAmbasDosis);
                }
                // Opción 3: mostrar nombres de ciudadanos solo con Pfizer
                else if (input == "3")
                {
                    ImprimirNombres("Ciudadanos SOLO Pfizer", soloPfizer);
                }
                // Opción 4: mostrar nombres de ciudadanos solo con AstraZeneca
                else if (input == "4")
                {
                    ImprimirNombres("Ciudadanos SOLO AstraZeneca", soloAstraZeneca);
                }
                // Si la opción no es válida, mostrar mensaje de error
                else
                {
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                }
            }
        }

        // Método auxiliar que imprime todos los nombres de un conjunto de ciudadanos
        static void ImprimirNombres(string titulo, HashSet<Ciudadano> conjunto)
        {
            Console.WriteLine($"Lista de {titulo}:");
            foreach (var ciudadano in conjunto)
            {
                // Cada ciudadano se imprimirá usando su ToString(), que devuelve el nombre
                Console.WriteLine($"  - {ciudadano}");
            }
        }
    }
}