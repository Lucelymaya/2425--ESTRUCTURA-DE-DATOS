using System;

public class Ejercicio5
{
    public static void Ejecutar()
    {
        Console.WriteLine("Ingrese la cantidad de asignaturas:");
        int cantidadAsignaturas;
        while (!int.TryParse(Console.ReadLine(), out cantidadAsignaturas) || cantidadAsignaturas <= 0)
        {
            Console.WriteLine("Por favor, ingrese una cantidad válida de asignaturas.");
        }

        decimal sumaNotas = 0;
        for (int i = 1; i <= cantidadAsignaturas; i++)
        {
            Console.WriteLine($"Ingrese la nota de la asignatura {i}:");
            decimal nota;
            while (!decimal.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            {
                Console.WriteLine("Por favor, ingrese una nota válida (entre 0 y 10).");
            }
            sumaNotas += nota;
        }

        decimal promedio = sumaNotas / cantidadAsignaturas;
        Console.WriteLine($"El promedio de las asignaturas es: {promedio:F2}");
    }
}