using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            // Mostrar las opciones del menú
            Console.WriteLine("\nSeleccione el ejercicio que desea ejecutar:");
            Console.WriteLine("1. Saludo simple");
            Console.WriteLine("2. Mostrar nombre N veces");
            Console.WriteLine("3. Contar letras del nombre");
            Console.WriteLine("4. Aplicar descuentos e IVA");
            Console.WriteLine("5. Notas de asignaturas");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");

            // Leer la opción seleccionada
            string opcion = Console.ReadLine();

            // Verificar la opción seleccionada
            switch (opcion)
            {
                case "1":
                    Ejercicio1.Ejecutar();
                    break;
                case "2":
                    Ejercicio2.Ejecutar();
                    break;
                case "3":
                    Ejercicio3.Ejecutar();
                    break;
                case "4":
                    Ejercicio4.Ejecutar();
                    break;
                case "5":
                    Ejercicio5.Ejecutar();
                    break;
                case "6":
                    Console.WriteLine("Saliendo...");
                    return; // Termina el programa
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}