using System;
using System.Collections.Generic;
using System.Linq;

namespace TraductorBasico
{
    class Program
    {
        static Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"time", "tiempo"}, {"person", "persona"}, {"year", "año"}, {"way", "camino"},
            {"day", "día"}, {"thing", "cosa"}, {"man", "hombre"}, {"world", "mundo"},
            {"life", "vida"}, {"hand", "mano"}, {"part", "parte"}, {"child", "niño/a"},
            {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"}, {"work", "trabajo"},
            {"week", "semana"}, {"case", "caso"}, {"point", "punto/tema"}, {"government", "gobierno"},
            {"company", "empresa/compañía"}
        };

        static void Main()
        {
            int opcion;
            do
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Ingresar más palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            TraducirFrase();
                            break;
                        case 2:
                            AgregarPalabra();
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número.");
                }

            } while (opcion != 0);
        }

        static void TraducirFrase()
        {
            Console.Write("Ingrese la frase: ");
            string frase = Console.ReadLine() ?? string.Empty; // Asignar un valor predeterminado si es null
            if (string.IsNullOrEmpty(frase))
            {
                Console.WriteLine("La frase no puede estar vacía.");
                return;
            }

            string[] palabras = frase.Split(' ');
            List<string> fraseTraducida = new List<string>();

            foreach (string palabra in palabras)
            {
                // Limpiar la palabra de caracteres especiales
                string palabraLimpia = new string(palabra.ToLower().Where(c => char.IsLetter(c) || c == '/').ToArray());

                // Traducir la palabra
                string traduccion = palabra; // Mantener la palabra original si no se encuentra traducción

                if (diccionario.ContainsKey(palabraLimpia))
                {
                    traduccion = diccionario[palabraLimpia]; // Traducir de inglés a español
                }
                else if (diccionario.ContainsValue(palabraLimpia))
                {
                    // Traducir de español a inglés
                    var entrada = diccionario.FirstOrDefault(x => x.Value == palabraLimpia);
                    if (!string.IsNullOrEmpty(entrada.Key)) // Verificar si se encontró una coincidencia
                    {
                        traduccion = entrada.Key;
                    }
                }

                // Mantener la capitalización original
                if (!string.IsNullOrEmpty(traduccion) && char.IsUpper(palabra[0]))
                {
                    traduccion = char.ToUpper(traduccion[0]) + traduccion.Substring(1);
                }

                // Restaurar caracteres especiales
                string palabraFinal = palabra;
                if (palabra.Length > 0)
                {
                    palabraFinal = traduccion + new string(palabra.SkipWhile(char.IsLetter).ToArray());
                }

                fraseTraducida.Add(palabraFinal);
            }

            Console.WriteLine("Su frase traducida es: " + string.Join(" ", fraseTraducida));
        }

        static void AgregarPalabra()
        {
            Console.Write("Ingrese la palabra en inglés: ");
            string ingles = Console.ReadLine()?.ToLower() ?? string.Empty;

            Console.Write("Ingrese su traducción en español: ");
            string espanol = Console.ReadLine()?.ToLower() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(ingles) && !string.IsNullOrWhiteSpace(espanol))
            {
                if (!diccionario.ContainsKey(ingles))
                {
                    diccionario.Add(ingles, espanol);
                    Console.WriteLine("Palabra agregada con éxito.");
                }
                else
                {
                    Console.WriteLine("La palabra ya existe en el diccionario.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Las palabras no pueden estar vacías.");
            }
        }
    }
}