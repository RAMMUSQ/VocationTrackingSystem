using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string GroupName { get; set; }

        [Required]
        public List<string> MemberNames { get; set; }
    }
}