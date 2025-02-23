using System;
using System.Collections.Generic;
using System.Linq;
 
namespace Vacunacion
{
    public class VacunacionCOVID
    {
        public static void Main(string[] args)
        {
            // Lista total de ciudadanos
            List<string> ciudadanos = GenerarCiudadanos(500);
 
            // Seleccionar ciudadanos aleatoriamente, permitiendo superposición
            HashSet<string> vacunadosPfizer = new HashSet<string>(SeleccionarCiudadanosAleatorio(ciudadanos, 75));
            HashSet<string> vacunadosAstraZeneca = new HashSet<string>(SeleccionarCiudadanosAleatorio(ciudadanos, 75));
 
            // Ciudadanos vacunados con ambas vacunas: intersección de los conjuntos Pfizer y AstraZeneca
            HashSet<string> ambasVacunas = new HashSet<string>(vacunadosPfizer);
            ambasVacunas.IntersectWith(vacunadosAstraZeneca);
 
            // Determinar los ciudadanos no vacunados
            HashSet<string> vacunados = new HashSet<string>(ambasVacunas.Union(vacunadosPfizer).Union(vacunadosAstraZeneca));
            HashSet<string> noVacunados = new HashSet<string>(ciudadanos.Except(vacunados));
 
            // Determinar los ciudadanos con solo una dosis
            HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer.Except(vacunadosAstraZeneca));
            HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca.Except(vacunadosPfizer));
 
            // Imprimir resultados
            MostrarLista("Ciudadanos NO vacunados", noVacunados);
            MostrarLista("Ciudadanos vacunados con ambas dosis", ambasVacunas);
            MostrarLista("Ciudadanos vacunados solo con Pfizer", soloPfizer);
            MostrarLista("Ciudadanos vacunados solo con AstraZeneca", soloAstraZeneca);
            // Console.WriteLine($"\nTotal vacunados con Pfizer: {vacunadosPfizer.Count}");
            // Console.WriteLine($"Total vacunados con AstraZeneca: {vacunadosAstraZeneca.Count}");
        }
 
        // Generar lista de ciudadanos
        public static List<string> GenerarCiudadanos(int cantidad)
        {
            return Enumerable.Range(1, cantidad).Select(i => $"Ciudadano {i}").ToList();
        }
 
        // Seleccionar aleatoriamente un número específico de ciudadanos
        public static List<string> SeleccionarCiudadanosAleatorio(List<string> lista, int cantidad)
        {
            return lista.OrderBy(_ => Guid.NewGuid()).Take(cantidad).ToList();
        }
 
        // Método para mostrar los ciudadanos en consola
        public static void MostrarLista(string titulo, HashSet<string> conjunto)
        {
            Console.WriteLine($"\n{titulo} ({conjunto.Count} ciudadanos):");
            foreach (var ciudadano in conjunto)
            {
                Console.WriteLine(ciudadano);
            }
        }
    }
}