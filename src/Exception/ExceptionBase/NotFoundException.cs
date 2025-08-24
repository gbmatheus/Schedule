using System.Net;

namespace Exception.ExceptionBase
{
    public class NotFoundException : ScheduleExceptionBase
    {
        public NotFoundException(string message) : base(message) { }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return new List<string> { Message };
        }
    }
}
