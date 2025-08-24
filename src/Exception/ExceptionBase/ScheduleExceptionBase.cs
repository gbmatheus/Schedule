namespace Exception.ExceptionBase
{
    public abstract class ScheduleExceptionBase : System.Exception
    {
        protected ScheduleExceptionBase(string message) : base(message) { }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
