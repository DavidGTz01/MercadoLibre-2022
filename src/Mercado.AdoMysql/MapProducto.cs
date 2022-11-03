using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.AdoMySQL.Mapeadores
{
    public class MapProducto : Mapeador<Producto>
    {
        public MapCliente MapCliente { get; set; }
        public MapProducto(AdoAGBD ado) : base(ado) => Tabla = "Producto";
        public MapProducto(MapCliente mapCliente) : this(mapCliente.AdoAGBD)
        {
            MapCliente = mapCliente;
        }
        public override Producto ObjetoDesdeFila(DataRow fila) => new Producto()
        {
            nombre = fila["nombre"].ToString(),
            cantidad = Convert.ToUInt16(fila["cantidad"]),
            precio = Convert.ToDecimal(fila["precio"]),
            Cliente = MapCliente.ClientePorId(Convert.ToInt16(fila["idCliente"])),
            idProducto = Convert.ToUInt16(fila["idProducto"]),
            publicacion = fila["publicacion"].ToDateTime()
        };
        public List<Producto> ObtenerProductos()
        {
            ColeccionDesdeTabla();
        }
        public List<Producto> ObtenerProductos(Cliente cliente)
        {
            SetComandoSP("ProductosPorCliente");

            BP.CrearParametro("unidCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Short)
              .SetValor(cliente.Id)
              .AgregarParametro();

            return ColeccionDesdeSP();
        }

        public void AltaProducto(Producto producto)
        {
            EjecutarComandoCon("altaProducto", ConfigurarAltaProducto, producto);
        }

        private void ConfigurarAltaProducto(Producto producto)
        {
            SetComandoSP("altaProducto");

            BP.CrearParametroSalida("unIdProducto")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .AgregarParametro();

            BP.CrearParametro("unidCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
              .SetValor(producto.Cliente.Id)
              .AgregarParametro();

            BP.CrearParametro("unnombre")
              .SetTipoVarchar(45)
              .SetValor(producto.nombre)
              .AgregarParametro();

            BP.CrearParametro("unprecio")
              .SetTipoDecimal(11, 2)
              .SetValor(producto.precio)
              .AgregarParametro();

            BP.CrearParametro("uncantidad")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Ulong)
              .SetValor(producto.cantidad)
              .AgregarParametro();

            BP.CrearParametro("unpublicacion")
              .SetTipoDATETIME
              .SetValor(producto.publicacion)
              .AgregarParametro();
        }
    }
}

