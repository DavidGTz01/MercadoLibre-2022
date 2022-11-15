using System.Collections.Generic;
using Mercado.Core;

namespace Mercado.Core.Ado
{
    public interface IAdo
    {
        //Acciones para la entidad Cliente
        void AltaCliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
        Cliente? ObtenerClientePorId(ushort idHotel);

        //Acciones para la entidad Producto
        void AltaProducto(Producto producto);
        List<Producto> ObtenerProductos();
        Producto? ObtenerProductosPorId(UInt16 idProducto);

        //Acciones para la entidad Compra
        void AltaCompra(Compra compra);
        List<Compra> ObtenerCompras();
    }
}