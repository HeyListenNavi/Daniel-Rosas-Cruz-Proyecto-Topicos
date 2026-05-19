using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.IO;
using Daniel_Rosas_Cruz.Models;

namespace Daniel_Rosas_Cruz.Data
{
    // clase repositorio para manejar la bdd
    public class TaskRepository
    {
        private readonly string _connectionString;
        private readonly object _dbLock = new object();

        public TaskRepository(string dbPath)
        {
            _connectionString = $"Data Source={dbPath};";
            InitializeDatabase(dbPath);
        }

        private void InitializeDatabase(string dbPath)
        {
            lock (_dbLock)
            {
                if (!File.Exists(dbPath))
                {
                    // crear la conexion con sqlite
                    using (var connection = new SqliteConnection(_connectionString))
                    {
                        connection.Open();

                        // crear tabla de tareas
                        string createTableQuery = @"
                            CREATE TABLE Tasks (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL,
                                FilePath TEXT NOT NULL,
                                ExecuteAt DATETIME NOT NULL,
                                Status INTEGER NOT NULL,
                                LogMessage TEXT
                            )";
                        using (var command = new SqliteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void AddTask(TaskItem task)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Tasks (Name, FilePath, ExecuteAt, Status, LogMessage) 
                                     VALUES (@Name, @FilePath, @ExecuteAt, @Status, @LogMessage)";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", task.Name);
                        command.Parameters.AddWithValue("@FilePath", task.FilePath);
                        command.Parameters.AddWithValue("@ExecuteAt", task.ExecuteAt);
                        command.Parameters.AddWithValue("@Status", (int)task.Status);
                        command.Parameters.AddWithValue("@LogMessage", (object)task.LogMessage ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdateTaskStatusAndLog(int id, TaskStatus status, string logMessage)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Status = @Status, LogMessage = @LogMessage WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", (int)status);
                        command.Parameters.AddWithValue("@LogMessage", logMessage ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdateTask(TaskItem task)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Name = @Name, FilePath = @FilePath, ExecuteAt = @ExecuteAt, Status = @Status WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", task.Name);
                        command.Parameters.AddWithValue("@FilePath", task.FilePath);
                        command.Parameters.AddWithValue("@ExecuteAt", task.ExecuteAt);
                        command.Parameters.AddWithValue("@Status", (int)task.Status);
                        command.Parameters.AddWithValue("@Id", task.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteTask(int id)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Tasks WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<TaskItem> GetAllTasks()
        {
            var tasks = new List<TaskItem>();
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Name, FilePath, ExecuteAt, Status, LogMessage FROM Tasks";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tasks.Add(new TaskItem
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    FilePath = reader["FilePath"].ToString(),
                                    ExecuteAt = Convert.ToDateTime(reader["ExecuteAt"]),
                                    Status = (TaskStatus)Convert.ToInt32(reader["Status"]),
                                    LogMessage = reader["LogMessage"] == DBNull.Value ? null : reader["LogMessage"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return tasks;
        }

        public List<TaskItem> GetPendingTasks()
        {
            var tasks = new List<TaskItem>();
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Name, FilePath, ExecuteAt, Status, LogMessage FROM Tasks WHERE Status = @Status";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", (int)TaskStatus.Pending);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tasks.Add(new TaskItem
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString(),
                                    FilePath = reader["FilePath"].ToString(),
                                    ExecuteAt = Convert.ToDateTime(reader["ExecuteAt"]),
                                    Status = (TaskStatus)Convert.ToInt32(reader["Status"]),
                                    LogMessage = reader["LogMessage"] == DBNull.Value ? null : reader["LogMessage"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return tasks;
        }
    }
}
