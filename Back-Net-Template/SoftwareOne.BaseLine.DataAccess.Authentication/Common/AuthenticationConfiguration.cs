using Microsoft.IdentityModel.Tokens;

namespace SoftwareOne.BaseLine.Authentication.Common
{
    public class AuthenticationConfiguration
    {
        public string JwtKey { get; set; } = null!;

        public int ExpirationTime { get; set; }

        public TokenValidationParameters Parameters { get; set; } = null!;
    }
}