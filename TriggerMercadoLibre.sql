--Realizar un trigger que antes de realizar una compra, se verifique se posean al menos en stock la cantidad de unidades pretendidas por la compra; en caso que no sea así no se tiene que permitir la compra y se tiene que mostrar leyenda ‘Unidades Insuficientes’.
DELIMITER $$
CREATE TRIGGER  BefInsCom BEFORE INSERT ON Compra 
FOR EACH ROW
BEGIN 
IF(EXISTS (SELECT * 
        FROM Producto 
        WHERE idProducto = NEW.idProducto
         AND 	cantidad < NEW.unidades  )) THEN
SIGNAL SQLSTATE ‘45000’
SET MESSAGE_TEXT = ‘Unidades Insuficientes’ ;
END IF;
END$$

--Realizar un trigger para que al momento de hacer una compra, al confirmarse la misma se decremente del stock del producto la cantidad de unidades compradas.

DELIMITER $$
CREATE TRIGGER AftInsCom  AFTER INSERT ON Compra

FOR EACH  ROW 
BEGIN 
  UPDATE Producto
  SET cantidad = (cantidad - NEW.unidades)
  WHERE idProducto = NEW.idProducto;

END$$
