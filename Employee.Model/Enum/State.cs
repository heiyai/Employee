namespace Employee.Model
{
    public enum State
    {
        Nomal = 0,
        Deleted = 1,
    }

    public static partial class ext
    {
        public static bool IsDeleted(this State target) { return target == State.Deleted; }
        public static State AsState(this byte value) { return (State)value; }
    }
}