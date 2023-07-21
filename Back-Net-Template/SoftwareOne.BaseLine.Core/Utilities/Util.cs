using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SoftwareOne.BaseLine.Core.Utilities
{
    public static class Util {

        public static string HashPassword(string password, out string salt)
        {
            // Generate a 128-bit salt using a sequence of cryptographically strong random bytes.
            byte[] saltBytes = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            salt = Convert.ToBase64String(saltBytes);
            return hashed;
        }

        public static bool VerifyHashedPassword(string password, string salt, string hashedPassword)
            {
                // Generate a 128-bit salt using a sequence of cryptographically strong random bytes.
                byte[] saltBytes = Convert.FromBase64String(salt); // divide by 8 to convert bits to bytes

                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                byte[] hashed = KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: saltBytes,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8);

                return CryptographicOperations.FixedTimeEquals(hashed, Convert.FromBase64String(hashedPassword));
            }
    }
}