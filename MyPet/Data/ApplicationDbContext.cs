using Microsoft.EntityFrameworkCore;
using MyPet.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Dog> Dogs { get; set; }

}
