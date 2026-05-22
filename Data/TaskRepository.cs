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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    // crear tabla de usuarios
                    string createUsersTable = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL UNIQUE,
                            Password TEXT NOT NULL
                        )";

                    // crear tabla de categorias
                    string createCategoriesTable = @"
                        CREATE TABLE IF NOT EXISTS Categories (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            UserId INTEGER,
                            FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
                        )";
                    
                    // crear tabla de tareas
                    string createTasksTable = @"
                        CREATE TABLE IF NOT EXISTS Tasks (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            FilePath TEXT NOT NULL,
                            ExecuteAt DATETIME NOT NULL,
                            Status INTEGER NOT NULL,
                            LogMessage TEXT,
                            CategoryId INTEGER,
                            UserId INTEGER NOT NULL,
                            FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE SET NULL,
                            FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
                        )";

                    // crear tabla de historial
                    string createHistoryTable = @"
                        CREATE TABLE IF NOT EXISTS TaskHistory (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            TaskId INTEGER NOT NULL,
                            ExecutedAt DATETIME NOT NULL,
                            Status INTEGER NOT NULL,
                            LogMessage TEXT,
                            FOREIGN KEY (TaskId) REFERENCES Tasks(Id) ON DELETE CASCADE
                        )";

                    using (var command = new SqliteCommand(createUsersTable, connection)) command.ExecuteNonQuery();
                    using (var command = new SqliteCommand(createTasksTable, connection)) command.ExecuteNonQuery();
                    using (var command = new SqliteCommand(createHistoryTable, connection)) command.ExecuteNonQuery();

                    // Migración robusta para Categorías: Quitar UNIQUE(Name) global y poner UNIQUE(Name, UserId)
                    bool needsCatMigration = false;
                    using (var cmd = new SqliteCommand("PRAGMA table_info(Categories)", connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            bool hasUserId = false;
                            while (reader.Read()) { if (reader["name"].ToString() == "UserId") hasUserId = true; }
                            if (!hasUserId) needsCatMigration = true;
                        }
                    }

                    if (needsCatMigration)
                    {
                        string migrateSql = @"
                            CREATE TABLE IF NOT EXISTS Categories_new (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL,
                                UserId INTEGER,
                                FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
                                UNIQUE(Name, UserId)
                            );
                            INSERT OR IGNORE INTO Categories_new (Id, Name) SELECT Id, Name FROM Categories;
                            DROP TABLE IF EXISTS Categories;
                            ALTER TABLE Categories_new RENAME TO Categories;";
                        using (var transaction = connection.BeginTransaction())
                        {
                            try {
                                using (var cmd = new SqliteCommand(migrateSql, connection, transaction)) cmd.ExecuteNonQuery();
                                transaction.Commit();
                            } catch { transaction.Rollback(); }
                        }
                    }
                    else
                    {
                        using (var command = new SqliteCommand(createCategoriesTable, connection)) command.ExecuteNonQuery();
                    }

                    // Migraciones para dbs existentes
                    try { using (var cmd = new SqliteCommand("ALTER TABLE Users ADD COLUMN Password TEXT DEFAULT '1234'", connection)) cmd.ExecuteNonQuery(); } catch { }
                    try { using (var cmd = new SqliteCommand("ALTER TABLE Tasks ADD COLUMN UserId INTEGER", connection)) cmd.ExecuteNonQuery(); } catch { }

                    SeedData(connection);
                }
            }
        }

        private void SeedData(SqliteConnection connection)
        {
            // Usuarios iniciales
            string checkUsers = "SELECT COUNT(*) FROM Users";
            using (var command = new SqliteCommand(checkUsers, connection))
            {
                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    string seed = "INSERT INTO Users (Name, Password) VALUES ('Administrador', 'admin'), ('Invitado', '1234')";
                    using (var seedCmd = new SqliteCommand(seed, connection)) seedCmd.ExecuteNonQuery();
                }
            }

            // Categorías globales
            string checkCats = "SELECT COUNT(*) FROM Categories WHERE UserId IS NULL";
            using (var command = new SqliteCommand(checkCats, connection))
            {
                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    string seed = "INSERT OR IGNORE INTO Categories (Name, UserId) VALUES ('General', NULL), ('Sistema', NULL), ('Trabajo', NULL), ('Personal', NULL)";
                    using (var seedCmd = new SqliteCommand(seed, connection)) seedCmd.ExecuteNonQuery();
                }
            }
        }

        public User Login(string username, string password)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE Name = @Name AND Password = @Pass";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", username);
                        command.Parameters.AddWithValue("@Pass", password);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User { Id = Convert.ToInt32(reader["Id"]), Name = reader["Name"].ToString() };
                            }
                        }
                    }
                }
            }
            return null;
        }

        public bool Register(string username, string password)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Name, Password) VALUES (@Name, @Pass)";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", username);
                        command.Parameters.AddWithValue("@Pass", password);
                        try { return command.ExecuteNonQuery() > 0; }
                        catch { return false; }
                    }
                }
            }
        }

        public void UpdateUser(int userId, string newName, string newPass)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Users SET Name = @Name, Password = @Pass WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", newName);
                        command.Parameters.AddWithValue("@Pass", newPass);
                        command.Parameters.AddWithValue("@Id", userId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteUser(int userId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", userId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<Category> GetCategories(int userId)
        {
            var cats = new List<Category>();
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Name, UserId FROM Categories WHERE UserId IS NULL OR UserId = @UserId";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cats.Add(new Category 
                                { 
                                    Id = Convert.ToInt32(reader["Id"]), 
                                    Name = reader["Name"].ToString(),
                                    UserId = reader["UserId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["UserId"])
                                });
                            }
                        }
                    }
                }
            }
            return cats;
        }

        public void AddCategory(string name, int userId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Categories (Name, UserId) VALUES (@Name, @UserId)";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdateCategory(int catId, string name)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Id", catId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteCategory(int catId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Categories WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", catId);
                        command.ExecuteNonQuery();
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
                    string query = @"INSERT INTO Tasks (Name, FilePath, ExecuteAt, Status, LogMessage, CategoryId, UserId) 
                                     VALUES (@Name, @FilePath, @ExecuteAt, @Status, @LogMessage, @CategoryId, @UserId)";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", task.Name);
                        command.Parameters.AddWithValue("@FilePath", task.FilePath);
                        command.Parameters.AddWithValue("@ExecuteAt", task.ExecuteAt);
                        command.Parameters.AddWithValue("@Status", (int)task.Status);
                        command.Parameters.AddWithValue("@LogMessage", (object)task.LogMessage ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CategoryId", (object)task.CategoryId ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserId", task.UserId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AddHistoryEntry(int taskId, TaskStatus status, string logMessage)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO TaskHistory (TaskId, ExecutedAt, Status, LogMessage) 
                                     VALUES (@TaskId, @ExecutedAt, @Status, @LogMessage)";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaskId", taskId);
                        command.Parameters.AddWithValue("@ExecutedAt", DateTime.Now);
                        command.Parameters.AddWithValue("@Status", (int)status);
                        command.Parameters.AddWithValue("@LogMessage", (object)logMessage ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<TaskHistoryItem> GetHistory(int userId)
        {
            var history = new List<TaskHistoryItem>();
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT h.*, t.Name as TaskName 
                                     FROM TaskHistory h 
                                     JOIN Tasks t ON h.TaskId = t.Id 
                                     WHERE t.UserId = @UserId
                                     ORDER BY h.ExecutedAt DESC LIMIT 100";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                history.Add(new TaskHistoryItem
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    TaskId = Convert.ToInt32(reader["TaskId"]),
                                    TaskName = reader["TaskName"].ToString(),
                                    ExecutedAt = Convert.ToDateTime(reader["ExecutedAt"]),
                                    Status = (TaskStatus)Convert.ToInt32(reader["Status"]),
                                    LogMessage = reader["LogMessage"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            return history;
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
                AddHistoryEntry(id, status, logMessage);
            }
        }

        public void UpdateTask(TaskItem task)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Name = @Name, FilePath = @FilePath, ExecuteAt = @ExecuteAt, Status = @Status, CategoryId = @CategoryId WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", task.Name);
                        command.Parameters.AddWithValue("@FilePath", task.FilePath);
                        command.Parameters.AddWithValue("@ExecuteAt", task.ExecuteAt);
                        command.Parameters.AddWithValue("@Status", (int)task.Status);
                        command.Parameters.AddWithValue("@CategoryId", (object)task.CategoryId ?? DBNull.Value);
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

        public List<TaskItem> GetAllTasks(int userId)
        {
            var tasks = new List<TaskItem>();
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT t.*, c.Name as CategoryName, u.Name as UserName 
                                     FROM Tasks t 
                                     LEFT JOIN Categories c ON t.CategoryId = c.Id
                                     LEFT JOIN Users u ON t.UserId = u.Id
                                     WHERE t.UserId = @UserId";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
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
                                    LogMessage = reader["LogMessage"] == DBNull.Value ? null : reader["LogMessage"].ToString(),
                                    CategoryId = reader["CategoryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CategoryId"]),
                                    CategoryName = reader["CategoryName"] == DBNull.Value ? "Sin Categoría" : reader["CategoryName"].ToString(),
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    UserName = reader["UserName"] == DBNull.Value ? "Sin Usuario" : reader["UserName"].ToString()
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
                    string query = "SELECT Id, Name, FilePath, ExecuteAt, Status, LogMessage, UserId FROM Tasks WHERE Status = @Status";
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
                                    LogMessage = reader["LogMessage"] == DBNull.Value ? null : reader["LogMessage"].ToString(),
                                    UserId = Convert.ToInt32(reader["UserId"])
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
