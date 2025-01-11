using System;
 
namespace RegistroDeProductos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializar matriz de productos con capacidad para 3 elementos
            Producto[] productos = new Producto[3];
 
            // Agregar productos a la matriz
            productos[0] = new Producto(1, "papas", "kg", 1.20m, 1.10m, 0.90m);
            productos[1] = new Producto(2, "yogur", "litro", 0.90m, 0.85m, 0.80m);
            productos[2] = new Producto(3, "aceite", "litro", 1.00m, 0.95m, 0.90m);
 
            // Mostrar información de todos los productos
            foreach (var producto in productos)
            {
                producto.MostrarInformacion();
                Console.WriteLine();
            }
        }
    }
}
