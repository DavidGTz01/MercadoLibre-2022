using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using Mercado.AdoMysql;

namespace Mercado.AdoMySQL.Mapeadores
{
    public class MapCliente : Mapeador<Cliente>
    {
        public MapCliente(AdoAGBD ado) : base(ado)
        {
            Tabla = "Cliente";
        }
        public override Cliente ObjetoDesdeFila(DataRow fila)
            => new Cliente()
            {
                idCliente = Convert.ToInt16(fila["idCliente"]),
                nombre = fila["nombre"].ToString(),
                apellido = fila["apellido"].ToString(),
                telefono = Convert.ToUInt16(fila["telefono"]),
                email = fila["email"].ToString(),
                usuario = fila["usuario"].ToString(),
                contrasena = fila["contrasena"].ToString()
            };

        public void AltaCliente(Cliente cliente)
        {
            EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, cliente);
        }
        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametroSalida("unIdCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .AgregarParametro();

            BP.CrearParametro("unapellido")
              .SetTipoVarchar(45)
              .SetValor(cliente.apellido)
              .AgregarParametro();

            BP.CrearParametro("untelefono")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt32)
              .SetValor(cliente.telefono)
              .AgregarParametro();

            BP.CrearParametro("unemail")
              .SetTipoVarchar(45)
              .SetValor(cliente.email)
              .AgregarParametro();

            BP.CrearParametro("unusuario")
              .SetTipoVarchar(45)
              .SetValor(cliente.usuario)
              .AgregarParametro();

            BP.CrearParametro("uncontrasena")
              .SetTipoChar(45)
              .SetValor(cliente.contrasena)
              .AgregarParametro();
        }
        public Cliente? ClientePorId(short idCliente)
          => FiltrarPorPK("idCliente", idCliente);

        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    }
}