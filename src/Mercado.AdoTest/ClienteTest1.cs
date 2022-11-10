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
        Ado
    }
}