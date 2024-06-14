using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
    }
}