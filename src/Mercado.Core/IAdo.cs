using System.Collections.Generic;
using Mercado.Core;

namespace Mercado.Core.Ado
{
    public interface IAdo
    {
        //Acciones para la entidad Cliente
        void AltaCliente(Cliente cliente);
        List<Cliente> ObtenerClientes();
        //Acciones para la entidad Producto
        void AltaProducto(Producto producto);
        List<Producto> ObtenerProductos();
    }
}