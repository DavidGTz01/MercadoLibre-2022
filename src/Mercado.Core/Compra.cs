using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Core
{
    public class Compra
    {
        public int idCompra { get; set; }
        public int idProducto { get; set; }
        public int idCliente { get; set; }
        public int unidades { get; set; }
        public decimal preciocompra { get; set; }
        public DateTime fechahora { get; set; }
        public Compra() { }
        public Compra(int idCompra, int idProducto, int idCliente, int unidades, decimal preciocompra, DateTime fechahora)
        {
            this.idCompra = idCompra;
            this.idProducto = idProducto;
            this.idCliente = idCliente;
            this.unidades = unidades;
            this.preciocompra = preciocompra;
            this.fechahora = fechahora;
        }

    }
}