using System;
 
namespace RegistroDeProductos
{
    public class Producto
    {
        // Propiedades
        public int Id { get; set; }  // Identificador único del producto
        public string Nombre { get; set; }  // Nombre del producto
        public string Unidad { get; set; }  // Unidad de medida (ej. "kg", "pieza")
        public decimal PrecioBase { get; set; }  // Precio base del producto
        public decimal PrecioMayorista { get; set; }  // Precio para mayoristas
        public decimal PrecioOferta { get; set; }  // Precio en oferta
 
        // Constructor
        public Producto(int id, string nombre, string unidad, decimal precioBase, decimal precioMayorista, decimal precioOferta)
        {
            Id = id;
            Nombre = nombre;
            Unidad = unidad;
            PrecioBase = precioBase;
            PrecioMayorista = precioMayorista;
            PrecioOferta = precioOferta;
        }
 
        // Método para mostrar información del producto
        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}\nNombre: {Nombre}\nUnidad: {Unidad}  Precio Base: {PrecioBase}  Precio Mayorista: {PrecioMayorista}  Precio Oferta: {PrecioOferta}");
        }
    }
}