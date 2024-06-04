using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    
    public DbSet<User> Users { get; set; }
    
    public DbSet<StoredTokens> StoredTokens { get; set; }
    
    public DbSet<PersonInfo>  PersonInfo { get; set; }
    
    public DbSet<Teams> Teams { get; set; }
    
    public DbSet<VocationRecord> VocationRecords { get; set; }
    
  
    
         
}