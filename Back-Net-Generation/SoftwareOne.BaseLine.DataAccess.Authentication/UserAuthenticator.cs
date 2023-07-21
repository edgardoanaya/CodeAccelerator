using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SoftwareOne.BaseLine.Authentication.Common;
using System.Security.Authentication;
using SoftwareOne.BaseLine.ApplicationTexts;
using SoftwareOne.BaseLine.Core.Exceptions;

namespace SoftwareOne.BaseLine.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Email"></param>
    /// <param name="Name"></param>
    /// <param name="Id"></param>
    /// <param name="Username"></param>
    public record User(string Username, string Email, string Name, int Id);

    /// <summary>
    /// 
    /// </summary>
    public class UserAuthenticator : IUserAuthenticator
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Microsoft.Extensions.Options.IOptions<AuthenticationConfiguration> authenticationConfiguration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticationConfiguration"></param>
        public UserAuthenticator(Microsoft.Extensions.Options.IOptions<AuthenticationConfiguration> authenticationConfiguration)
        {
            this.authenticationConfiguration = authenticationConfiguration;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAuthenticator"></param>
        /// <returns></returns>
        public string GenerateTokenAuthentication(User userAuthenticator)
        {
            var decryptedKey = Encoding.ASCII.GetBytes(authenticationConfiguration.Value.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Email, userAuthenticator?.Email ?? string.Empty),
                    new Claim(ClaimTypes.NameIdentifier, userAuthenticator?.Name ?? string.Empty),
                    new Claim(ClaimTypes.Sid, userAuthenticator?.Id.ToString() ?? string.Empty),
                    new Claim(ClaimTypes.UserData, userAuthenticator?.Username?? string.Empty)
                }),
                Expires = DateTime.UtcNow.AddMinutes(authenticationConfiguration.Value.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(decryptedKey), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            var bearerToken = tokenHandler.WriteToken(createdToken);

            return bearerToken;
        }

        /// <summary>
        /// Validates the token authentication.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>string</returns>
        public string ValidateTokenAuthentication(string? token)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authenticationConfiguration.Value.JwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
            };
            try
            {
                var result = tokenHandler.ValidateToken(token, tokenValidationParameters, out var _);
                Claim? claim = result.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid);
                if (claim!= null)
                {
                    return claim.Value;
                }
            }
            catch (System.ArgumentException)
            {
                throw new AuthenticationException(ResourceValidations.Forbidden);
            }
            catch (SecurityTokenExpiredException)
            {
                throw new SwoUnauthorizedException(ResourceValidations.Unauthorized);
            }
            throw new AuthenticationException(ResourceValidations.Forbidden);
        }

        /// <summary>
        /// Gets the Username from the token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetUsername(string? token)
        {
            if (token == null) {
                return "Anonymous";
            }
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authenticationConfiguration.Value.JwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
            };
            var result = tokenHandler.ValidateToken(token, tokenValidationParameters, out var _);
            Claim? claim = result.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData);
            if (claim!= null)
            {
                return claim.Value;
            }
            throw new AuthenticationException(ResourceValidations.Forbidden);
        }
    }
}