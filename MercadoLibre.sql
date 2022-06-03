DROP DATABASE IF EXISTS MercaLibre;
CREATE DATABASE IF NOT EXISTS MercaLibre;
USE MercaLibre;

CREATE TABLE Cliente(
idCliente           smallint      NOT NULL,
nombre              varchar (45)  NOT NULL,
apellido            varchar (45)  NOT NULL,
telefono            integer       NOT NULL,
email               varchar (45)  NOT NULL,
usuario             varchar (45)  NOT NULL,
contrasena          char    (100) NOT NULL,
PRIMARY KEY (idCliente)
);
CREATE TABLE Producto(
idProducto          integer       NOT NULL,
idCliente           smallint      NOT NULL,
precio              decimal(7,2)  NOT NULL,
cantidad            bigint        NOT NULL,
nombrepro           varchar (45)  NOT NULL,
publicacion         datetime      NOT NULL,
PRIMARY KEY(idProducto),
CONSTRAINT FK_Producto_Producto FOREIGN KEY (idCliente)
    REFERENCES Cliente(idCliente)
);

CREATE TABLE Compra(
idCompra            integer       NOT NULL,    
idProducto          integer       NOT NULL,
unidades            bigint        NOT NULL,
preciocompra        decimal(7,2)  NOT NULL,
fechahora           datetime      NOT NULL,
PRIMARY KEY (idCompra),
CONSTRAINT FK_Producto_Compra FOREIGN KEY (idProducto)
	REFERENCES Producto(idProducto)
);