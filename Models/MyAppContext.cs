using Microsoft.EntityFrameworkCore;
namespace samaranipi.Models;

public class MyAppContext : DbContext
{
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<ContractStage> ContractStages { get; set; } = null!;
    public MyAppContext(DbContextOptions<MyAppContext> options)
        : base(options){

        // Database.EnsureDeleted();
        Database.EnsureCreated();
    } 
        
}