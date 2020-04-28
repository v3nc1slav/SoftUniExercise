using SharedTrip.Models;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Service
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersService(ApplicationDbContext db)
        {
            this.dbContext = db;
        }

        public bool EmailExists(string email)
        {
            return this.dbContext.Users.Any(x => x.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = this.Hash(password);
            var user = this.dbContext.Users.FirstOrDefault(
                u => u.Username == username && u.Password == hashPassword);
            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public string GetUsername(string id)
        {
            var username = this.dbContext.Users
                .Where(x => x.Id == id)
                .Select(x => x.Username)
                .FirstOrDefault();
            return username;
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password),
            };
            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
        }

        public bool UsernameExists(string username)
        {
            return this.dbContext.Users.Any(x => x.Username == username);
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
