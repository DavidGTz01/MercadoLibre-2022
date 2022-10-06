-- Administrador: puede ver todo desde cualquier lado.
USE MercaLibre;
DROP USER IF EXISTS 'Administrador'@'%';
CREATE USER 'Administrador'@'%' IDENTIFIED BY 'passAdministrador';
GRANT SELECT ON MercaLibre.* TO 'Administrador '@'%';



-- SistemaUsuario: desde la red 10.3.45.xxx puede

DROP USER IF EXISTS 'SistemaUsuario'@'10.3.45.%';
CREATE USER 'SistemaUsuario'@'10.3.45.%' IDENTIFIED BY 'passSistemaUsuario';

-- Dar de alta Usuarios y modificar solo su contraseña.
GRANT INSERT, UPDATE(Contrasena) ON MercaLibre.Cliente TO  'SistemaUsuario'@'10.3.45.%';

-- Ver y dar de alta productos, solo modificar su precio y cantidad.
GRANT SELECT, INSERT, UPDATE(precio, cantidad) ON MercaLibre.Producto TO  'SistemaUsuario'@'10.3.45.%';



-- Usuario:  desde cualquier lado puede
CREATE USER 'Usuario'@'%' IDENTIFIED BY 'passUsuario';

-- Ver todo lo de la tabla usuario.
GRANT SELECT ON MercaLibre.* TO  'Usuario'@'%';

-- Ver todo respecto de los productos.
GRANT SELECT ON MercaLibre.Producto TO  'Usuario'@'%';

-- Ver todo respecto de las compras.
GRANT SELECT ON MercaLibre.Compra TO  'Usuario'@'%';
