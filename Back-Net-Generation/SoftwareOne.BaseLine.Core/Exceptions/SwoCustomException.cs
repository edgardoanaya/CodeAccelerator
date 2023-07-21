using System.Net;

namespace SoftwareOne.BaseLine.Core.Exceptions
{
    public class SwoCustomException : Exception
    {
        public List<string>? ErrorMessages { get; }

        public HttpStatusCode StatusCode { get; }

        public SwoCustomException(string message, List<string>? errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            ErrorMessages = errors;
            StatusCode = statusCode;
        }
    }
}