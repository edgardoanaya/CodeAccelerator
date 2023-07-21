using System.Net;

namespace SoftwareOne.BaseLine.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class SwoDomainValidationException : SwoCustomException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SwoDomainValidationException(string message)
           : base(message, null, HttpStatusCode.BadRequest) { }
    }
}