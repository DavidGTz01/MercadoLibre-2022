namespace Mercado.AdoMysql;
public class Cliente
{
    public int idCliente { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string telefono { get; set; }
    public string email { get; set; }
    public string usuario { get; set; }
    public string contrasena { get; set; }
    public Cliente() { }
    public Cliente(int idCliente, string nombre, string apellido, string telefono, string email, string usuario, string contrasena)
    {
        this.idCliente = idCliente;
        this.nombre = nombre;
        this.apellido = apellido;
        this.telefono = telefono;
        this.email = email;
        this.usuario = usuario;
        this.constrasena = contrasena;
    }
}

public class Producto
{
    public int idProducto { get; set; }
    public int idCliente { get; set; }
    public decimal precio { get; set; }
    public int cantidad { get; set; }
    public string nombre { get; set; }
    public datetime publicacion { get; set; }
    public Producto() { }
}
