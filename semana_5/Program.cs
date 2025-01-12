using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Seleccione un ejercicio para ejecutar (1-5):");
        Console.WriteLine("1. Mostrar asignaturas de un curso.");
        Console.WriteLine("2. Mostrar asignaturas con mensaje personalizado.");
        Console.WriteLine("3. Mostrar números del 1 al 10 en orden inverso.");
        Console.WriteLine("4. Pedir números al usuario hasta ingresar '0'.");
        Console.WriteLine("5. Calcular el producto de los números de una lista.");

        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                MostrarAsignaturas();
                break;
            case 2:
                MostrarAsignaturasConMensaje();
                break;
            case 3:
                MostrarNumerosInverso();
                break;
            case 4:
                PedirNumerosHastaCero();
                break;
            case 5:
                CalcularProductoLista();
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, elija entre 1 y 5.");
                break;
        }
    }

    static void MostrarAsignaturas()
    {
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Console.WriteLine("Asignaturas del curso:");
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine(asignatura);
        }
    }

    static void MostrarAsignaturasConMensaje()
    {
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Console.WriteLine("Asignaturas con mensaje personalizado:");
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura}");
        }
    }

    static void MostrarNumerosInverso()
    {
        List<int> numeros = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }

        numeros.Reverse();

        Console.WriteLine("Números del 1 al 10 en orden inverso:");
        Console.WriteLine(string.Join(", ", numeros));
    }

    static void PedirNumerosHastaCero()
    {
        List<int> numeros = new List<int>();
        int numero;

        Console.WriteLine("Introduce números (0 para terminar):");
        do
        {
            numero = int.Parse(Console.ReadLine());
            if (numero != 0)
            {
                numeros.Add(numero);
            }
        } while (numero != 0);

        Console.WriteLine("Los números ingresados son:");
        Console.WriteLine(string.Join(", ", numeros));
    }

    static void CalcularProductoLista()
    {
        List<int> numeros = new List<int> { 1, 2, 3, 4, 5 }; // Lista predefinida.
        int producto = 1;

        foreach (int numero in numeros)
        {
            producto *= numero;
        }

        Console.WriteLine("El producto de los números de la lista es: " + producto);
    }
}

