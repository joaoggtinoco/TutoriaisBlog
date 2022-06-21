using TutoriaisBlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TutoriaisBlogApi.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Usuario> Usuarios{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Usuario>().HasData(
        new Usuario
        {
          Id = 1,
          Nome = "Josefina Da Silva",
          Email = "josefina@gmail.com",
          Idade = 20
        },
        new Usuario
        {
          Id = 2,
          Nome = "Marlucio De Oliveira",
          Email = "marlucio@gmail.com",
          Idade = 25
        }
        );

    }
  }
}

