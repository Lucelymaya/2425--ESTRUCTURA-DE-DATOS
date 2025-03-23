using System;

// Clase para representar un nodo del árbol binario
class Nodo
{
    public int Valor; // Valor del nodo (puede ser string, double, etc.)
    public Nodo? Izquierdo; // Referencia al nodo izquierdo (puede ser null)
    public Nodo? Derecho; // Referencia al nodo derecho (puede ser null)

    // Constructor para inicializar un nodo
    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

// Clase para representar el árbol binario
class ArbolBinario
{
    private Nodo? Raiz; // Raíz del árbol (puede ser null)

    // Constructor para inicializar el árbol
    public ArbolBinario()
    {
        Raiz = null;
    }

    // Método para insertar un valor en el árbol
    public void Insertar(int valor)
    {
        Raiz = InsertarRec(Raiz, valor);
    }

    // Método recursivo para insertar un valor
    private Nodo InsertarRec(Nodo? nodo, int valor)
    {
        // Si el nodo es nulo, crear un nuevo nodo
        if (nodo == null)
        {
            nodo = new Nodo(valor);
            return nodo;
        }

        // Si el valor es menor, insertar en el subárbol izquierdo
        if (valor < nodo.Valor)
        {
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        }
        // Si el valor es mayor, insertar en el subárbol derecho
        else if (valor > nodo.Valor)
        {
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);
        }

        return nodo;
    }

    // Método para eliminar un valor del árbol
    public void Eliminar(int valor)
    {
        Raiz = EliminarRec(Raiz, valor);
    }

    // Método recursivo para eliminar un valor
    private Nodo? EliminarRec(Nodo? nodo, int valor)
    {
        // Si el nodo es nulo, no hay nada que eliminar
        if (nodo == null)
        {
            return nodo;
        }

        // Si el valor es menor, buscar en el subárbol izquierdo
        if (valor < nodo.Valor)
        {
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        }
        // Si el valor es mayor, buscar en el subárbol derecho
        else if (valor > nodo.Valor)
        {
            nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        }
        // Si el valor es igual, eliminar el nodo
        else
        {
            // Caso 1: Nodo sin hijos o con un solo hijo
            if (nodo.Izquierdo == null)
            {
                return nodo.Derecho;
            }
            else if (nodo.Derecho == null)
            {
                return nodo.Izquierdo;
            }

            // Caso 2: Nodo con dos hijos
            nodo.Valor = MinValor(nodo.Derecho); // Encontrar el sucesor más cercano
            nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Valor); // Eliminar el sucesor
        }

        return nodo;
    }

    // Método para encontrar el valor mínimo en un subárbol
    private int MinValor(Nodo nodo)
    {
        int minValor = nodo.Valor;
        while (nodo.Izquierdo != null)
        {
            minValor = nodo.Izquierdo.Valor;
            nodo = nodo.Izquierdo;
        }
        return minValor;
    }

    // Método para buscar un valor en el árbol
    public bool Buscar(int valor)
    {
        return BuscarRec(Raiz, valor);
    }

    // Método recursivo para buscar un valor
    private bool BuscarRec(Nodo? nodo, int valor)
    {
        // Si el nodo es nulo, el valor no está en el árbol
        if (nodo == null)
        {
            return false;
        }

        // Si el valor es igual, se encontró
        if (valor == nodo.Valor)
        {
            return true;
        }

        // Si el valor es menor, buscar en el subárbol izquierdo
        if (valor < nodo.Valor)
        {
            return BuscarRec(nodo.Izquierdo, valor);
        }
        // Si el valor es mayor, buscar en el subárbol derecho
        else
        {
            return BuscarRec(nodo.Derecho, valor);
        }
    }

    // Método para recorrer el árbol en Pre-Orden
    public void PreOrden(Nodo? nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreOrden(nodo.Izquierdo);
            PreOrden(nodo.Derecho);
        }
    }

    // Método para recorrer el árbol en In-Orden
    public void InOrden(Nodo? nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InOrden(nodo.Derecho);
        }
    }

    // Método para recorrer el árbol en Post-Orden
    public void PostOrden(Nodo? nodo)
    {
        if (nodo != null)
        {
            PostOrden(nodo.Izquierdo);
            PostOrden(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    // Método para obtener la altura del árbol
    public int Altura(Nodo? nodo)
    {
        if (nodo == null)
        {
            return -1;
        }

        int alturaIzquierda = Altura(nodo.Izquierdo);
        int alturaDerecha = Altura(nodo.Derecho);

        return Math.Max(alturaIzquierda, alturaDerecha) + 1;
    }

    // Método para contar el número de nodos
    public int ContarNodos(Nodo? nodo)
    {
        if (nodo == null)
        {
            return 0;
        }

        return 1 + ContarNodos(nodo.Izquierdo) + ContarNodos(nodo.Derecho);
    }

    // Método para contar el número de hojas
    public int ContarHojas(Nodo? nodo)
    {
        if (nodo == null)
        {
            return 0;
        }

        if (nodo.Izquierdo == null && nodo.Derecho == null)
        {
            return 1;
        }

        return ContarHojas(nodo.Izquierdo) + ContarHojas(nodo.Derecho);
    }

    // Método para obtener la raíz del árbol
    public Nodo? ObtenerRaiz()
    {
        return Raiz;
    }
}

// Programa principal
class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú de Operaciones:");
            Console.WriteLine("1. Insertar un valor");
            Console.WriteLine("2. Eliminar un valor");
            Console.WriteLine("3. Buscar un valor");
            Console.WriteLine("4. Recorrer en Pre-Orden");
            Console.WriteLine("5. Recorrer en In-Orden");
            Console.WriteLine("6. Recorrer en Post-Orden");
            Console.WriteLine("7. Obtener la altura del árbol");
            Console.WriteLine("8. Contar el número de nodos");
            Console.WriteLine("9. Contar el número de hojas");
            Console.WriteLine("10. Salir");
            Console.Write("Seleccione una opción: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el valor a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorInsertar))
                        {
                            arbol.Insertar(valorInsertar);
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida.");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorEliminar))
                        {
                            arbol.Eliminar(valorEliminar);
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorBuscar))
                        {
                            if (arbol.Buscar(valorBuscar))
                            {
                                Console.WriteLine("El valor está en el árbol.");
                            }
                            else
                            {
                                Console.WriteLine("El valor no está en el árbol.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Recorrido en Pre-Orden:");
                        arbol.PreOrden(arbol.ObtenerRaiz());
                        break;

                    case 5:
                        Console.WriteLine("Recorrido en In-Orden:");
                        arbol.InOrden(arbol.ObtenerRaiz());
                        break;

                    case 6:
                        Console.WriteLine("Recorrido en Post-Orden:");
                        arbol.PostOrden(arbol.ObtenerRaiz());
                        break;

                    case 7:
                        Console.WriteLine("Altura del árbol: " + arbol.Altura(arbol.ObtenerRaiz()));
                        break;

                    case 8:
                        Console.WriteLine("Número de nodos: " + arbol.ContarNodos(arbol.ObtenerRaiz()));
                        break;

                    case 9:
                        Console.WriteLine("Número de hojas: " + arbol.ContarHojas(arbol.ObtenerRaiz()));
                        break;

                    case 10:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo.");
            }
        } while (opcion != 10);
    }
}