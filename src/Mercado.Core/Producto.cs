using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Core
{
    public class Producto
    {
        public uint idProducto { get; set; }
        public Cliente Cliente { get; set; }
        public decimal precio { get; set; }
        public ulong cantidad { get; set; }
        public string nombre { get; set; }
        public DateTime publicacion { get; set; }
        public override string ToString()
        => $"{nombre} - {Cliente.nombre} - Cantidad: {cantidad} - ${precio:0.00}c/u - Publicacion: {publicacion}";
    }
}
