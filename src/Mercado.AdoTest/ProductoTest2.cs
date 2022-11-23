using Mercado.Core;
using Mercado.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
using Mercado.AdoMysql;
namespace Mercado.AdoTest;
public class ProductoTest2
{
    public AdoMercado Ado {get; set; }
    public ProductoTest2()
    {      
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoMercado(adoAGBD);
    }
    [Fact]
    public void AltaProducto()
    {
        DateTime tiempo = new DateTime(2022,11,17);
        var producto = new Producto(Ado.ObtenerClientePorId(1)!,5,3,"yoqse",tiempo);
        Ado.AltaProducto(producto);
        Assert.Equal(8, producto.idProducto);
    }
    [Theory]
    [InlineData(1)]
    public void TraerProducto(ushort idProducto)
    {
        var Producto = Ado.ObtenerProductos();
        Assert.Contains(Producto, p => p.idProducto == idProducto);
    }
}
