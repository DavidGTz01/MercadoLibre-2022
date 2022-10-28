using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Core
{
    public class Producto
    {
        public int idProducto { get; set; }
        public short idCliente { get; set; }
        public double precio { get; set; }
        public long cantidad { get; set; }
        public string nombre { get; set; }
        public DateTime publicacion { get; set; }
        public Producto() { }
        public Producto(int idProducto, short idCliente, double precio, long cantidad, string nombre, DateTime publicacion)
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