-- Realizar los SP para dar de alta todas las entidades recibiendo los parámetros necesarios.
DELIMITER $$
DROP PROCEDURE IF EXISTS AltaCompra $$
CREATE PROCEDURE AltaCompra (unidCompra INTEGER UNSIGNED ,    
       unidProducto INTEGER ,     
       unidCliente SMALLINT , ununidades BIGINT UNSIGNED , unpreciocompra DECIMAL(11,2) , unfechahora DATETIME)
BEGIN 
   INSERT INTO Compra (idCompra,idProducto,idCliente, unidades, preciocompra, fechahora)
      VALUES(unidCompra, unidProducto,unidCliente, ununidades,     
	unpreciocompra, unfechahora);


END $$    

DELIMITER $$
DROP PROCEDURE IF EXISTS AltaCliente $$
CREATE PROCEDURE AltaCliente (unidCliente SMALLINT ,  
    unnombre VARCHAR(45), 
    unapellido VARCHAR(45),
    untelefono INTEGER UNSIGNED,
    unemail VARCHAR(45), 
    unusuario VARCHAR (45), 
    uncontrasena CHAR(45))
BEGIN
   INSERT INTO Cliente (idCliente, nombre, apellido, telefono, email, usuario, contrasena)
      VALUES( unidCliente, unnombre, unapellido, untelefono, unemail, 
	unusuario, SHA2(contrasena,256));
END $$    


DELIMITER $$
DROP PROCEDURE IF EXISTS AltaProducto $$
CREATE PROCEDURE AltaProducto (unidProducto INTEGER UNSIGNED ,
					         unidCliente SMALLINT ,
         unprecio DECIMAL(11,2) ,
         uncantidad BIGINT UNSIGNED ,
         unnombre VARCHAR(45) ,
         unpublicacion DATETIME )
BEGIN
   INSERT INTO Producto (idProducto, idCliente, precio, cantidad, nombre, publicacion)
      VALUES(unidProducto, unidCliente ,unprecio, uncantidad, unnombre, unpublicacion);

END $$    
-- Realizar el SF ‘recaudacionPara’ que reciba por parámetros el identificador de un producto y 2 fechas, la función tiene que devolver la sumatoria de las ventas de ese producto entre esas 2 fechas (inclusive). 

DELIMITER $$
DROP FUNCTION IF EXISTS recaudacionPara $$
CREATE FUNCTION recaudacionPara (unidProducto INTEGER UNSIGNED,
                                                                     cotaSuperior DATETIME,
                                                                     cotaInferior DATETIME)
                                                                  RETURNS FLOAT READS SQL DATA
BEGIN
  DECLARE resultado FLOAT;
  SELECT SUM(preciodecompra * unidades ) INTO resultado
  FROM Compra 
  WHERE idCompra = unidCompra
  AND fechahora BETWEEN cotaInferior AND cotaSuperior; 
   
        RETURN resultado;
END $$

-- Se pide hacer el SP ‘BuscarProducto’ que reciba por parámetro una cadena. El SP tiene que devolver los productos que contengan la cadena en su nombre (Documentación función MATCH-AGAINST).

DELIMITER $$
DROP PROCEDURE IF EXISTS BuscarProducto $$
CREATE PROCEDURE BuscarProducto (nombre VARCHAR (45))
					        			         
BEGIN
 SELECT nombre
 FROM Producto
WHERE  MATCH (nombre) AGAINST (nombre IN boolean mode);
END $$    
-- Realizar el SP ‘VentasDe’ que reciba como parámetro un idUsuario, el SP tiene que devolver todas las columnas de la tabla Compra que pertenezcan al usuario ordenadas por fecha de mayor a menor.
     
DELIMITER $$
DROP PROCEDURE IF EXISTS VentasDe $$
CREATE PROCEDURE VentasDe (unidCliente SMALLINT)

BEGIN
  SELECT CO.idCompra , CO.idProducto, CO.idCliente, CO.unidades, CO.preciocompra,  CO.fechahora 
  FROM Compra CO
  INNER JOIN Producto P ON CO.idProducto = P.idProducto
  WHERE idCliente = unidCliente 
  ORDER BY fechahora DESC;

END $$    

-- Realizar el SP ‘ComprasDe’ que reciba como parámetro un idUsuario, el SP tiene que devolver todas las columnas de la tabla Compra que pertenezcan al usuario ordenadas por fecha de mayor a menor.

DELIMITER $$
DROP PROCEDURE IF EXISTS ComprasDe $$
CREATE PROCEDURE ComprasDe (unidCliente SMALLINT)
          					  
BEGIN
  SELECT CO.idCompra , CO.idProducto , CO.idCliente, CO.unidades, CO.preciocompra,  CO.fechahora
 FROM Compra 
  WHERE idCliente = unidCliente
  ORDER BY fechahora DESC;

END $$    


CALL AltaCliente (30,'Rosaurita', 'Pedraza', '1122334455', 'rosauritapedraza30@gmail.com', 'Rous', 'bangchansit0'); 

CALL AltaCliente (44, 'Evelyn', 'Siles', '1136170568', 'silesevelyn04@gmail.com' ,'Ev3', 'hope225');

CALL AltaCliente (09, 'Magali Lara Aborto','Rodriguez', 1198778890,'maga.rodriguez@gmail.com', 'Maguis', 'magui89');


CALL Altacliente (10,'Matias','Moscoso', 1032547698, 'matimoscoso10@gmail.com', 'Mati', 'matias12345');

CALL Altacliente (15,'David', 'Tay', 9876543210, 'davidtay15@gmail.com' , 'David', 'guevara987');

CALL AltaProducto (111, 10,10500, 5, 'Twice - Álbum Eyes wide open', '2020-09-26 23:59:38');

CALL AltaProducto (135, 10, 9850, 13, 'BTS - Álbum Butter',  '2021-05-21 00:01:05');

CALL AltaProducto (190, 10, 11000 , 1, ' Stray Kids - Álbum Circus' , '2022-03 -06 00:00:11');

CALL Alta Producto (227, 15,14000, 8, 'Seventeen - Light Stick CARAT Bong Original', '2020-12-21 12:02:49' );

CALL Alta Producto (211, 15, 18000, 17, 'BlackPink- Bl-ping-bong Original', '2020-05-28 00:00:17');

CALL AltaProducto (235, 15, 15000, 10, 'Twice - Light Stick Candy Bong Z Original Bluetooth', '2021-12-15 12:05:31');

CALL AltaProducto (372, 09,1800,1, 'Seventeen - PhotoCard Vernon Original', '2021-02- 01 13:04:53' );

CALL AltaCompra (418, 111, 30, 1, 10500, '2022-04- 01 23:28:22');

CALL AltaCompra (421, 235, 30, 2, 30000, '2022-04- 01 23:35:19');

CALL AltaCompra (421, 211, 30, 1, 18000, '2022-04- 01 23:41:13');

CALL AltaCompra ( 442 , 111, 44, 1, 10500, '2022-04-04 09:30:59');

CALL AltaCompra (444, 227, 44, 1, 14000, '2022-04- 04 09:39:11');

CALL AltaCompra (450, 372, 44,1 , 1800, '2022-04- 04 09:53:26');

CALL AltaCompra (453,190, 44,1 , 11000, '2022-04- 04 09:59:24');

CALL AltaCompra (497, 135, 09, 1, 9850, '2022-04-08 17:35:47');

CALL AltaCompra (500, 211, 09, 2, 36000, '2022-04-08 17:40:05');

CALL AltaCompra (502, 190 , 09, 1, 11000, '2022-04-08 17:44:03');

