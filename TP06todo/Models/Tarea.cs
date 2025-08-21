namespace TP06todo.Models;

public class Tarea{

    public int id { get; private set; }
    public string descripcion { get; private set; }
    public DateTime fecha { get; private set; }
    public bool finalizada { get; private set; }
    public int idUsuario { get; private set; }
    public string titulo { get; private set; }
    
    public Tarea(int id, string descripcion, bool finalizada, int idUsuario, string titulo, DateTime fecha )
    {
        this.id = id;
        this.descripcion = descripcion;
        this.fecha = fecha;
        this.finalizada = finalizada;
        this.idUsuario = idUsuario;
        this.titulo = titulo;

    }

}