﻿using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using Mercado.AdoMysql;
using Mercado.Core;

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
                nombre = fila["nombre"].ToString(),
                apellido = fila["apellido"].ToString(),
                telefono = Convert.ToUInt32(fila["telefono"]),
                email = fila["email"].ToString(),
                usuario = fila["usuario"].ToString(),
                contrasena = fila["contrasena"].ToString(),
                idCliente = Convert.ToUInt16(fila["idCliente"])
            };

        public void AltaCliente(Cliente cliente)
        {
            EjecutarComandoCon("AltaCliente", ConfigurarAltaCliente,PostAltaCliente, cliente);
        }

        public void PostAltaCliente(Cliente cliente)
        {
          var paramunidCliente = GetParametro("unidCliente");
          cliente.idCliente = Convert.ToUInt16(paramunidCliente.Value);
        }
        public void ConfigurarAltaCliente(Cliente cliente)
        {
            SetComandoSP("AltaCliente");

            BP.CrearParametroSalida("unidCliente")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UInt16)
              .SetValor(cliente.idCliente)
              .AgregarParametro();

            BP.CrearParametro("unnombre")
              .SetTipoVarchar(45)
              .SetValor(cliente.nombre)
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
        public Cliente ClientePorId(Int16 id)
          => FiltrarPorPK("idCliente", id);
        public List<Cliente> ObtenerClientes() => ColeccionDesdeTabla();
    }
}