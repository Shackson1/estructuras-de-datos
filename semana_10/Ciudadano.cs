using System;

namespace CampaniaVacunacion
{
    // Clase que representa a un ciudadano con su nombre y estado de vacunación
    public class Ciudadano
    {
        // Nombre único del ciudadano (solo lectura desde fuera)
        public string Nombre { get; }

        // Indica si el ciudadano ha recibido la vacuna de Pfizer
        public bool HaRecibidoPfizer { get; private set; }

        // Indica si el ciudadano ha recibido la vacuna de AstraZeneca
        public bool HaRecibidoAstraZeneca { get; private set; }

        // Constructor: asigna el nombre y deja ambos estados de vacunación en falso
        public Ciudadano(string nombre)
        {
            Nombre = nombre;
            HaRecibidoPfizer = false;
            HaRecibidoAstraZeneca = false;
        }

        // Marca que el ciudadano ha recibido la dosis de Pfizer
        public void RecibirPfizer()
        {
            HaRecibidoPfizer = true;
        }

        // Marca que el ciudadano ha recibido la dosis de AstraZeneca
        public void RecibirAstraZeneca()
        {
            HaRecibidoAstraZeneca = true;
        }

        // Devuelve el nombre del ciudadano cuando se imprime el objeto
        public override string ToString()
        {
            return Nombre;
        }

        // Compara ciudadanos por nombre para determinar igualdad
        public override bool Equals(object obj)
        {
            return obj is Ciudadano otro && Nombre == otro.Nombre;
        }

        // Genera un código hash basado en el nombre (para usar en colecciones como HashSet)
        public override int GetHashCode()
        {
            return Nombre.GetHashCode(StringComparison.InvariantCulture);
        }
    }
}