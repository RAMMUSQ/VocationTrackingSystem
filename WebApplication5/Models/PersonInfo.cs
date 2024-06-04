using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models;

public class PersonInfo
{
    [Key]
    public int  Id { get; set; }
    
    public string TeamName { get; set;}
    
    public DateTime Jobworkdate { get; set;}
    
    public int Kalanİzin { get; set; }

    public int  Kullanılanİzin { get; set; }

    public int ÇalışmaSenesi { get; set; }
    
}