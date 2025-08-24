using System.Net;

namespace Exception.ExceptionBase
{
    public class DomainException: ScheduleExceptionBase
    {
        public DomainException(string message) : base(message)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return new List<string> { Message };
        }
    }
}
