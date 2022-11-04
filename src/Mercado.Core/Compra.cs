using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Core
{
    public class Compra
    {
        public uint idCompra { get; set; }
        public Producto idProducto { get; set; }
        public Cliente idCliente { get; set; }
        public ulong unidades { get; set; }
        public decimal preciocompra { get; set; }
        public DateTime fechahora { get; set; }
        public override string ToString()
        => $" {idCliente.nombre} - Unidades: {unidades} - ${preciocompra:0.00}c/u - fecha y hora: {fechahora}";
    }
}