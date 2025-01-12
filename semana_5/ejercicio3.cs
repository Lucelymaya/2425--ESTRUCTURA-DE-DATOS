using System;

public class Ejercicio3
{
    public static void Ejecutar()
    {
        Console.WriteLine("Ingrese su nombre:");
        string nombre = Console.ReadLine();
        Console.WriteLine($"El nombre ingresado tiene {nombre.Length} letras.");
    }
}