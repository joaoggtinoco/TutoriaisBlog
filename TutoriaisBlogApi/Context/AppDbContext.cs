using TutoriaisBlogApi.Models;
using Microsoft.EntityFrameworkCore;

//O objetivo dessa classe é fazer a ponte entre a API e o banco 
namespace TutoriaisBlogApi.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Postagem> Postagens { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //  modelBuilder.Entity<Usuario>().HasData(
    //    new Usuario
    //    {
    //      Id = 1,
    //      Nome = "Josefina Da Silva",
    //      Email = "josefina@gmail.com",
    //      Idade = 20
    //    },
    //    new Usuario
    //    {
    //      Id = 2,
    //      Nome = "Marlucio De Oliveira",
    //      Email = "marlucio@gmail.com",
    //      Idade = 25
    //    }
    //    );

    //Usuario usuario = new Usuario
    //{
    //  Id = 1,
    //  Nome = "Josefina Da Silva",
    //  Email = "josefina@gmail.com",
    //  Idade = 20
    //};
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //  modelBuilder.Entity<Usuario>()
      //    .HasOne(usuario => usuario.Postagens)
      //    .WithOne(postagem => postagem.Usuario)
      //    .HasForeignKey<Postagem>(postagem => postagem.UsuarioId);

      modelBuilder.Entity<Postagem>()
        .HasOne(postagem => postagem.Usuario)
        .WithMany(usuario => usuario.Postagens)
        .HasForeignKey(postagem => postagem.UsuarioId);
    }
  }
}

