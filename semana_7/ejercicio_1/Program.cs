
    // Clase que encapsula la lógica de verificación de balanceo de símbolos
    public class VerificadorBalance
    {
        // Método público para verificar una expresión
        public bool EstaBalanceada(string expresion)
        {
            // Stack para almacenar los caracteres de apertura
            Stack<char> pila = new Stack<char>();

            // Diccionario para definir pares válidos de apertura/cierre
            Dictionary<char, char> pares = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            // Recorremos cada carácter de la expresión
            foreach (char caracter in expresion)
            {
                // Si es un símbolo de apertura, lo apilamos
                if (caracter == '(' || caracter == '[' || caracter == '{')
                {
                    pila.Push(caracter);
                }
                // Si es un símbolo de cierre, verificamos la correspondencia
                else if (caracter == ')' || caracter == ']' || caracter == '}')
                {
                    // Si la pila está vacía o el símbolo de la cima no corresponde
                    if (pila.Count == 0 || pila.Peek() != pares[caracter])
                    {
                        return false; // No está balanceado
                    }

                    // Sacamos el símbolo correspondiente de la pila
                    pila.Pop();
                }
            }

            // Si la pila está vacía al final, los símbolos están balanceados
            return pila.Count == 0;
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos la clase VerificadorBalance
            VerificadorBalance verificador = new VerificadorBalance();

            // Ejemplo de expresión matemática
            string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";

            // Llamamos al método para verificar el balance
            bool balanceado = verificador.EstaBalanceada(expresion);

            // Mostramos el resultado al usuario
            if (balanceado)
            {
                Console.WriteLine("Fórmula balanceada.");
            }
            else
            {
                Console.WriteLine("Fórmula no balanceada.");
            }

            // Pausa para ver resultados si se ejecuta en consola
            Console.ReadKey();
        }
    }


