using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaniaVacunacion
{
    // Clase que gestiona la campaña de vacunación de un conjunto de ciudadanos
    public class CampanaVacunacion
    {
        // Almacena el conjunto completo de ciudadanos
        private readonly HashSet<Ciudadano> ciudadanos = new();

        // Generador de números aleatorios para las selecciones
        private readonly Random rnd = new();

        // Genera 'cantidad' ciudadanos con nombres "Ciudadano001", "Ciudadano002", …
        public void GenerarCiudadanos(int cantidad)
        {
            for (int i = 1; i <= cantidad; i++)
            {
                // Crear un nuevo ciudadano con nombre secuencial
                var nuevo = new Ciudadano($"Ciudadano{i:D3}");
                ciudadanos.Add(nuevo);
            }
        }

        // Distribuye vacunas de manera que:
        //  - Siempre haya soloPfizerCount ciudadanos con únicamente Pfizer
        //  - Siempre haya soloAstraCount ciudadanos con únicamente AstraZeneca
        //  - El resto se reparte aleatoriamente entre "ambas dosis" y "no vacunados"
        public void VacunarAleatoriamente(int soloPfizerCount, int soloAstraCount)
        {
            // 1) Obtener total de ciudadanos disponibles
            int total = ciudadanos.Count;

            // 2) Calcular aleatoriamente cuántos recibirán ambas dosis
            int bothCount = rnd.Next(0, total - soloPfizerCount - soloAstraCount + 1);

            // 3) Seleccionar 'bothCount' ciudadanos para recibir Pfizer y AstraZeneca
            var bothSet = SeleccionarAleatorios(ciudadanos, bothCount);

            // 4) Construir conjunto con los que quedan después de extraer bothSet
            var remaining = new HashSet<Ciudadano>(ciudadanos.Except(bothSet));

            // 5) De los restantes, seleccionar 'soloPfizerCount' para solo Pfizer
            var pfSet = SeleccionarAleatorios(remaining, soloPfizerCount);
            //    Eliminar esos seleccionados del conjunto restante
            remaining.ExceptWith(pfSet);

            // 6) De los que quedan, seleccionar 'soloAstraCount' para solo AstraZeneca
            var azSet = SeleccionarAleatorios(remaining, soloAstraCount);
            //    Eliminar esos seleccionados del conjunto restante
            remaining.ExceptWith(azSet);

            // 7) Asignar vacunas:
            //    - A bothSet: aplicar Pfizer y AstraZeneca
            foreach (var c in bothSet)
            {
                c.RecibirPfizer();
                c.RecibirAstraZeneca();
            }

            //    - A pfSet: aplicar únicamente Pfizer
            foreach (var c in pfSet)
            {
                c.RecibirPfizer();
            }

            //    - A azSet: aplicar únicamente AstraZeneca
            foreach (var c in azSet)
            {
                c.RecibirAstraZeneca();
            }

            // 8) Lo que quede en 'remaining' son los ciudadanos sin vacunar
        }

        // Devuelve 'n' ciudadanos elegidos al azar desde el conjunto fuente
        private HashSet<Ciudadano> SeleccionarAleatorios(HashSet<Ciudadano> fuente, int n)
        {
            // Barajar la colección y tomar los primeros 'n'
            return fuente
                .OrderBy(_ => rnd.Next())
                .Take(n)
                .ToHashSet();
        }

        // Filtra y devuelve los ciudadanos sin ninguna dosis
        public HashSet<Ciudadano> ObtenerNoVacunados()
        {
            return ciudadanos
                .Where(c => !c.HaRecibidoPfizer && !c.HaRecibidoAstraZeneca)
                .ToHashSet();
        }

        // Filtra y devuelve los ciudadanos que tienen ambas dosis
        public HashSet<Ciudadano> ObtenerConAmbasDosis()
        {
            return ciudadanos
                .Where(c => c.HaRecibidoPfizer && c.HaRecibidoAstraZeneca)
                .ToHashSet();
        }

        // Filtra y devuelve los ciudadanos que solo recibieron Pfizer
        public HashSet<Ciudadano> ObtenerSoloPfizer()
        {
            return ciudadanos
                .Where(c => c.HaRecibidoPfizer && !c.HaRecibidoAstraZeneca)
                .ToHashSet();
        }

        // Filtra y devuelve los ciudadanos que solo recibieron AstraZeneca
        public HashSet<Ciudadano> ObtenerSoloAstraZeneca()
        {
            return ciudadanos
                .Where(c => !c.HaRecibidoPfizer && c.HaRecibidoAstraZeneca)
                .ToHashSet();
        }
    }
}