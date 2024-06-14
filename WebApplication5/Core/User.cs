using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } // Admin or User
        public ICollection<UserGroups> Groups { get; set; } = new List<UserGroups>(); // Navigation property for groups the user belongs to
    }
}