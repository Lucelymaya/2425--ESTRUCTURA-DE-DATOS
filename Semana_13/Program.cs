using System;

// Clase para representar un nodo del árbol binario
class Nodo
{
    public string Titulo; // Título de la revista
    public Nodo? Izquierdo; // Referencia al nodo izquierdo (puede ser null)
    public Nodo? Derecho; // Referencia al nodo derecho (puede ser null)

    // Constructor para inicializar un nodo
    public Nodo(string titulo)
    {
        Titulo = titulo;
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

    // Método para insertar un título en el árbol
    public void Insertar(string titulo)
    {
        Raiz = InsertarRec(Raiz, titulo);
    }

    // Método recursivo para insertar un título
    private Nodo InsertarRec(Nodo? nodo, string titulo)
    {
        // Si el nodo es nulo, crear un nuevo nodo
        if (nodo == null)
        {
            nodo = new Nodo(titulo);
            return nodo;
        }

        // Si el título es menor, insertar en el subárbol izquierdo
        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, titulo);
        }
        // Si el título es mayor, insertar en el subárbol derecho
        else if (string.Compare(titulo, nodo.Titulo) > 0)
        {
            nodo.Derecho = InsertarRec(nodo.Derecho, titulo);
        }

        return nodo;
    }

    // Método para buscar un título en el árbol
    public bool Buscar(string titulo)
    {
        return BuscarRec(Raiz, titulo);
    }

    // Método recursivo para buscar un título
    private bool BuscarRec(Nodo? nodo, string titulo)
    {
        // Si el nodo es nulo, el título no está en el árbol
        if (nodo == null)
        {
            return false;
        }

        // Si el título es igual, se encontró
        if (string.Compare(titulo, nodo.Titulo) == 0)
        {
            return true;
        }

        // Si el título es menor, buscar en el subárbol izquierdo
        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            return BuscarRec(nodo.Izquierdo, titulo);
        }
        // Si el título es mayor, buscar en el subárbol derecho
        else
        {
            return BuscarRec(nodo.Derecho, titulo);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un árbol binario
        ArbolBinario arbol = new ArbolBinario();

        // Lista de 10 títulos de revistas
        string[] titulos = {
            "Revista Ciencia Hoy",
            "Revista un dia a la vez",
            "Revista de Tecnología",
            "Investigación y Ciencia",
            "Estilo de vida y Cultura",
            "Revista Innovación",
            "Tecnologia y Futuro",
            "Innovación y Desarollo",
            "Electrónica Hoy",
            "Revista Digital"
        };

        // Insertar los títulos en el árbol binario
        foreach (string titulo in titulos)
        {
            arbol.Insertar(titulo);
        }

        int opcion;
        do
        {
            // Mostrar el menú
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string? input = Console.ReadLine();

            // Validar la entrada del usuario
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        // Buscar un título
                        Console.Write("Ingrese el título a buscar: ");
                        string? tituloBuscado = Console.ReadLine();
                        if (!string.IsNullOrEmpty(tituloBuscado))
                        {
                            if (arbol.Buscar(tituloBuscado))
                            {
                                Console.WriteLine("Título encontrado.");
                            }
                            else
                            {
                                Console.WriteLine("Título no encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El título no puede estar vacío.");
                        }
                        break;

                    case 2:
                        // Salir del programa
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
        } while (opcion != 2);
    }
}