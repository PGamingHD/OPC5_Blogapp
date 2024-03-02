using Microsoft.EntityFrameworkCore;
using OPC5_Blogapp.Data;
using OPC5_Blogapp.Data.Models;

namespace Services.Users
{
    public interface IUserService
    {
        void AddUser(User user);
        User? GetUserByUsername(string username);
        Task<bool> UpdateUserPassword(string username, string newPassword);
    }
}
