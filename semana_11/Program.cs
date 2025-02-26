using System;
using System.Collections.Generic;

namespace TraductorBasico
{
    class Program
    {
        static Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"time", "tiempo"}, {"person", "persona"}, {"year", "año"}, {"way", "camino"},
            {"day", "día"}, {"thing", "cosa"}, {"man", "hombre"}, {"world", "mundo"},
            {"life", "vida"}, {"hand", "mano"}, {"part", "parte"}, {"child", "niño"},
            {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"}, {"work", "trabajo"},
            {"week", "semana"}, {"case", "caso"}, {"point", "punto"}, {"government", "gobierno"},
            {"company", "empresa"}
        };

        static void Main()
        {
            int opcion;
            do
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Ingresar más palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese un número válido.");
                    continue;
                }

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
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            } while (opcion != 0);
        }

        static void TraducirFrase()
        {
            Console.Write("\nIngrese la frase a traducir: ");
            string frase = Console.ReadLine().ToLower();
            string[] palabras = frase.Split(' ');
            List<string> fraseTraducida = new List<string>();

            foreach (string palabra in palabras)
            {
                string palabraLimpia = palabra.Trim(',', '.', '!', '?', ';'); // Eliminar puntuación
                if (diccionario.ContainsKey(palabraLimpia))
                {
                    fraseTraducida.Add(diccionario[palabraLimpia]);
                }
                else if (diccionario.ContainsValue(palabraLimpia))
                {
                    // Buscar la clave (inglés) de la palabra en español
                    foreach (var par in diccionario)
                    {
                        if (par.Value == palabraLimpia)
                        {
                            fraseTraducida.Add(par.Key);
                            break;
                        }
                    }
                }
                else
                {
                    fraseTraducida.Add(palabra);
                }
            }

            Console.WriteLine("\nSu frase traducida es: " + string.Join(" ", fraseTraducida));
        }

        static void AgregarPalabra()
        {
            Console.Write("\nIngrese la palabra en inglés: ");
            string palabraIngles = Console.ReadLine().ToLower();

            Console.Write("Ingrese la traducción en español: ");
            string palabraEspanol = Console.ReadLine().ToLower();

            if (!diccionario.ContainsKey(palabraIngles))
            {
                diccionario.Add(palabraIngles, palabraEspanol);
                Console.WriteLine("Palabra agregada exitosamente.");
            }
            else
            {
                Console.WriteLine("La palabra ya existe en el diccionario.");
            }
        }
    }
}
