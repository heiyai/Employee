using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Model
{
    public abstract class BaseEntity : IEntity
    {
        public int ID { get; set; }
    }
}
