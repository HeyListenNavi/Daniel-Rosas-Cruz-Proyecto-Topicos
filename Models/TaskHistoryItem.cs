using System;

namespace Daniel_Rosas_Cruz.Models
{
    public class TaskHistoryItem
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime ExecutedAt { get; set; }
        public TaskStatus Status { get; set; }
        public string LogMessage { get; set; }
    }
}
