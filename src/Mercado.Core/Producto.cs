using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Core
{
    public class Producto
    {
        public int idProducto { get; set; }
        public int idCliente { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public DateTime publicacion { get; set; }
        public Producto() { }
        public Producto(int idProducto, int idCliente, decimal precio, int cantidad, string nombre, DateTime publicacion)
        {
            this.idProducto = idProducto;
            this.idCliente = idCliente;
            this.precio = precio;
            this.cantidad = cantidad;
            this.nombre = nombre;
            this.publicacion = publicacion;
        }
    }
}