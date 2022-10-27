using System.Collections.Generic;
using Mercado.Core;

namespace Mercado.Core.Ado
{
    public interface IAdo
    {
        void AltaCliente(Cliente cliente);
        List<Cliente> ObtenerClientes();

        void AltaCompra(Compra compra);
        List<Compra> ObtenerCompras();

        void AltaProducto(Producto producto);
        List<Producto> ObtenerProductos();
    }
}