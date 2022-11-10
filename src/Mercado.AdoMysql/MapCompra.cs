using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using Mercado.AdoMysql;

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
            idCompra = Convert.ToUInt16(fila["idCompra"]),
            idProducto = MapProducto.ProductoPorId(Convert.ToUInt16(fila["idProducto"])),
            idCliente = MapCliente.ClientePorId(Convert.ToInt16(fila["idCliente"])),
            unidades = Convert.ToUInt32(fila["unidades"]),
            preciocompra = Convert.ToDecimal(fila["preciocompra"]),
            fechahora = fila["fecha y hora"].ToDateTime()
        };
        public List<Compra> ObtenerCompra()
        {
            ColeccionDesdeTabla();
        }
        public List<Compra> ObtenerCompra(Cliente cliente)
        {
            SetComandoSP("CompraPorCliente");

            BP.CrearParametro("unidCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Short)
              .SetValor(cliente.idCliente)
              .AgregarParametro();

            return ColeccionDesdeSP();
        }
        public List<Compra> ObtenerCompra(Producto producto)
        {
            SetComandoSP("CompraPorProducto");

            BP.CrearParametro("unidProducto")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .SetValor(producto.idProducto)
              .AgregarParametro();

            return ColeccionDesdeSP();
        }
        public void AltaCompra(Compra compra)
        {
            EjecutarComandoCon("altaCompra", ConfigurarAltaCompra, compra);
        }
        private void ConfigurarAltaCompra(Compra compra)
        {
            SetComandoSP("altaCompra");

            BP.CrearParametroSalida("unIdCompra")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .AgregarParametro();

            BP.CrearParametro("unidProducto")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .SetValor(compra.Cliente.idProducto)
              .AgregarParametro();

            BP.CrearParametro("unidCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .SetValor(compra.Cliente.idCliente)
              .AgregarParametro();

            BP.CrearParametro("ununidades")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .SetValor(compra.unidades)
              .AgregarParametro();

            BP.CrearParametro("unpreciocompra")
              .SetTipoDecimal(11, 2)
              .SetValor(compra.preciocompra)
              .AgregarParametro();

            BP.CrearParametro("unfechahora")
              .SetTipoDatetime
              .SetValor(compra.fechahora)
              .AgregarParametro();
        }
    }
}