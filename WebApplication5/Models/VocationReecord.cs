using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models;

public class VocationRecord
{
    [Key]
    public int Id { get; set; }

    public string İzinTürü { get; set; }
    
    public int İzinGünü { get; set; }
    
    public string Onay { get; set; }
    
    
}