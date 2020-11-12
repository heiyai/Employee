using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Model
{
    [Serializable]
    public class Task: BaseEntity
    {
        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Deadline { get; set; }
        public State State { get; set; }

    }
}
