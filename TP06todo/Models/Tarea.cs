namespace TP06todo.Models;

public class Tarea
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public bool Finalizada { get; set; }
    public int IdUsuario { get; set; }
    public string Titulo { get; set; }

    public Tarea() { }

    public Tarea(int id, string descripcion, DateTime fecha, bool finalizada, int idUsuario, string titulo)
    {
        Id = id;
        Descripcion = descripcion;
        Fecha = fecha;
        Finalizada = finalizada;
        IdUsuario = idUsuario;
        Titulo = titulo;
    }
}