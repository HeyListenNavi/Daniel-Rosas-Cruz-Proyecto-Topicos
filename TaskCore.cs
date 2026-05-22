using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Daniel_Rosas_Cruz
{
    // Clase de Base de datos

    public class AccesoDatos
    {
        private string _connectionString;
        private readonly object _dbLock = new object();

        public AccesoDatos(string connectionString)
        {
            _connectionString = connectionString;
            CrearBaseDeDatosSiNoExiste();
            InicializarTablas();
        }

        private void CrearBaseDeDatosSiNoExiste()
        {
            var builder = new SqlConnectionStringBuilder(_connectionString);
            string databaseName = builder.InitialCatalog;
            builder.InitialCatalog = "master";

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                string query = $@"
                    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}')
                    BEGIN
                        CREATE DATABASE [{databaseName}]
                    END";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InicializarTablas()
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sqlBase = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Users] (
                                Id INT IDENTITY(1,1) PRIMARY KEY, 
                                Name NVARCHAR(100) NOT NULL UNIQUE, 
                                Password NVARCHAR(100) NOT NULL DEFAULT '1234'
                            )
                        END;

                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Categories] (
                                Id INT IDENTITY(1,1) PRIMARY KEY, 
                                Name NVARCHAR(100) NOT NULL, 
                                UserId INT,
                                CONSTRAINT FK_Categories_Users FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
                            )
                        END;

                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Tasks] (
                                Id INT IDENTITY(1,1) PRIMARY KEY, 
                                Name NVARCHAR(100) NOT NULL, 
                                FilePath NVARCHAR(MAX) NOT NULL, 
                                ExecuteAt DATETIME NOT NULL, 
                                Status INT NOT NULL DEFAULT 0, 
                                LogMessage NVARCHAR(MAX) DEFAULT '', 
                                CategoryId INT, 
                                UserId INT, 
                                CONSTRAINT FK_Tasks_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE SET NULL, 
                                CONSTRAINT FK_Tasks_Users FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE NO ACTION
                            )
                        END;

                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskHistory]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[TaskHistory] (
                                Id INT IDENTITY(1,1) PRIMARY KEY, 
                                TaskId INT NOT NULL, 
                                ExecutedAt DATETIME NOT NULL, 
                                Status INT NOT NULL, 
                                LogMessage NVARCHAR(MAX) DEFAULT '', 
                                CONSTRAINT FK_TaskHistory_Tasks FOREIGN KEY (TaskId) REFERENCES Tasks(Id) ON DELETE CASCADE
                            )
                        END;";

                    using (var command = new SqlCommand(sqlBase, connection)) command.ExecuteNonQuery();

                    string fixOrphans = "UPDATE Tasks SET UserId = (SELECT TOP 1 Id FROM Users ORDER BY Id ASC) WHERE UserId IS NULL AND (SELECT COUNT(*) FROM Users) > 0";
                    using (var cmd = new SqlCommand(fixOrphans, connection)) cmd.ExecuteNonQuery();

                    CargarDatosIniciales(connection);
                }
            }
        }

        private void CargarDatosIniciales(SqlConnection connection)
        {
            string checkUsers = "SELECT COUNT(*) FROM Users";
            using (var command = new SqlCommand(checkUsers, connection))
            {
                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    string seed = "INSERT INTO Users (Name, Password) VALUES ('Administrador', 'admin'), ('Invitado', '1234')";
                    using (var seedCmd = new SqlCommand(seed, connection)) seedCmd.ExecuteNonQuery();
                }
            }

            string checkCats = "SELECT COUNT(*) FROM Categories WHERE UserId IS NULL";
            using (var command = new SqlCommand(checkCats, connection))
            {
                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    string seed = @"
                        IF NOT EXISTS (SELECT 1 FROM Categories WHERE Name = 'General' AND UserId IS NULL)
                            INSERT INTO Categories (Name, UserId) VALUES ('General', NULL);
                        IF NOT EXISTS (SELECT 1 FROM Categories WHERE Name = 'Sistema' AND UserId IS NULL)
                            INSERT INTO Categories (Name, UserId) VALUES ('Sistema', NULL);
                        IF NOT EXISTS (SELECT 1 FROM Categories WHERE Name = 'Trabajo' AND UserId IS NULL)
                            INSERT INTO Categories (Name, UserId) VALUES ('Trabajo', NULL);
                        IF NOT EXISTS (SELECT 1 FROM Categories WHERE Name = 'Personal' AND UserId IS NULL)
                            INSERT INTO Categories (Name, UserId) VALUES ('Personal', NULL);";
                    using (var seedCmd = new SqlCommand(seed, connection)) seedCmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable Login(string username, string password)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE Name = @Name AND Password = @Pass";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", username);
                        command.Parameters.AddWithValue("@Pass", password);
                        using (var reader = command.ExecuteReader())
                        {
                            DataSet ds = new DataSet();
                            DataTable dt = ds.Tables.Add();
                            ds.EnforceConstraints = false;
                            dt.Load(reader);
                            return dt.Rows.Count > 0 ? dt : null;
                        }
                    }
                }
            }
        }

        public bool RegistrarUsuario(string username, string password)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Name, Password) VALUES (@Name, @Pass)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", username);
                        command.Parameters.AddWithValue("@Pass", password);
                        try { return command.ExecuteNonQuery() > 0; }
                        catch { return false; }
                    }
                }
            }
        }

        public void ActualizarPerfil(int userId, string newName, string newPass)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Users SET Name = @Name, Password = @Pass WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", newName);
                        command.Parameters.AddWithValue("@Pass", newPass);
                        command.Parameters.AddWithValue("@Id", userId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void BorrarCuenta(int userId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", userId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public DataTable ObtenerCategorias(int userId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Name, UserId FROM Categories WHERE UserId IS NULL OR UserId = @UserId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            var ds = new DataSet();
                            ds.EnforceConstraints = false;
                            DataTable dt = ds.Tables.Add();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
        }

        public void GuardarCategoria(string nombre, int userId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Categories (Name, UserId) VALUES (@Name, @UserId)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", nombre);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void ModificarCategoria(int id, string nombre)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", nombre);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void EliminarCategoria(int id)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Categories WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void CrearTarea(string nombre, string ruta, DateTime fecha, int estado, int? catId, int userId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Tasks (Name, FilePath, ExecuteAt, Status, LogMessage, CategoryId, UserId) VALUES (@Name, @FilePath, @ExecuteAt, @Status, '', @CategoryId, @UserId)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", nombre);
                        command.Parameters.AddWithValue("@FilePath", ruta);
                        command.Parameters.AddWithValue("@ExecuteAt", fecha);
                        command.Parameters.AddWithValue("@Status", estado);
                        command.Parameters.AddWithValue("@CategoryId", (object)catId ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public DataTable ListarTareas(int userId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
SELECT t.Id, t.Name, t.FilePath, t.ExecuteAt, t.Status, t.LogMessage, t.CategoryId, t.UserId,
       c.Name AS CategoryName, u.Name AS UserName
FROM Tasks t
LEFT JOIN Categories c ON t.CategoryId = c.Id
LEFT JOIN Users u ON t.UserId = u.Id
WHERE t.UserId = @UserId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            var ds = new DataSet();
                            ds.EnforceConstraints = false;
                            DataTable dt = ds.Tables.Add();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable ListarPendientes()
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tasks WHERE Status = 0";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var ds = new DataSet();
                            ds.EnforceConstraints = false;
                            DataTable dt = ds.Tables.Add();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
        }

        public void ActualizarTarea(int id, string nombre, string ruta, DateTime fecha, int? catId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Name = @Name, FilePath = @FilePath, ExecuteAt = @ExecuteAt, CategoryId = @CategoryId WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", nombre);
                        command.Parameters.AddWithValue("@FilePath", ruta);
                        command.Parameters.AddWithValue("@ExecuteAt", fecha);
                        command.Parameters.AddWithValue("@CategoryId", (object)catId ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void BorrarTarea(int id)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Tasks WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void CambiarEstado(int id, int estado, string log)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Status = @Status, LogMessage = @Log WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", estado);
                        command.Parameters.AddWithValue("@Log", log);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                    
                    string hist = "INSERT INTO TaskHistory (TaskId, ExecutedAt, Status, LogMessage) VALUES (@TaskId, @Date, @Status, @Log)";
                    using (var cmd = new SqlCommand(hist, connection))
                    {
                        cmd.Parameters.AddWithValue("@TaskId", id);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Status", estado);
                        cmd.Parameters.AddWithValue("@Log", log);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public DataTable ObtenerHistorial(int userId)
        {
            lock (_dbLock)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT TOP 100 h.*, t.Name as TaskName FROM TaskHistory h JOIN Tasks t ON h.TaskId = t.Id WHERE t.UserId = @UserId ORDER BY h.ExecutedAt DESC";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        using (var reader = command.ExecuteReader())
                        {
                            var ds = new DataSet();
                            ds.EnforceConstraints = false;
                            DataTable dt = ds.Tables.Add();
                            dt.Load(reader);
                            return dt;
                        }
                    }
                }
            }
        }
    }

    // Clase para porcesar todas las tareas programadas

    public class ProcesadorTareas
    {
        private readonly AccesoDatos _db;
        private readonly ConcurrentDictionary<int, System.Timers.Timer> _timers;
        public event Action<DataRow> AlCambiarEstado;

        public ProcesadorTareas(AccesoDatos db)
        {
            _db = db;
            _timers = new ConcurrentDictionary<int, System.Timers.Timer>();
        }

        public void Iniciar()
        {
            DataTable pendientes = _db.ListarPendientes();
            foreach (DataRow fila in pendientes.Rows)
            {
                Programar(fila);
            }
        }

        public void Programar(DataRow filaTarea)
        {
            int id = Convert.ToInt32(filaTarea["Id"]);
            Cancelar(id); // Limpiar si ya existe

            DateTime ejecutaEn = Convert.ToDateTime(filaTarea["ExecuteAt"]);
            double ms = (ejecutaEn - DateTime.Now).TotalMilliseconds;

            if (ms <= 0)
            {
                Task.Run(() => EjecutarArchivo(filaTarea));
                return;
            }

            var timer = new System.Timers.Timer(ms);
            timer.AutoReset = false;
            timer.Elapsed += (s, e) =>
            {
                _timers.TryRemove(id, out _);
                EjecutarArchivo(filaTarea);
                timer.Dispose();
            };
            _timers.TryAdd(id, timer);
            timer.Start();
        }

        public void Cancelar(int id)
        {
            if (_timers.TryRemove(id, out var timer))
            {
                timer.Stop();
                timer.Dispose();
            }
        }

        private void EjecutarArchivo(DataRow fila)
        {
            int id = Convert.ToInt32(fila["Id"]);
            _db.CambiarEstado(id, 1, "Iniciando...");
            
            try {
                ProcessStartInfo info = new ProcessStartInfo { FileName = fila["FilePath"].ToString(), UseShellExecute = true };
                using (Process p = Process.Start(info))
                {
                    ActualizarEnBD(fila, 2, "OK");
                }
            }
            catch (Exception ex) { 
                ActualizarEnBD(fila, 3, "Error: " + ex.Message); 
            }
        }

        private void ActualizarEnBD(DataRow fila, int nuevoEstado, string mensaje)
        {
            int id = Convert.ToInt32(fila["Id"]);
            _db.CambiarEstado(id, nuevoEstado, mensaje);
            
            // Refrescar fila para el evento UI
            fila["Status"] = nuevoEstado;
            fila["LogMessage"] = mensaje;
            AlCambiarEstado?.Invoke(fila);
        }
    }
}
