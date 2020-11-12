using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Model
{
    public enum State : byte
    {
        Nomal = 0,
        Deleted = 1,
    }

    public static partial class ext
    {
        public static bool IsDeleted(this State target) { return target == State.Deleted; }
        public static State AsEmployeeState(this byte value) { return (State)value; }
    }
}