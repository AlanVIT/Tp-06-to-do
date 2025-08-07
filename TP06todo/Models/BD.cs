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

    public static void agregarTarea(int id, string descripcion, bool finalizada, string idUsuario, string titulo, DateTime fecha )
    {   
        string query = "INSERT INTO Tarea (id, descripcion, fecha,  finalizada, idUsuario, titulo ) VALUES (@pid, @pdescripcion, @pfecha,  @pfinalizada, @pidUsuario, @ptitulo) ";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pid = id, pdescripcion = descripcion, pfecha = fecha, pfinalizada = finalizada, pidUsuario = idUsuario, ptitulo = titulo});
        }
    }

     public static void eliminarTarea(int id)
    {
        string query = "DELETE Tarea WHERE id = @pid ";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pid = id});
        }
    }

    public static void modificarTarea(int id, string descripcion, bool finalizada, string idUsuario, string titulo, DateTime fecha )
    {   
        string query = "UPDATE Tarea SET descripcion = @pdescripcion, fecha = @pfecha, finalizada = @pfinalizada, idUsuario = @pidUsuario, titulo = @ptitulo WHERE id = @pid";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pid = id, pdescripcion = descripcion, pfecha = fecha, pfinalizada = finalizada, pidUsuario = idUsuario, ptitulo = titulo});
        }
    }

    public static List<Tarea> verTareas(int id)
    {
        List<Tarea> listaTareas = new List<Tarea>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Tarea.id, Tarea.descripcion, Tarea.fecha,  Tarea.finalizada, Tarea.idUsuario, Tarea.titulo FROM Usuario INNER JOIN Tarea ON Usuario.id = @pid";
            listaTareas = connection.Query<Tarea>(query, new { pid = id}).ToList();
        }
        return listaTareas;
    }

    public static void finalizarTarea(int id)
    {   
        string query = "UPDATE Tarea SET finalizada = 1";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pid = id});
        }
    }
    public static void actualizarFecha(int id, DateTime nuevaFecha)
    {   
        string query = "UPDATE Tarea SET fecha = @pnuevaFecha";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {pid = id, pnuevaFecha = nuevaFecha});
        }
    }

    

}


