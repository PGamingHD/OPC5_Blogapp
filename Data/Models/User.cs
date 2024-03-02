using System.ComponentModel.DataAnnotations;

namespace OPC5_Blogapp.Data.Models
{
    public enum PermissionRoles
    {
        Owner,
        Developer,
        Administrator,
        Moderator,
        User,
    }
    public class User
    
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Hashed { get; set; }
        public string Email { get; set; }

        public PermissionRoles Role { get; set; } = PermissionRoles.User;
    }
}
