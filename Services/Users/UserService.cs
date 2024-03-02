using Microsoft.EntityFrameworkCore;
using OPC5_Blogapp.Data;
using OPC5_Blogapp.Data.Models;
using Konscious.Security.Cryptography;
using System.Text;

namespace Services.Users
{
    public class UserService(ApplicationDbContext _context) : IUserService
    {
        private readonly ApplicationDbContext context = _context;

        public void AddUser(User user)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(user.Hashed))
            {
                Salt = Encoding.UTF8.GetBytes("YourSer123.123@21!3.123123@3123123!##21321321@21i21522199omgkmkmv21231.2312312!#23@2131.23123i1ijgi2382t91aslfsplgasda"),
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            byte[] hash = argon2.GetBytes(64);

            user.Hashed =  Convert.ToBase64String(hash);
            user.Role = PermissionRoles.User;

            context.Users.Add(user);
            context.SaveChanges();
        }
        public User? GetUserByUsername(string username)
        {
            User? fetchedUser = context.Users.FirstOrDefault(u => u.Username == username);

            return fetchedUser;
        }
        public async Task<bool> UpdateUserPassword(string username, string newPassword)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user != null)
            {
                user.Hashed = newPassword;
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}