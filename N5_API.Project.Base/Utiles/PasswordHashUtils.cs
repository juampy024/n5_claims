using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace N5_API.Project.Base.Utiles
{
    public class PasswordHashUtils
    {
        public (string passwordHash, string passwordSalt) CreatePasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordSalt = hmac.Key;
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return (Convert.ToBase64String(passwordHash), Convert.ToBase64String(passwordSalt));
        }

        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            byte[] hashPassword = Convert.FromBase64String(passwordHash);
            byte[] saltPassword = Convert.FromBase64String(passwordSalt);

            using var hmac = new HMACSHA512(saltPassword);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return StructuralComparisons.StructuralEqualityComparer.Equals(computedHash, hashPassword);
        }
    }
}
