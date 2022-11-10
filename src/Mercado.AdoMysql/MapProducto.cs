using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using Mercado.AdoMysql;

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
            idCliente = MapCliente.ClientePorId(Convert.ToInt16(fila["idCliente"])),
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
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .SetValor(cliente.idCliente)
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
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .SetValor(producto.Cliente.idCliente)
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
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .SetValor(producto.cantidad)
              .AgregarParametro();

            BP.CrearParametro("unpublicacion")
              .SetTipoDatetime
              .SetValor(producto.publicacion)
              .AgregarParametro();
        }
    }
}

