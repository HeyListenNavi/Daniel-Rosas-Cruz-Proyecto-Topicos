using System;

namespace Daniel_Rosas_Cruz.Models
{

    // enum para el estado de las tareas
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed,
        Failed
    }

    // clase modelo para representar una tarea
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public DateTime ExecuteAt { get; set; }
        public TaskStatus Status { get; set; }
        public string LogMessage { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}
