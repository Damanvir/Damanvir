using Microsoft.Data.Sqlite;
using System;

public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(string dbPath)
    {
        _connectionString = new SqliteConnectionStringBuilder { DataSource = dbPath }.ToString();
    }

    public void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"
            CREATE TABLE Students (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL
            );
        ";
        command.ExecuteNonQuery();
    }

    public void AddStudent(string name)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Students (Name) VALUES (@Name)";
        command.Parameters.AddWithValue("@Name", name);
        command.ExecuteNonQuery();
    }

    public void DisplayStudents()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name FROM Students";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader.GetInt32(0)}, Name: {reader.GetString(1)}");
        }
    }
}
