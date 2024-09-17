using Ginilytics.Common.Utility.Contract;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Ginilytics.Common.Utility
{
    public class PasswordSecurity : IPasswordSecurity
    {
        public int SALT_BYTES, HASH_BYTES, PBKDF2_ITERATIONS;
        public const int HASH_SECTIONS = 4;
        public const int ITERATION_INDEX = 0;
        public const int HASH_SIZE_INDEX = 1;
        public const int SALT_INDEX = 2;
        public const int PBKDF2_INDEX = 3;

        public string CreateHash(string password)
        {
            System.Random random = new System.Random();
            SALT_BYTES = random.Next(20, 50);
            HASH_BYTES = random.Next(10, 80);
            PBKDF2_ITERATIONS = random.Next(100, 90000);
            byte[] salt = new byte[SALT_BYTES - 1 + 1];

            try
            {
                using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider())
                {
                    csprng.GetBytes(salt);
                }
            }
            catch (CryptographicException ex)
            {
                throw new CannotPerformOperationException("Random number generator not available.", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to random number generator.", ex);
            }

            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTES);
            string parts = PBKDF2_ITERATIONS + ":" + hash.Length + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
            return parts;
        }

        public bool VerifyPassword(string password, string goodHash)
        {
            char[] delimiter = new[] { ':' };
            string[] split = goodHash.Split(delimiter);

            if (split.Length != HASH_SECTIONS)
                throw new InvalidHashException("Fields are missing from the password hash.");

            int iterations = 0;

            try
            {
                iterations = Int32.Parse(split[ITERATION_INDEX]);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to Int32.Parse", ex);
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException("Could not parse the iteration count as an integer.", ex);
            }
            catch (OverflowException ex)
            {
                throw new InvalidHashException("The iteration count is too large to be represented.", ex);
            }

            if (iterations < 1)
                throw new InvalidHashException("Invalid number of iterations. Must be >= 1.");

            byte[] salt = null;

            try
            {
                salt = Convert.FromBase64String(split[SALT_INDEX]);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to Convert.FromBase64String", ex);
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException("Base64 decoding of salt failed.", ex);
            }

            byte[] hash = null;

            try
            {
                hash = Convert.FromBase64String(split[PBKDF2_INDEX]);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to Convert.FromBase64String", ex);
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException("Base64 decoding of pbkdf2 output failed.", ex);
            }

            int storedHashSize = 0;

            try
            {
                storedHashSize = Int32.Parse(split[HASH_SIZE_INDEX]);
            }
            catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to Int32.Parse", ex);
            }
            catch (FormatException ex)
            {
                throw new InvalidHashException("Could not parse the hash size as an integer.", ex);
            }
            catch (OverflowException ex)
            {
                throw new InvalidHashException("The hash size is too large to be represented.", ex);
            }

            if (storedHashSize != hash.Length)
                throw new InvalidHashException("Hash length doesn't match stored hash length.");

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = System.Convert.ToUInt32(a.Length) ^ System.Convert.ToUInt32(b.Length);
            int i = 0;

            while (i < a.Length && i < b.Length)
            {
                diff = diff | System.Convert.ToUInt32((a[i] ^ b[i]));
                i += 1;
            }

            return diff == 0;
        }

        private byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (Rfc2898DeriveBytes pb = new Rfc2898DeriveBytes(password, salt))
            {
                pb.IterationCount = iterations;
                return pb.GetBytes(outputBytes);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    class InvalidHashException : Exception
    {
        public InvalidHashException()
        {
        }

        public InvalidHashException(string message) : base(message)
        {
        }

        public InvalidHashException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    class CannotPerformOperationException : Exception
    {
        public CannotPerformOperationException()
        {
        }

        public CannotPerformOperationException(string message) : base(message)
        {
        }

        public CannotPerformOperationException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}
