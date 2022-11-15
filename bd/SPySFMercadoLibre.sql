-- Active: 1646654372192@@127.0.0.1@3306@mercalibre
-- Realizar los SP para dar de alta todas las entidades recibiendo los parámetros necesarios.

DELIMITER $$

DROP PROCEDURE
    IF EXISTS AltaCompra $$
CREATE PROCEDURE
    AltaCompra (
        unidCompra INTEGER UNSIGNED,
        unidProducto INTEGER UNSIGNED,
        unidCliente SMALLINT,
        ununidades BIGINT UNSIGNED,
        unpreciocompra DECIMAL(11, 2),
        unfechahora DATETIME
    ) BEGIN
INSERT INTO
    Compra (
        idCompra,
        idProducto,
        idCliente,
        unidades,
        preciocompra,
        fechahora
    )
VALUES
(
        unidCompra,
        unidProducto,
        unidCliente,
        ununidades,
        unpreciocompra,
        unfechahora
    );

END $$ 

DELIMITER $$

DROP PROCEDURE
    IF EXISTS AltaCliente $$
CREATE PROCEDURE
    AltaCliente(
        unidCliente SMALLINT,
        unnombre VARCHAR(45),
        unapellido VARCHAR(45),
        untelefono INTEGER UNSIGNED,
        unemail VARCHAR(45),
        unusuario VARCHAR (45),
        uncontrasena CHAR(45)
    ) BEGIN
INSERT INTO
    Cliente (
        idCliente,
        nombre,
        apellido,
        telefono,
        email,
        usuario,
        contrasena
    )
VALUES
(
        unidCliente,
        unnombre,
        unapellido,
        untelefono,
        unemail,
        unusuario,
        SHA2(contrasena, 256)
    );

END $$ 

DELIMITER $$

DROP PROCEDURE
    IF EXISTS AltaProducto $$
CREATE PROCEDURE
    AltaProducto (
        unidProducto INTEGER UNSIGNED,
        unidCliente SMALLINT,
        unprecio DECIMAL(11, 2),
        uncantidad BIGINT UNSIGNED,
        unnombre VARCHAR(45),
        unpublicacion DATETIME
    ) BEGIN
INSERT INTO
    Producto (
        idProducto,
        idCliente,
        precio,
        cantidad,
        nombre,
        publicacion
    )
VALUES
(
        unidProducto,
        unidCliente,
        unprecio,
        uncantidad,
        unnombre,
        unpublicacion
    );

END $$ -- Realizar el SF ‘recaudacionPara’ que reciba por parámetros el identificador de un producto y 2 fechas, la función tiene que devolver la sumatoria de las ventas de ese producto entre esas 2 fechas (inclusive).

DELIMITER $$

DROP FUNCTION
    IF EXISTS recaudacionPara $$
CREATE FUNCTION
    recaudacionPara (
        unidProducto INTEGER UNSIGNED,
        cotaSuperior DATETIME,
        cotaInferior DATETIME
    ) RETURNS FLOAT READS SQL DATA BEGIN DECLARE resultado FLOAT;

SELECT
    SUM(preciodecompra * unidades) INTO resultado
FROM Compra
WHERE
    idCompra = unidCompra
    AND fechahora BETWEEN cotaInferior AND cotaSuperior;

RETURN resultado;

END $$ -- Se pide hacer el SP ‘BuscarProducto’ que reciba por parámetro una cadena. El SP tiene que devolver los productos que contengan la cadena en su nombre (Documentación función MATCH-AGAINST).

DELIMITER $$

DROP PROCEDURE
    IF EXISTS BuscarProducto $$
CREATE PROCEDURE
    BuscarProducto (nombre VARCHAR (45)) BEGIN
SELECT nombre
FROM Producto
WHERE
    MATCH (nombre) AGAINST (nombre IN boolean mode);

END $$ -- Realizar el SP ‘VentasDe’ que reciba como parámetro un idUsuario, el SP tiene que devolver todas las columnas de la tabla Compra que pertenezcan al usuario ordenadas por fecha de mayor a menor.

DELIMITER $$

DROP PROCEDURE
    IF EXISTS VentasDe $$
CREATE PROCEDURE
    VentasDe (unidCliente SMALLINT) BEGIN
SELECT
    CO.idCompra,
    CO.idProducto,
    CO.idCliente,
    CO.unidades,
    CO.preciocompra,
    CO.fechahora
FROM Compra CO
    INNER JOIN Producto P ON CO.idProducto = P.idProducto
WHERE idCliente = unidCliente
ORDER BY fechahora DESC;

END $$ -- Realizar el SP ‘ComprasDe’ que reciba como parámetro un idUsuario, el SP tiene que devolver todas las columnas de la tabla Compra que pertenezcan al usuario ordenadas por fecha de mayor a menor.

DELIMITER $$

DROP PROCEDURE
    IF EXISTS ComprasDe $$
CREATE PROCEDURE
    ComprasDe (unidCliente SMALLINT) BEGIN
SELECT
    CO.idCompra,
    CO.idProducto,
    CO.idCliente,
    CO.unidades,
    CO.preciocompra,
    CO.fechahora
FROM Compra
WHERE
    idCliente = unidCliente
ORDER BY fechahora DESC;

END $$
