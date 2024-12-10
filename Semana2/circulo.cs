Console.WriteLine("Hello");
using System;

namespace FigurasGeometricas
{
    // Clase Círculo
    public class Circulo
    {
        // Propiedad para almacenar el radio del círculo
        public double Radio { get; set; }

        // Constructor que inicializa el radio
        public Circulo(double radio)
        {
            Radio = radio;
        }

        // Método para calcular el área del círculo
        // CalcularArea es una función que devuelve un valor double
        // Requiere como argumento el radio del círculo
        public double CalcularArea()
        {
            return Math.PI * Radio * Radio; // Fórmula: Área = π * radio^2
        }

        // Método para calcular el perímetro del círculo
        // CalcularPerimetro devuelve un valor double
        // Requiere como argumento el radio del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio; // Fórmula: Perímetro = 2 * π * radio
        }
    }

    // Clase Rectángulo
    public class Rectangulo
    {
        // Propiedades para almacenar la base y la altura del rectángulo
        public double Base { get; set; }
        public double Altura { get; set; }

        // Constructor que inicializa la base y la altura
        public Rectangulo(double baseRect, double alturaRect)
        {
            Base = baseRect;
            Altura = alturaRect;
        }

        // Método para calcular el área del rectángulo
        // CalcularArea devuelve un valor double
        // Requiere como argumentos la base y la altura del rectángulo
        public double CalcularArea()
        {
            return Base * Altura; // Fórmula: Área = base * altura
        }

        // Método para calcular el perímetro del rectángulo
        // CalcularPerimetro devuelve un valor double
        // Requiere como argumentos la base y la altura del rectángulo
        public double CalcularPerimetro()
        {
            return 2 * (Base + Altura); // Fórmula: Perímetro = 2 * (base + altura)
        }
    }

    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un objeto de tipo Circulo con un radio de 5
            Circulo circulo = new Circulo(5);

            // Imprimir el área y el perímetro del círculo
            Console.WriteLine("Área del círculo: " + circulo.CalcularArea());
            Console.WriteLine("Perímetro del círculo: " + circulo.CalcularPerimetro());

            // Crear un objeto de tipo Rectangulo con una base de 4 y una altura de 6
            Rectangulo rectangulo = new Rectangulo(4, 6);

            // Imprimir el área y el perímetro del rectángulo
            Console.WriteLine("Área del rectángulo: " + rectangulo.CalcularArea());
            Console.WriteLine("Perímetro del rectángulo: " + rectangulo.CalcularPerimetro());
        }
    }
}
