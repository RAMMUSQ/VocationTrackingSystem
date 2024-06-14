using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class UserGroups
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Group name
        public ICollection<User> Members { get; set; } = new List<User>(); // Navigation property for users in the group
    }
}