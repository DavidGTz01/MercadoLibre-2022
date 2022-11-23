using Mercado.Core;
using Mercado.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
using Mercado.AdoMysql;
namespace Mercado.AdoTest;
public class ClienteTest1
{
    public AdoMercado Ado { get; set; }
    public ClienteTest1()
    {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoMercado(adoAGBD);
    }
    [Fact]
    public void AltaCLiente()
    {
        var cliente = new Cliente("davi", "tayson", 1149807585, "davi.tay@gmail.com", "peruanop", "puapuapum");
        Ado.AltaCliente(cliente);
        Assert.Equal(6, cliente.idCliente);
    }

    [Theory]
    [InlineData(4, "Matias")]
    public void TraerClientes(ushort idCliente, string nombre)
    {
        var cliente = Ado.ObtenerClientes();
        Assert.Contains(cliente, c => c.idCliente == idCliente && c.nombre == nombre);
    }
}