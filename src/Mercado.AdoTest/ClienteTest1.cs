using Mercado.Core;
using Mercado.AdoMySQL;
using et12.edu.ar.AGBD.Ado;
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
        var cliente = new Cliente(2, "davi", "tayson", 1149807585, "davi.tay@gmail.com", "peruanop", "puapuapum");
        Ado.RegistrarCliente(cliente);
        Assert.Equal(2, cliente.idCliente);
    }

    [Theory]
    [InlineData(1, "Pedro")]
    public void TraerClientes(short idCliente, string nombre)
    {
        var cliente = Ado.ObtenerClientes();
        Assert.Contains(cliente, c => c.idCliente == idCliente && c.nombre == nombre);
    }
}