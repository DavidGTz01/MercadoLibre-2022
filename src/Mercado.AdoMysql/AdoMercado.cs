using et12.edu.ar.AGBD.Ado;
using Mercado.AdoMySQL.Mapeadores;
using Mercado.Core;
using Mercado.Core.Ado;

namespace Mercado.AdoMysql;
public class AdoMercado
{
    public AdoAGBD Ado { get; set; }
    public MapCliente MapCliente { get; set; }
    public MapCompra MapCompra { get; set; }
    public MapProducto MapProducto { get; set; }
    public AdoMercado(AdoAGBD ado)
    {
        Ado = ado;
        MapCliente = new MapCliente(Ado);
        MapCompra = new MapCompra(Ado);
        MapProducto = new MapProducto(Ado);
    }
    public void AltaCliente(Cliente cliente) => MapCliente.altaCliente(cliente);
    public List<Cliente> ObtenerClientes() => MapCliente.ColeccionDesdeTabla();
    public Cliente? ObtenerClientePorId(short idCliente)
    => MapCliente.FiltrarPorPk("idCliente", idCliente);

    public void RegistrarCliente(Cliente cliente) => MapCliente.RegistrarCliente(cliente);
    public List<Cliente> ObtenerClientes() => MapCliente.ColeccionDesdeTabla();
    public void AltaProducto(Producto producto) => MapProducto.AltaProducto(producto);
    public List<Producto> ObtenerProductos() => MapProducto.ColeccionDesdeTabla();
}
