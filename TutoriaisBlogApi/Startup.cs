using TutoriaisBlogApi.Context;
//using TutoriaisBlogApi.Services;
using Microsoft.EntityFrameworkCore;
using TutoriaisBlogApi.Services;

namespace TutoriaisBlogApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      // Add services to the container.
      services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();

      //Config de conexão com banco SqlServer.
      services.AddDbContext<AppDbContext>(options =>
          options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));

      //Config de conexão com banco MySQL.
      //services.AddDbContext<AppDbContext>(options =>
      //options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      services.AddScoped<IUsuarioService, UsuarioService>();
      services.AddScoped<IPostagemService, PostagemService>();
    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseCors(options =>
      {
        options.WithOrigins("http://54.207.212.51");
        options.AllowAnyMethod();
        options.AllowAnyHeader();
      });

      app.UseHttpsRedirection();
      app.UseAuthorization();
      app.MapControllers();

    }
  }
}
