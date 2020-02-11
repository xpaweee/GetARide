using System;
using System.Security.Cryptography;
using System.Text;
using GetARide.Infrastructure.Extensions;

namespace GetARide.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;
        private static readonly int SaltSize = 40;
        public string GetHash(string value, string salt)
        {
            if(value.Empty())
                throw new ArgumentException("Can not generat salt from an empty value", nameof(value));
            if(salt.Empty())
                throw new ArgumentException("Can not generat salt from hashing value", nameof(value));
                
            var pbkdf2 = new Rfc2898DeriveBytes( Encoding.ASCII.GetBytes(value),GetBytes(salt),DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
                
        }

        private byte[] GetBytes(string salt)
        {
            throw new NotImplementedException();
        }

        public string GetSalt(string value)
        {
            if(value.Empty())
                throw new ArgumentException("Can not generat salt from an empty value", nameof(value));

            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }
    }
}