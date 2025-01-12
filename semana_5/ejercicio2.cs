using System;

public class Ejercicio2
{
    public static void Ejecutar()
    {
        Console.WriteLine("Ingrese su nombre:");
        string nombre = Console.ReadLine();
        Console.WriteLine("¿Cuántas veces desea ver su nombre?");
        
        int veces;
        while (!int.TryParse(Console.ReadLine(), out veces) || veces <= 0)
        {
            Console.WriteLine("Por favor, ingrese un número válido mayor a 0.");
        }

        for (int i = 0; i < veces; i++)
        {
            Console.WriteLine(nombre);
        }
    }
}