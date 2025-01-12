using System;

public class Ejercicio4
{
    public static void Ejecutar()
    {
        Console.WriteLine("Ingrese el precio del producto:");
        decimal precio;
        while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
        {
            Console.WriteLine("Por favor, ingrese un precio válido mayor a 0.");
        }

        Console.WriteLine("Ingrese el porcentaje de descuento:");
        decimal descuento;
        while (!decimal.TryParse(Console.ReadLine(), out descuento) || descuento < 0)
        {
            Console.WriteLine("Por favor, ingrese un descuento válido.");
        }

        Console.WriteLine("Ingrese el porcentaje de IVA:");
        decimal iva;
        while (!decimal.TryParse(Console.ReadLine(), out iva) || iva < 0)
        {
            Console.WriteLine("Por favor, ingrese un IVA válido.");
        }

        decimal precioConDescuento = precio - (precio * descuento / 100);
        decimal precioFinal = precioConDescuento + (precioConDescuento * iva / 100);
        Console.WriteLine($"Precio con descuento: {precioConDescuento:C2}");
        Console.WriteLine($"Precio final con IVA: {precioFinal:C2}");
    }
}