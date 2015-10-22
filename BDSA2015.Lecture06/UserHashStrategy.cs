using System;
using System.Security.Cryptography;
using System.Text;

namespace BDSA2015.Lecture06
{
    public abstract class HashStrategy
    {
        protected int _defaultSaltLength;

        private readonly HashAlgorithm _algorithm;

        public string Password { private get; set; }

        public string Salt { get; private set; }

        public string Hash => ComputeHash(Password, Salt ?? (Salt = GenerateSalt(_defaultSaltLength)));

        protected HashStrategy(HashAlgorithm algoritm)
        {
            _algorithm = algoritm;
        }

        protected string ComputeHash(string password, string salt)
        {
            var concat = string.Concat(password, salt);
            var bytes = Encoding.UTF8.GetBytes(concat);
            var hash = _algorithm.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public static string GenerateSalt(int length)
        {
            var p = new RNGCryptoServiceProvider();
            var bytes = new byte[length];
            p.GetNonZeroBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }

    public class SHA1User : HashStrategy
    {
        public SHA1User() :
            base(new SHA1Managed())
        {
            _defaultSaltLength = 20;
        }
    }

    public class SHA512User : HashStrategy
    {
        public SHA512User() :
            base(new SHA512Managed())
        {
            _defaultSaltLength = 20;
        }
    }
}
