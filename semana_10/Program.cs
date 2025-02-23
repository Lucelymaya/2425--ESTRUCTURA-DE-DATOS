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

            // Seleccionar ciudadanos aleatoriamente sin repetir
            HashSet<string> dobleVacunados = new HashSet<string>(SeleccionarCiudadanosAleatorio(ciudadanos, 100));
            HashSet<string> restantes = new HashSet<string>(ciudadanos.Except(dobleVacunados));
            HashSet<string> pfizerVacunados = new HashSet<string>(SeleccionarCiudadanosAleatorio(restantes.ToList(), 75));
            restantes.ExceptWith(pfizerVacunados);
            HashSet<string> astrazenecaVacunados = new HashSet<string>(SeleccionarCiudadanosAleatorio(restantes.ToList(), 75));

            // Determinar los ciudadanos no vacunados
            HashSet<string> vacunados = new HashSet<string>(dobleVacunados.Union(pfizerVacunados).Union(astrazenecaVacunados));
            HashSet<string> noVacunados = new HashSet<string>(ciudadanos.Except(vacunados));

            // Determinar los ciudadanos con solo una dosis
            HashSet<string> soloPfizer = new HashSet<string>(pfizerVacunados.Except(dobleVacunados));
            HashSet<string> soloAstrazeneca = new HashSet<string>(astrazenecaVacunados.Except(dobleVacunados));

            // Imprimir resultados
            MostrarLista("Ciudadanos NO vacunados", noVacunados);
            MostrarLista("Ciudadanos vacunados con ambas dosis", dobleVacunados);
            MostrarLista("Ciudadanos vacunados solo con Pfizer", soloPfizer);
            MostrarLista("Ciudadanos vacunados solo con AstraZeneca", soloAstrazeneca);
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
