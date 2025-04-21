using Libreria.LogicaAccesoDatos;
using Libreria.LogicaAccesoDatos.Repositorios;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace ObligatorioP3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.
            // Registrar el DbContext en el contenedor de servicios
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DI - REPOS
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioEnvioComun, RepositorioEnvioComun>();
            builder.Services.AddScoped<IRepositorioEnvioUrgente, RepositorioEnvioUrgente>();
            builder.Services.AddScoped<IRepositorioSeguimientoEnvio, RepositorioSeguimientoEnvio>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();



            //DI - CASOS USO
            //builder.Services.AddScoped<ICUAltaGenero, CUAltaGenero>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
