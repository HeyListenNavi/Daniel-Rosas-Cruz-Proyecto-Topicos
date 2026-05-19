using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Daniel_Rosas_Cruz.Data;
using Daniel_Rosas_Cruz.Models;

namespace Daniel_Rosas_Cruz.Engine
{
    // clase para ejecutar las tareas
    public class TaskSchedulerEngine
    {
        private readonly TaskRepository _repository;
        private readonly ConcurrentDictionary<int, CancellationTokenSource> _scheduledTasks;

        public event Action<TaskItem> OnTaskStatusChanged;

        public TaskSchedulerEngine(TaskRepository repository)
        {
            _repository = repository;
            _scheduledTasks = new ConcurrentDictionary<int, CancellationTokenSource>();
        }

        public void Start()
        {
            var pendingTasks = _repository.GetPendingTasks();
            foreach (var task in pendingTasks)
            {
                ScheduleTask(task);
            }
        }

        public void ScheduleTask(TaskItem taskItem)
        {
            // cancelar la tarea si ya está programada para evitar duplicados
            if (_scheduledTasks.TryGetValue(taskItem.Id, out var existingCts))
            {
                existingCts.Cancel();
                existingCts.Dispose();
                _scheduledTasks.TryRemove(taskItem.Id, out _);
            }

            var cts = new CancellationTokenSource();
            _scheduledTasks.TryAdd(taskItem.Id, cts);

            TimeSpan delay = taskItem.ExecuteAt - DateTime.Now;
            if (delay.TotalMilliseconds <= 0)
            {
                delay = TimeSpan.Zero;
            }

            var token = cts.Token;

            Task.Run(async () =>
            {
                try
                {
                    if (delay > TimeSpan.Zero)
                    {
                        await Task.Delay(delay, token);
                    }

                    if (token.IsCancellationRequested)
                        return;

                    ExecuteTask(taskItem);
                }
                catch (TaskCanceledException)
                {
                }
                catch (Exception ex)
                {
                    UpdateStatus(taskItem, Models.TaskStatus.Failed, ex.Message);
                }
                finally
                {
                    _scheduledTasks.TryRemove(taskItem.Id, out var existing);
                }
            }, token);
        }

        public void CancelTask(int taskId)
        {
            if (_scheduledTasks.TryGetValue(taskId, out var cts))
            {
                cts.Cancel();
            }
        }

        private void ExecuteTask(TaskItem taskItem)
        {
            UpdateStatus(taskItem, Models.TaskStatus.InProgress, "Iniciando proceso...");

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = taskItem.FilePath,
                    UseShellExecute = true
                };
                
                using (Process process = Process.Start(startInfo))
                {
                    UpdateStatus(taskItem, Models.TaskStatus.Completed, "Proceso ejecutado con éxito.");
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(taskItem, Models.TaskStatus.Failed, $"Error al ejecutar: {ex.Message}");
            }
        }

        private void UpdateStatus(TaskItem taskItem, Models.TaskStatus newStatus, string logMessage)
        {
            taskItem.Status = newStatus;
            taskItem.LogMessage = logMessage;
            
            _repository.UpdateTaskStatusAndLog(taskItem.Id, newStatus, logMessage);
            
            OnTaskStatusChanged?.Invoke(taskItem);
        }
    }
}
