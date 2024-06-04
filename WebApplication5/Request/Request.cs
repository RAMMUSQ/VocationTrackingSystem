using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Request;

public class LoginRequest
{  
    [Key]
   // public int AppId { get; set; }
    
   // public string Name { get; set; } = string.Empty;

   // public string LastName { get; set; } = string.Empty;
     
    public  string UserName   { get; set; } = string.Empty;

    public  string Password  { get; set; } = string.Empty;

   // public bool? Gender { get; set; }

    //public DateTime? Birthdate { get; set; }

   // public string PhoneNumber { get; set; }
    
    public DateTime? CreatedDate { get; set; }
     
    public DateTime? UpdatedDate { get; set; }
}
   

