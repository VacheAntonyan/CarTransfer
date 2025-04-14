using CarTransfer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System;

namespace CarTransfer
{
    public class UserService
    {
        private readonly Datacontext _dbContext;

        public UserService(Datacontext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public bool Register(string username, string password)
        {
            var existingUser = _dbContext.users.SingleOrDefault(u => u.Username == username);
            if (existingUser != null) return false; 

            var hashedPassword = HashPassword(password);

            var user = new User
            {
                Username = username,
                PasswordHash = hashedPassword.Hash,
                Salt = hashedPassword.Salt
            };

            _dbContext.users.Add(user);
            _dbContext.SaveChanges();

            return true;
        }

        
        public bool VerifyLogin(string username, string password)
        {
            var user = _dbContext.users.SingleOrDefault(u => u.Username == username);
            if (user == null) return false;

            return VerifyPassword(password, user.PasswordHash, user.Salt);
        }

        private PasswordHash HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            return new PasswordHash { Hash = hash, Salt = salt };
        }

        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 100_000, HashAlgorithmName.SHA256);
            byte[] computedHash = pbkdf2.GetBytes(32);

            return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
        }

        
        public struct PasswordHash
        {
            public byte[] Hash;
            public byte[] Salt;
        }
    }
}