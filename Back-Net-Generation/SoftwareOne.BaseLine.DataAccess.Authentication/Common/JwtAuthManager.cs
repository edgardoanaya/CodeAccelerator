//using System.Text;
//using Microsoft.Extensions.Options;
//using System.Collections.Immutable;
//using System.Collections.Concurrent;

//namespace SoftwareOne.BaseLine.Authentication.Common
//{
//    public class JwtAuthManager
//    {
//        public IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary => _usersRefreshTokens.ToImmutableDictionary();
//        private readonly ConcurrentDictionary<string, RefreshToken> _usersRefreshTokens;  // can store in a database or a distributed cache
//        private readonly JwtTokenConfig _jwtTokenConfig;
//        private readonly byte[] _secret;

//        /// <summary>
//        /// 
//        /// </summary>
//        private readonly IOptions<AuthenticationConfiguration> authenticationConfiguration;

//        public JwtAuthManager(IOptions<AuthenticationConfiguration> authenticationConfigurationJwtTokenConfig, jwtTokenConfig)
//        {
//            _jwtTokenConfig = jwtTokenConfig;
//            _usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
//            _secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret);
//        }
//    }
//}
