using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Model
{
    [Serializable]
    [Table("Task")]
    public class Task: BaseEntity
    {
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
        public State State { get; set; }

    }
}
