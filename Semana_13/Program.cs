using System;
using System.Collections.Generic;

public class CatalogoPublicaciones
{
    private List<string> publicaciones;

    public CatalogoPublicaciones()
    {
        // Inicializar la lista de publicaciones con títulos predefinidos
        publicaciones = new List<string>
        {
            "Ciencia y Tecnología Avanzada",
            "Medicina Moderna",
            "Arte Contemporáneo",
            "Literatura Universal",
            "Historia del Mundo",
            "Educación Global",
            "Deportes Extremos",
            "Economía Internacional",
            "Medio Ambiente Sostenible",
            "Cultura y Sociedad"
        };
    }

    public string BuscarPublicacion(string titulo)
    {
        // Búsqueda iterativa en la lista de publicaciones
        foreach (string publicacion in publicaciones)
        {
            if (publicacion.Equals(titulo, StringComparison.OrdinalIgnoreCase)) // Ignora mayúsculas/minúsculas
            {
                return "encontrado";
            }
        }
        return "no encontrado";
    }
}

public class ProgramaPrincipal
{
    public static void Main(string[] args)
    {
        // Información del autor y docente
        string autor = "Lilia Lucely Maya Enriquez";
        string docente = "Delfin Bernabe Ortega Tenezaca";
        string fecha = DateTime.Now.ToString("dd/MM/yyyy"); // Fecha actual

        // Mostrar información
        Console.WriteLine($"AUTOR: {autor}");
        Console.WriteLine($"DOCENTE: {docente}");
        Console.WriteLine($"FECHA: {fecha}");
        Console.WriteLine();

        CatalogoPublicaciones catalogo = new CatalogoPublicaciones();

        int opcion;
        do
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Buscar una publicación");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el título de la publicación: ");
                        string tituloBuscado = Console.ReadLine();
                        string resultado = catalogo.BuscarPublicacion(tituloBuscado);
                        Console.WriteLine($"Resultado: {resultado}");
                        break;
                    case 2:
                        Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        } while (opcion != 2);
    }
}