using System.Net;

namespace SoftwareOne.BaseLine.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class SwoFormNotAvaliableException : SwoCustomException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SwoFormNotAvaliableException(string message)
           : base(message, null, HttpStatusCode.InternalServerError) { }
    }
}