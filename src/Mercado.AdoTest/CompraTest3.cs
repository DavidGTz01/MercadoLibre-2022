using Mercado.Core;
using Mercado.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
using Mercado.AdoMysql;
namespace Mercado.AdoTest;
public class CompraTest3
{
    public AdoMercado Ado { get; set; }
    public CompraTest3()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoMercado(adoAGBD);
    }
    [Fact]
    public void AltaCompra()
    {

        DateTime hora = new DateTime(2022, 11, 23);
        var compra = new Compra(Ado.ObtenerProductosPorId(1), Ado.ObtenerClientePorId(1), 1, 2, hora);
        Ado.AltaCompra(compra);
        Assert.Equal((uint)11, compra.idCompra);
    }

    [Theory]
    [InlineData(1)]
    public void TraerCompras(ushort idCompra)
    {
        var compras = Ado.ObtenerCompras();
        Assert.Contains(compras, c => c.idCompra == idCompra);
    }
}