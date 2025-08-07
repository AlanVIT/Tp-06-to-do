namespace TP06todo.Models;

public class Usuario{

    public int id { get; private set; }
    public string nombre { get; private set; }
    public string apellido { get; private set; }
    public string usuario { get; private set; }
    public string password { get; private set; }
    public string foto { get; private set; }
    public DateTime fecha { get; private set; }
    
    public Usuario(int id, string nombre,string apellido, string usuario, string password, string foto,DateTime fecha )
    {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.usuario = usuario;
        this.password = password;
        this.foto = foto;
        this.fecha = fecha;

    }

}