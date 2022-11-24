using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using Mercado.AdoMysql;
using Mercado.Core;

namespace Mercado.AdoMySQL.Mapeadores
{
    public class MapCompra : Mapeador<Compra>
    {
        public MapCliente MapCliente { get; set; }
        public MapProducto MapProducto { get; set; }
        public MapCompra(AdoAGBD ado) : base(ado) => Tabla = "Compra";
        public MapCompra(MapCliente mapCliente, MapProducto mapProducto) : this(mapCliente.AdoAGBD)
        {
            MapCliente = mapCliente;
            MapProducto = mapProducto;
        }
        public override Compra ObjetoDesdeFila(DataRow fila) => new Compra()
        {
            idCompra = Convert.ToUInt16(fila["idCompra"]),
            idProducto = MapProducto.ProductoPorId(Convert.ToUInt16(fila["idProducto"])),
            idCliente = MapCliente.ClientePorId(Convert.ToInt16(fila["idCliente"])),
            unidades = Convert.ToUInt32(fila["unidades"]),
            preciocompra = Convert.ToDecimal(fila["preciocompra"]),
            fechahora = Convert.ToDateTime(fila["fechahora"])
        };
        public List<Compra> ObtenerCompra() => ColeccionDesdeTabla();
        public void AltaCompra(Compra compra)
        {
          EjecutarComandoCon("AltaCompra", ConfigurarAltaCompra, PostAltaCompra, compra);
        }
        public void PostAltaCompra(Compra compra)
        {
          var paramunidcompra = GetParametro("unidCompra");
          compra.idCompra = Convert.ToUInt16(paramunidcompra.Value);
        }
        private void ConfigurarAltaCompra(Compra compra)
        {
            SetComandoSP("AltaCompra");

            BP.CrearParametroSalida("unIdCompra")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .AgregarParametro();

            BP.CrearParametro("unidProducto")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .SetValor(compra.idProducto.idProducto)
              .AgregarParametro();

            BP.CrearParametro("unidCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int16)
              .SetValor(compra.idCliente.idCliente)
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
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.DateTime)
              .SetValor(compra.fechahora)
              .AgregarParametro();
        }
        public Compra CompraPorId(UInt16 id)
          => FiltrarPorPK("idCompra", id);
    }
}