using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models;

public class Teams
{
    [Key]
    public int TeamId { get; set; }

    public string TeamName { get; set; }

    public string TeamAdmin { get; set; }
}