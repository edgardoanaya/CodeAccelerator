using System.Net;

namespace SoftwareOne.BaseLine.Core.Exceptions
{
    public class SwoNotFoundException : SwoCustomException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SwoNotFoundException(string message)
            : base(message, null, HttpStatusCode.NotFound) { }
    }
}