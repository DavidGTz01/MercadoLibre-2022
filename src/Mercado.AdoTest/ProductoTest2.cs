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
        var producto = new Producto(1,Ado.ObtenerClientePorId(1)!,5,3,"yoqse",tiempo);
        Ado.AltaProducto(producto);
        Assert.Equal(2, producto.idProducto);
    }
}
