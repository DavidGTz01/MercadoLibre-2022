
SET @idR = NULL;
CALL AltaCliente (@idR,'Rosaurita','Pedraza',1122334455,'rosauritapedraza30@gmail.com','Rous','bangchansit0');

SET @idE = NULL;
CALL AltaCliente (@idE,'Evelyn','Siles',1136170568,'silesevelyn04@gmail.com','Ev3','hope225');

SET @idM = NULL;
CALL AltaCliente (@idM,'Magali Lara Aborto','Rodriguez',1198778890,'maga.rodriguez@gmail.com','Maguis','magui89');

SET @idELMATI = NULL;
CALL Altacliente (@idELMATI,'Matias','Moscoso',1032547698,'matimoscoso10@gmail.com','Mati','matias12345');

SET @idfers = NULL;
CALL Altacliente (@idfers,'David','Tay',1000000000, 'davidtay15@gmail.com','David','guevara987'); -- 9876543210 valor largoooo




SET @idProducto1 = NULL;
CALL AltaProducto (@idProducto1,1,10500,5,'Twice - Álbum Eyes wide open','2020-09-26 23:59:38');

SET @idProducto2 = NULL;
CALL AltaProducto (@idProducto2,2,9850,13,'BTS - Álbum Butter','2021-05-21 00:01:05');

SET @idProducto3 = NULL;
CALL AltaProducto (@idProducto3,3,11000,1,' Stray Kids - Álbum Circus','2022-03-06 00:00:11');

SET @idProducto4 = NULL;
CALL AltaProducto (@idProducto4,4,14000,8,'Seventeen - Light Stick CARAT Bong Original','2020-12-21 12:02:49');

SET @idProducto5 = NULL;
CALL AltaProducto (@idProducto5,5,18000,17,'BlackPink- Bl-ping-bong Original','2020-05-28 00:00:17');

SET @idProducto6 = NULL;
CALL AltaProducto (@idProducto6,1,15000,10,'Twice - Light Stick', '2021-12-15 12:05:31');

SET @idProducto7 = NULL;
CALL AltaProducto (@idProducto7,2,1800,1,'Seventeen - PhotoCard Vernon Original','2021-02-01 13:04:53');




SET @idCompra1 = NULL;
CALL AltaCompra (@idCompra1, 1, 1, 1, 10500, '2022-04-01 23:28:22');

SET @idCompra2 = NULL;
CALL AltaCompra (@idCompra2, 2, 1, 2, 30000, '2022-04-01 23:35:19');

SET @idCompra3 = NULL;
CALL AltaCompra (@idCompra3, 3, 1, 1, 18000, '2022-04-01 23:41:13');

SET @idCompra4 = NULL;
CALL AltaCompra ( @idCompra4 , 4, 2, 1, 10500, '2022-04-04 09:30:59');

SET @idCompra5 = NULL;
CALL AltaCompra (@idCompra5, 5, 2, 1, 14000, '2022-04-04 09:39:11');

SET @idCompra6 = NULL;
CALL AltaCompra (@idCompra6, 6, 2,1 , 1800, '2022-04-04 09:53:26');

SET @idCompra7 = NULL;
CALL AltaCompra (@idCompra7,2, 2,1 , 11000, '2022-04-04 09:59:24');

SET @idCompra8 = NULL;
CALL AltaCompra (@idCompra8, 3, 3, 1, 9850, '2022-04-08 17:35:47');

SET @idCompra9 = NULL;
CALL AltaCompra (@idCompra9, 4, 3, 2, 36000, '2022-04-08 17:40:05');

SET @idCompra10 = NULL;
CALL AltaCompra (@idCompra10, 5 , 3, 1, 11000, '2022-04-08 17:44:03');