//dotnet add package Microsoft.Data.SqlClient
//dotnet add package Dapper
//dotnet add package Microsoft.AspNetCore.Session
//dotnet add package NewtonSoft.Json
using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06todo.Models;

public static class BD
{

    private static string _connectionString = @"Server=localhost;DataBase=TP 06 to do;Integrated Security=True;TrustServerCertificate=True;";
    public static int Login(string usuario, string password)
    {
        int id = -1;
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Id FROM Usuario WHERE usuario = @pUsuario AND password = @pPassword";
            id = connection.QueryFirstOrDefault<int>(query, new { pUsuario = usuario, pPassword = password});
        }
        return id;
    }

    public static void RegistrarUsuario(string nombre, string apellido, string usuario, string password, string foto, DateTime fecha)
    {
        string query = "INSERT INTO Usuario (nombre, apellido, usuario, password, foto, fecha) VALUES (@pNombre, @pApellido, @pUsuario, @pPassword, @pFoto, @pFecha)";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pNombre = nombre, pApellido = apellido, pUsuario = usuario, pPassword = password, pFoto = foto, pFecha = fecha });
        }
    }

        public static void AgregarTarea(string descripcion, bool finalizada, int idUsuario, string titulo, DateTime fecha)
        {
            string query = "INSERT INTO Tarea (descripcion, fecha, finalizada, idUsuario, titulo) VALUES (@pdescripcion, @pfecha, @pfinalizada, @pidUsuario, @ptitulo)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new {
                    pdescripcion = descripcion,
                    pfecha = fecha,
                    pfinalizada = finalizada,
                    pidUsuario = idUsuario,
                    ptitulo = titulo
                });
            }
        }


     public static void EliminarTarea(int id)
    {
        string query = "DELETE Tarea WHERE id = @pid ";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pid = id});
        }
    }

    public static void ModificarTarea(int id, string descripcion, bool finalizada, int idUsuario, string titulo, DateTime fecha )
    {   
        string query = "UPDATE Tarea SET descripcion = @pdescripcion, fecha = @pfecha, finalizada = @pfinalizada, idUsuario = @pidUsuario, titulo = @ptitulo WHERE id = @pid";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pid = id, pdescripcion = descripcion, pfecha = fecha, pfinalizada = finalizada, pidUsuario = idUsuario, ptitulo = titulo});
        }
    }

    public static List<Tarea> VerTareas(int id)
    {
        List<Tarea> listaTareas = new List<Tarea>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tarea WHERE idUsuario = @pid";
            listaTareas = connection.Query<Tarea>(query, new { pid = id}).ToList();
        }
        return listaTareas;
    }
    public static Tarea VerTarea(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tarea WHERE Tarea.id = @pid";
            return connection.QueryFirstOrDefault<Tarea>(query, new { pid = id });
        }
    }

public static void FinalizarTarea(int id)
{
    string query = "UPDATE Tarea SET finalizada = 1 WHERE id = @pid";
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new { pid = id });
    }
}

public static void ActualizarFecha(int id, DateTime nuevaFecha)
{
    string query = "UPDATE Tarea SET fecha = @pnuevaFecha WHERE id = @pid";
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Execute(query, new { pid = id, pnuevaFecha = nuevaFecha });
    }
}

    

}


