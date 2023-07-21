using System.Net;

namespace SoftwareOne.BaseLine.Core.Exceptions
{
    public class SwoForbiddenException : SwoCustomException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SwoForbiddenException(string message)
            : base(message, null, HttpStatusCode.Forbidden) { }
    }
}