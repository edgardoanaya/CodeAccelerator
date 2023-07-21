namespace SoftwareOne.BaseLine.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserAuthenticator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAuthenticator"></param>
        /// <returns></returns>
        string GenerateTokenAuthentication(User userAuthenticator);

        /// <summary>
        /// Validates the token authentication.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        string ValidateTokenAuthentication(string? token);

        /// <summary>
        /// Gets the Username from the token authentication.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetUsername(string? token);
    }
}