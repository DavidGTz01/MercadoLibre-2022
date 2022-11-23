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
        public Compra() { }
        public Compra(Producto idProducto, Cliente idCliente, ulong unidades, decimal preciocompra, DateTime fechahora)
        {
            this.idProducto = idProducto;
            this.idCliente = idCliente;
            this.unidades = unidades;
            this.preciocompra = preciocompra;
            this.fechahora = fechahora;
        }
    }
}