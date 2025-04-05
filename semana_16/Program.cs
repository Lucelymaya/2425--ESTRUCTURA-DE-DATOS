using System;
using System.Collections.Generic;

namespace VuelosEcuador
{
    // Clase que representa un Aeropuerto
    class Aeropuerto
    {
        public string Nombre { get; set; } // Propiedad que almacena el nombre del aeropuerto
        public int Codigo { get; set; }   // Propiedad que almacena el código del aeropuerto (índice en el arreglo)

        // Constructor que inicializa el aeropuerto con su nombre y código
        public Aeropuerto(string nombre, int codigo)
        {
            Nombre = nombre;
            Codigo = codigo;
        }
    }

    class Program
    {
        // Lista de aeropuertos de Ecuador con sus respectivos nombres y códigos
        static List<Aeropuerto> aeropuertos = new List<Aeropuerto>
        {
            new Aeropuerto("Quito (UIO)", 0),
            new Aeropuerto("Guayaquil (GYE)", 1),
            new Aeropuerto("Cuenca (CUE)", 2),
            new Aeropuerto("Galápagos (GPS)", 3),
            new Aeropuerto("Manta (MEC)", 4),
            new Aeropuerto("Loja (LOH)", 5)
        };

        // Matriz de precios de vuelos entre los aeropuertos (grafo ponderado)
        // Si no hay vuelo entre dos aeropuertos, se representa con -1
        static int[,] precios = {
            { 0, 150, 200, 500, 350, 400 }, // Quito (UIO)
            { 150, 0, 250, 600, 450, 500 }, // Guayaquil (GYE)
            { 200, 250, 0, 700, 500, 600 }, // Cuenca (CUE)
            { 500, 600, 700, 0, 850, 800 }, // Galápagos (GPS)
            { 350, 450, 500, 850, 0, 650 }, // Manta (MEC)
            { 400, 500, 600, 800, 650, 0 }  // Loja (LOH)
        };

        // Algoritmo de Dijkstra: Encuentra el camino más barato desde el aeropuerto de origen
        static int[] Dijkstra(int[,] grafo, int origen)
        {
            int n = grafo.GetLength(0); // Número de aeropuertos (nodos)
            int[] distancia = new int[n]; // Arreglo para almacenar las distancias mínimas
            bool[] visitado = new bool[n]; // Arreglo para marcar los aeropuertos visitados

            // Inicialización de las distancias. Al principio, todas las distancias son infinitas (int.MaxValue)
            // excepto la distancia al aeropuerto de origen, que es 0
            for (int i = 0; i < n; i++)
                distancia[i] = int.MaxValue;
            distancia[origen] = 0;

            // Algoritmo de Dijkstra para calcular las distancias mínimas desde el aeropuerto de origen
            for (int i = 0; i < n - 1; i++)
            {
                // Encuentra el aeropuerto no visitado con la distancia más corta
                int u = MinDistancia(distancia, visitado);
                visitado[u] = true; // Marca el aeropuerto u como visitado

                // Relaja las aristas (actualiza las distancias a los aeropuertos vecinos)
                for (int v = 0; v < n; v++)
                {
                    // Si no se ha visitado el aeropuerto v, hay un vuelo entre u y v y se puede relajar la distancia
                    if (!visitado[v] && grafo[u, v] != -1 && distancia[u] != int.MaxValue &&
                        distancia[u] + grafo[u, v] < distancia[v])
                    {
                        // Relajación: Se actualiza la distancia de v si se encuentra un camino más corto
                        distancia[v] = distancia[u] + grafo[u, v];
                    }
                }
            }

            return distancia; // Retorna el arreglo de distancias mínimas
        }

        // Función que encuentra el nodo con la distancia mínima en el grafo no visitado
        static int MinDistancia(int[] dist, bool[] visitado)
        {
            int min = int.MaxValue, minIndex = -1;

            // Busca el aeropuerto con la distancia más corta y que no haya sido visitado aún
            for (int i = 0; i < dist.Length; i++)
            {
                if (!visitado[i] && dist[i] <= min)
                {
                    min = dist[i];
                    minIndex = i;
                }
            }

            return minIndex; // Retorna el índice del aeropuerto con la distancia mínima
        }

        // Función para mostrar los resultados de los vuelos más baratos
        static void MostrarResultados(int[] distancias, int origen)
        {
            Console.WriteLine($"\nResultados desde el aeropuerto {aeropuertos[origen].Nombre}:\n");

            int vueloMasBarato = int.MaxValue; // Variable para almacenar el precio del vuelo más barato
            int destinoMasBarato = -1;         // Variable para almacenar el aeropuerto destino del vuelo más barato

            bool encontradoVuelo = false; // Bandera para saber si hay vuelos disponibles

            // Recorre las distancias calculadas por Dijkstra
            for (int i = 0; i < distancias.Length; i++)
            {
                // Si la distancia es válida y el aeropuerto no es el de origen
                if (distancias[i] != int.MaxValue && i != origen)
                {
                    Console.WriteLine($"Destino: {aeropuertos[i].Nombre}, Precio: {distancias[i]}");

                    // Si encontramos un vuelo más barato, lo guardamos
                    if (distancias[i] < vueloMasBarato)
                    {
                        vueloMasBarato = distancias[i];
                        destinoMasBarato = i;
                    }

                    encontradoVuelo = true; // Se encontró al menos un vuelo
                }
            }

            // Si no se encontraron vuelos, se muestra un mensaje apropiado
            if (!encontradoVuelo)
            {
                Console.WriteLine("No hay vuelos disponibles desde este aeropuerto.");
            }
            else
            {
                // Muestra el vuelo más barato encontrado
                Console.WriteLine($"\nEl vuelo más barato desde {aeropuertos[origen].Nombre} es a {aeropuertos[destinoMasBarato].Nombre} con un precio de {vueloMasBarato}.");
            }
        }

        // Función para leer un número entero del usuario con validación
        static int LeerEntero()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Por favor, ingrese un valor válido.");
                }
                else
                {
                    // Si el input es un número válido y está en el rango de aeropuertos, lo devuelve
                    if (int.TryParse(input, out int result) && result >= 0 && result < aeropuertos.Count)
                        return result;
                    else
                        Console.WriteLine("Valor inválido o fuera de rango. Intente nuevamente.");
                }
            }
        }

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                // Menú de opciones
                Console.WriteLine("\n===== Sistema de Vuelos Ecuador =====");
                Console.WriteLine("1. Buscar Vuelos Baratos (Dijkstra)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = LeerEntero(); // Lee la opción elegida por el usuario

                switch (opcion)
                {
                    case 1:
                        // Muestra los aeropuertos disponibles y sus códigos
                        Console.WriteLine("\nCódigos de Aeropuertos:");
                        for (int i = 0; i < aeropuertos.Count; i++)
                            Console.WriteLine($"{i}: {aeropuertos[i].Nombre}");

                        Console.Write("\nIngrese el código del aeropuerto de origen: ");
                        int origen = LeerEntero(); // Lee el código del aeropuerto de origen

                        // Ejecuta Dijkstra para encontrar los vuelos más baratos desde el aeropuerto de origen
                        int[] resultado = Dijkstra(precios, origen);

                        // Muestra los resultados
                        MostrarResultados(resultado, origen);
                        break;

                    case 0:
                        // Opción de salir
                        Console.WriteLine("Gracias por usar el sistema. ¡Hasta pronto!");
                        break;

                    default:
                        // Opción no válida
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != 0); // Continúa mostrando el menú hasta que el usuario elija salir
        }
    }
}