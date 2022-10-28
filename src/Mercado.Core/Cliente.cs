﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.AdoMysql;
public class Cliente
{
    public short idCliente { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public int telefono { get; set; }
    public string email { get; set; }
    public string usuario { get; set; }
    public string contrasena { get; set; }
    public Cliente() { }
    public Cliente(short idCliente, string nombre, string apellido, int telefono, string email, string usuario, string contrasena)
    {
        this.idCliente = idCliente;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
        this.email = email;
        this.usuario = usuario;
        this.contrasena = contrasena;
    }
}
