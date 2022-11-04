using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.AdoMySQL.Mapeadores
{
    public class MapCompra : Mapeador<Compra>
    {
        public MapCliente MapCliente { get; set; }
        public MapCompra(AdoAGBD ado) : base(ado) => Tabla = "Compra";
        public MapCompra(MapCliente mapCliente) : this(mapCliente.AdoAGBD)
        {
            MapCliente = mapCliente;
        }
        public MapProducto MapProducto { get; set; }
        public MapCompra(AdoAGBD ado) : base(ado) => Tabla = "Compra";
        public MapCompra(MapProducto mapProducto) : this(mapProducto.AdoAGBD)
        {
            MapProducto = mapProducto;
        }
        public override Compra ObjetoDesdeFila(DataRow fila) => new Compra()
        {
            nombre = fila["nombre"].ToString(),
            cantidad = Convert.ToUInt16(fila["cantidad"]),
            precio = Convert.ToDecimal(fila["precio"]),
            idCliente = MapCliente.ClientePorId(Convert.ToInt16(fila["idCliente"])),
            idProducto = MapProducto.ProductoPorId(Convert.ToUInt16(fila["idProducto"])),
            publicacion = fila["publicacion"].ToDateTime()
        };
    }
}