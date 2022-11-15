using et12.edu.ar.AGBD.Ado;
using Mercado.AdoMySQL.Mapeadores;
using Mercado.Core;
using Mercado.Core.Ado;

namespace Mercado.AdoMysql;
public class AdoMercado : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapCliente MapCliente { get; set; }
    public MapCompra MapCompra { get; set; }
    public MapProducto MapProducto { get; set; }
    public AdoMercado(AdoAGBD ado)
    {
        Ado = ado;
        MapCliente = new MapCliente(Ado);
        MapProducto = new MapProducto(MapCliente);
        MapCompra = new MapCompra(MapCliente, MapProducto);
    }
    public void AltaCliente(Cliente cliente) => MapCliente.AltaCliente(cliente);
    public List<Cliente> ObtenerClientes() => MapCliente.ColeccionDesdeTabla();
    public Cliente? ObtenerClientePorId(ushort idCliente)
    => MapCliente.FiltrarPorPK("idCliente", idCliente);

    public void AltaCompra(Compra compra) => MapCompra.AltaCompra(compra);
    public List<Compra> ObtenerCompras() => MapCompra.ColeccionDesdeTabla();

    public void AltaProducto(Producto producto) => MapProducto.AltaProducto(producto);
    public List<Producto> ObtenerProductos() => MapProducto.ColeccionDesdeTabla();
    public Producto? ObtenerProductosPorId(UInt16 idProducto)
    => MapProducto.FiltrarPorPK("idProducto", idProducto);
}
