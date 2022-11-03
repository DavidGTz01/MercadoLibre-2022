using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;

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
                idCliente = Convert.ToUInt16(fila["idCliente"]),
                Nombre = fila["Cliente"].ToString(),
                apellido = fila["Cliente"].ToString(),
                telefono = Convert.ToUInt16(fila["telefono"]),
                email = fila["Cliente"].ToString(),
                usuario = fila["Cliente"].ToString(),
                contraseña = fila["Cliente"].ToString()
            };

        public void AltaCliente(Cliente cliente)
        {
            EjecutarComandoCon("altaCliente", ConfigurarAltaCliente, cliente);
        }
        public void ConfigurarAltaRubro(Cliente cliente)
        {
            SetComandoSP("altaCliente");

            BP.CrearParametroSalida("unIdCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .AgregarParametro();

            BP.CrearParametro("unapellido")
              .SetTipoString
              .SetValor(apellido.Nombre)
              .AgregarParametro();

            BP.CrearParametro("untelefono")
              .SetTipoSmallInt
              .SetValor(untelefono.Nombre)
              .AgregarParametro();

            BP.CrearParametro("unemail")
              .SetTipoString
              .SetValor(unemail.Nombre)
              .AgregarParametro();

            BP.CrearParametro("unusuario")
              .SetTipoString
              .SetValor(unusuario.Nombre)
              .AgregarParametro();

            BP.CrearParametro("uncontrasena")
              .SetTipoString
              .SetValor(uncontrasena.Nombre)
              .AgregarParametro();
        }
        public Cliente ClientePorId(Short idCliente)
        {
            SetComandoSP("ClientePoridCliente");

            BP.CrearParametro("unIdCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Short)
              .SetValor(id)
              .AgregarParametro();

            return ElementoDesdeSP();
        }

        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    }
}