using System.Net;

namespace SoftwareOne.BaseLine.Core.Exceptions
{
    public class SwoUnauthorizedException : SwoCustomException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SwoUnauthorizedException(string message)
            : base(message, null, HttpStatusCode.Unauthorized) { }
    }
}