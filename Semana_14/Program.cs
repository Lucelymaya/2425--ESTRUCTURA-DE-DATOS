using System;

namespace GestionInventario
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public Producto(int id, string nombre, int cantidad)
        {
            Id = id;
            Nombre = nombre;
            Cantidad = cantidad;
        }
    }

    public class NodoInventario
    {
        public Producto Producto { get; set; }
        public NodoInventario? Izquierdo { get; set; }
        public NodoInventario? Derecho { get; set; }

        public NodoInventario(Producto producto) => Producto = producto;
    }

    public class ArbolInventario
    {
        private NodoInventario? Raiz { get; set; }

        // Insertar producto por ID
        public void AgregarProducto(Producto producto) => Raiz = InsertarRec(Raiz, producto);
        
        private NodoInventario InsertarRec(NodoInventario? nodo, Producto producto)
        {
            if (nodo == null) return new NodoInventario(producto);
            
            if (producto.Id < nodo.Producto.Id)
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, producto);
            else if (producto.Id > nodo.Producto.Id)
                nodo.Derecho = InsertarRec(nodo.Derecho, producto);
            
            return nodo;
        }

        // Eliminar producto por ID
        public void EliminarProducto(int id) => Raiz = EliminarRec(Raiz, id);
        
        private NodoInventario? EliminarRec(NodoInventario? nodo, int id)
        {
            if (nodo == null) return null;

            if (id < nodo.Producto.Id) nodo.Izquierdo = EliminarRec(nodo.Izquierdo, id);
            else if (id > nodo.Producto.Id) nodo.Derecho = EliminarRec(nodo.Derecho, id);
            else
            {
                if (nodo.Izquierdo == null) return nodo.Derecho;
                if (nodo.Derecho == null) return nodo.Izquierdo;

                nodo.Producto = MinProducto(nodo.Derecho);
                nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Producto.Id);
            }
            return nodo;
        }

        // Buscar producto por ID
        public Producto? BuscarProducto(int id) => BuscarRec(Raiz, id);
        
        private Producto? BuscarRec(NodoInventario? nodo, int id)
        {
            if (nodo == null) return null;
            if (id == nodo.Producto.Id) return nodo.Producto;
            
            return id < nodo.Producto.Id ? 
                BuscarRec(nodo.Izquierdo, id) : 
                BuscarRec(nodo.Derecho, id);
        }

        // Recorridos del inventario
        public void ListarPreOrden(NodoInventario? nodo)
        {
            if (nodo == null) return;
            MostrarProducto(nodo);
            ListarPreOrden(nodo.Izquierdo);
            ListarPreOrden(nodo.Derecho);
        }

        public void ListarInOrden(NodoInventario? nodo)
        {
            if (nodo == null) return;
            ListarInOrden(nodo.Izquierdo);
            MostrarProducto(nodo);
            ListarInOrden(nodo.Derecho);
        }

        public void ListarPostOrden(NodoInventario? nodo)
        {
            if (nodo == null) return;
            ListarPostOrden(nodo.Izquierdo);
            ListarPostOrden(nodo.Derecho);
            MostrarProducto(nodo);
        }

        private Producto MinProducto(NodoInventario nodo)
        {
            while (nodo.Izquierdo != null) nodo = nodo.Izquierdo;
            return nodo.Producto;
        }

        public NodoInventario? ObtenerRaiz() => Raiz;

        private void MostrarProducto(NodoInventario nodo)
        {
            Console.WriteLine($"ID: {nodo.Producto.Id} | {nodo.Producto.Nombre} | Stock: {nodo.Producto.Cantidad}");
        }
    }

    public static class MenuInventario
    {
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("SISTEMA DE GESTIÓN DE INVENTARIO");
            Console.WriteLine("1. Agregar nuevo producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Buscar producto");
            Console.WriteLine("4. Listar productos (Pre-Orden)");
            Console.WriteLine("5. Listar productos (In-Orden)");
            Console.WriteLine("6. Listar productos (Post-Orden)");
            Console.WriteLine("7. Salir");
            Console.Write("Selección: ");
        }

        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor)) break;
                Console.WriteLine("¡Entrada inválida! Intente nuevamente");
            }
            return valor;
        }

        public static string LeerCadena(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine() ?? string.Empty;
        }
    }

    class Program
    {
        static void Main()
        {
            var inventario = new ArbolInventario();
            int opcion;

            do
            {
                MenuInventario.MostrarMenu();
                opcion = MenuInventario.LeerEntero("");

                switch (opcion)
                {
                    case 1:
                        var id = MenuInventario.LeerEntero("ID del producto: ");
                        var nombre = MenuInventario.LeerCadena("Nombre: ");
                        var cantidad = MenuInventario.LeerEntero("Cantidad en stock: ");
                        inventario.AgregarProducto(new Producto(id, nombre, cantidad));
                        Console.WriteLine("¡Producto agregado!");
                        Console.ReadKey();
                        break;

                    case 2:
                        var idEliminar = MenuInventario.LeerEntero("ID a eliminar: ");
                        inventario.EliminarProducto(idEliminar);
                        Console.WriteLine("Operación completada");
                        Console.ReadKey();
                        break;

                    case 3:
                        var idBuscar = MenuInventario.LeerEntero("ID a buscar: ");
                        var producto = inventario.BuscarProducto(idBuscar);
                        Console.WriteLine(producto != null ? 
                            $"Encontrado: {producto.Nombre} (Stock: {producto.Cantidad})" : 
                            "Producto no registrado");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("\nInventario (Pre-Orden):");
                        inventario.ListarPreOrden(inventario.ObtenerRaiz());
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("\nInventario (In-Orden):");
                        inventario.ListarInOrden(inventario.ObtenerRaiz());
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("\nInventario (Post-Orden):");
                        inventario.ListarPostOrden(inventario.ObtenerRaiz());
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 7);
        }
    }
}