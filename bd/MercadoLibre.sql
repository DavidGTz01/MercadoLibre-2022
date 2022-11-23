-- Active: 1646654372192@@127.0.0.1@3306@mercalibre

DROP DATABASE IF EXISTS MercaLibre;

CREATE DATABASE IF NOT EXISTS MercaLibre;

USE MercaLibre;

CREATE TABLE
    Cliente(
        idCliente smallint NOT NULL auto_increment UNIQUE ,
        nombre varchar (45) NOT NULL,
        apellido varchar (45) NOT NULL,
        telefono integer NOT NULL,
        email varchar (45) NOT NULL,
        usuario varchar (45) NOT NULL,
        contrasena char (100) NOT NULL,
        PRIMARY KEY (idCliente)
    );

CREATE TABLE
    Producto(
        idProducto integer NOT NULL auto_increment,
        idCliente smallint NOT NULL,
        precio decimal(11, 2) NOT NULL,
        cantidad bigint NOT NULL,
        nombre varchar (45) NOT NULL,
        publicacion datetime NOT NULL,
        FULLTEXT (nombre),
        PRIMARY KEY(idProducto),
        CONSTRAINT FK_Producto_Producto FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente),
        FULLTEXT (nombre)
    );

CREATE TABLE
    Compra(
        idCompra integer NOT NULL auto_increment,
        idProducto integer NOT NULL,
        idCliente smallint NOT NULL,
        unidades bigint NOT NULL,
        preciocompra decimal(11, 2) NOT NULL,
        fechahora datetime NOT NULL,
        PRIMARY KEY (idCompra),
        CONSTRAINT FK_Producto_Compra FOREIGN KEY (idProducto) REFERENCES Producto(idProducto),
        CONSTRAINT FK_Producto_idCliente FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente)
    );