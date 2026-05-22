using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Daniel_Rosas_Cruz
{
    // Clase de Base de datos

    public class AccesoDatos
    {
        private readonly string _connectionString;
        private readonly object _dbLock = new object();

        public AccesoDatos(string dbPath)
        {
            _connectionString = $"Data Source={dbPath};";
            InicializarTablas(dbPath);
        }

        private void InicializarTablas(string dbPath)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();

                    string sqlBase = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                            Name TEXT NOT NULL UNIQUE, 
                            Password TEXT NOT NULL DEFAULT '1234'
                        );
                        CREATE TABLE IF NOT EXISTS Categories (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                            Name TEXT NOT NULL, 
                            UserId INTEGER,
                            FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
                        );
                        CREATE TABLE IF NOT EXISTS Tasks (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                            Name TEXT NOT NULL, 
                            FilePath TEXT NOT NULL, 
                            ExecuteAt DATETIME NOT NULL, 
                            Status INTEGER NOT NULL DEFAULT 0, 
                            LogMessage TEXT DEFAULT '', 
                            CategoryId INTEGER, 
                            UserId INTEGER, 
                            FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE SET NULL, 
                            FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
                        );
                        CREATE TABLE IF NOT EXISTS TaskHistory (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                            TaskId INTEGER NOT NULL, 
                            ExecutedAt DATETIME NOT NULL, 
                            Status INTEGER NOT NULL, 
                            LogMessage TEXT DEFAULT '', 
                            FOREIGN KEY (TaskId) REFERENCES Tasks(Id) ON DELETE CASCADE
                        );";

                    using (var command = new SqliteCommand(sqlBase, connection)) command.ExecuteNonQuery();

                    try
                    {
                        bool migrado = false;
                        using (var cmdCheck = new SqliteCommand("SELECT sql FROM sqlite_master WHERE name='Categories' AND sql LIKE '%UNIQUE%'", connection))
                        {
                            var result = cmdCheck.ExecuteScalar();
                            migrado = result != null && result.ToString().Contains("UNIQUE");
                        }

                        if (!migrado)
                        {
                            string migrateSql = @"
                                CREATE TABLE IF NOT EXISTS Categories_temp (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                    Name TEXT NOT NULL, 
                                    UserId INTEGER, 
                                    UNIQUE(Name, UserId)
                                );
                                INSERT OR IGNORE INTO Categories_temp (Id, Name, UserId) SELECT Id, Name, UserId FROM Categories;
                                DROP TABLE IF EXISTS Categories;
                                ALTER TABLE Categories_temp RENAME TO Categories;";
                            
                            using (var transaction = connection.BeginTransaction())
                            {
                                try {
                                    using (var cmd = new SqliteCommand(migrateSql, connection, transaction)) cmd.ExecuteNonQuery();
                                    transaction.Commit();
                                } catch { transaction.Rollback(); }
                            }
                        }
                    }
                    catch { }

                    try { using (var cmd = new SqliteCommand("ALTER TABLE Users ADD COLUMN Password TEXT NOT NULL DEFAULT '1234'", connection)) cmd.ExecuteNonQuery(); } catch { }
                    try { using (var cmd = new SqliteCommand("ALTER TABLE Tasks ADD COLUMN UserId INTEGER", connection)) cmd.ExecuteNonQuery(); } catch { }
                    try { using (var cmd = new SqliteCommand("ALTER TABLE Tasks ADD COLUMN LogMessage TEXT DEFAULT ''", connection)) cmd.ExecuteNonQuery(); } catch { }

                    string fixOrphans = "UPDATE Tasks SET UserId = (SELECT Id FROM Users ORDER BY Id ASC LIMIT 1) WHERE UserId IS NULL AND (SELECT COUNT(*) FROM Users) > 0";
                    using (var cmd = new SqliteCommand(fixOrphans, connection)) cmd.ExecuteNonQuery();

                    CargarDatosIniciales(connection);
                }
            }
        }

        private void CargarDatosIniciales(SqliteConnection connection)
        {
            string checkUsers = "SELECT COUNT(*) FROM Users";
            using (var command = new SqliteCommand(checkUsers, connection))
            {
                if (Convert.ToInt32(command.ExecuteScalar()) == 0)
                {
                    string seed = "INSERT INTO Users (Name, Password) VALUES ('Administrador', 'admin'), ('Invitado', '1234')";
                    using (var seedCmd = new SqliteCommand(seed, connection)) seedCmd.ExecuteNonQuery();
                }
            }

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

        public DataTable Login(string username, string password)
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

        public void ActualizarPerfil(int userId, string newName, string newPass)
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

        public void BorrarCuenta(int userId)
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

        public DataTable ObtenerCategorias(int userId)
        {
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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Categories (Name, UserId) VALUES (@Name, @UserId)";
                    using (var command = new SqliteCommand(query, connection))
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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Categories WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Tasks (Name, FilePath, ExecuteAt, Status, LogMessage, CategoryId, UserId) VALUES (@Name, @FilePath, @ExecuteAt, @Status, '', @CategoryId, @UserId)";
                    using (var command = new SqliteCommand(query, connection))
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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
SELECT t.Id, t.Name, t.FilePath, t.ExecuteAt, t.Status, t.LogMessage, t.CategoryId, t.UserId,
       c.Name AS CategoryName, u.Name AS UserName
FROM Tasks t
LEFT JOIN Categories c ON t.CategoryId = c.Id
LEFT JOIN Users u ON t.UserId = u.Id
WHERE t.UserId = @UserId";
                    using (var command = new SqliteCommand(query, connection))
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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tasks WHERE Status = 0";
                    using (var command = new SqliteCommand(query, connection))
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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Name = @Name, FilePath = @FilePath, ExecuteAt = @ExecuteAt, CategoryId = @CategoryId WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
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

        public void CambiarEstado(int id, int estado, string log)
        {
            lock (_dbLock)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Status = @Status, LogMessage = @Log WHERE Id = @Id";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", estado);
                        command.Parameters.AddWithValue("@Log", log);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                    
                    string hist = "INSERT INTO TaskHistory (TaskId, ExecutedAt, Status, LogMessage) VALUES (@TaskId, @Date, @Status, @Log)";
                    using (var cmd = new SqliteCommand(hist, connection))
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
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT h.*, t.Name as TaskName FROM TaskHistory h JOIN Tasks t ON h.TaskId = t.Id WHERE t.UserId = @UserId ORDER BY h.ExecutedAt DESC LIMIT 100";
                    using (var command = new SqliteCommand(query, connection))
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
        private readonly ConcurrentDictionary<int, CancellationTokenSource> _tareasVivas;
        public event Action<DataRow> AlCambiarEstado;

        public ProcesadorTareas(AccesoDatos db)
        {
            _db = db;
            _tareasVivas = new ConcurrentDictionary<int, CancellationTokenSource>();
        }

        public void Iniciar()
        {
            DataTable pendientes = _db.ListarPendientes();
            foreach (DataRow fila in pendientes.Rows) Programar(fila);
        }

        public void Programar(DataRow filaTarea)
        {
            int id = Convert.ToInt32(filaTarea["Id"]);
            if (_tareasVivas.TryGetValue(id, out var viejoCts))
            {
                viejoCts.Cancel();
                viejoCts.Dispose();
                _tareasVivas.TryRemove(id, out _);
            }

            var cts = new CancellationTokenSource();
            _tareasVivas.TryAdd(id, cts);

            DateTime ejecutaEn = Convert.ToDateTime(filaTarea["ExecuteAt"]);
            TimeSpan espera = ejecutaEn - DateTime.Now;
            if (espera.TotalMilliseconds <= 0) espera = TimeSpan.Zero;

            var token = cts.Token;
            Task.Run(async () =>
            {
                try {
                    if (espera > TimeSpan.Zero) await Task.Delay(espera, token);
                    if (token.IsCancellationRequested) return;
                    EjecutarArchivo(filaTarea);
                }
                catch (TaskCanceledException) { }
                catch (Exception ex) { ActualizarEnBD(filaTarea, 3, ex.Message); }
                finally { _tareasVivas.TryRemove(id, out _); }
            }, token);
        }

        public void Cancelar(int id)
        {
            if (_tareasVivas.TryGetValue(id, out var cts)) cts.Cancel();
        }

        private void EjecutarArchivo(DataRow fila)
        {
            ActualizarEnBD(fila, 1, "Iniciando...");
            try {
                ProcessStartInfo info = new ProcessStartInfo { FileName = fila["FilePath"].ToString(), UseShellExecute = true };
                using (Process p = Process.Start(info)) ActualizarEnBD(fila, 2, "OK");
            }
            catch (Exception ex) { ActualizarEnBD(fila, 3, "Error: " + ex.Message); }
        }

        private void ActualizarEnBD(DataRow fila, int nuevoEstado, string mensaje)
        {
            int id = Convert.ToInt32(fila["Id"]);
            _db.CambiarEstado(id, nuevoEstado, mensaje);
            
            // Refrescar fila para el evento
            fila["Status"] = nuevoEstado;
            fila["LogMessage"] = mensaje;
            AlCambiarEstado?.Invoke(fila);
        }
    }
}
