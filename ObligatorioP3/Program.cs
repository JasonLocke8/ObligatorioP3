using Libreria.LogicaAccesoDatos;
using Libreria.LogicaAccesoDatos.Repositorios;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using Libreria.LogicaAplicacion.CasosUso.CUAgencia;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using Libreria.LogicaAplicacion.CasosUso.CUAutenticacion;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAutenticacion;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios;
using Libreria.LogicaAplicacion.CasosUso.CUEnvios;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUSeguimiento;
using Libreria.LogicaAplicacion.CasosUso.CUSeguimientoEnvio;

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
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioEnvioComun, RepositorioEnvioComun>();
            builder.Services.AddScoped<IRepositorioEnvioUrgente, RepositorioEnvioUrgente>();
            builder.Services.AddScoped<IRepositorioSeguimientoEnvio, RepositorioSeguimientoEnvio>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();

            //DI - CASOS USO

            // Usuario
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUListarUsuario, CUListarUsuario>();
            builder.Services.AddScoped<ICUEditarUsuario, CUEditarUsuario>();
            builder.Services.AddScoped<ICUEliminarUsuario, CUEliminarUsuario>();

            // Agencia
            builder.Services.AddScoped<ICUAltaAgencia, CUAltaAgencia>();
            builder.Services.AddScoped<ICUListarAgencia, CUListarAgencia>();
            builder.Services.AddScoped<ICUEditarAgencia, CUEditarAgencia>();
            builder.Services.AddScoped<ICUEliminarAgencia, CUEliminarAgencia>();

            // Envios
            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUListarEnvio, CUListarEnvio>();
            builder.Services.AddScoped<ICUFinalizarEnvio, CUFinalizarEnvio>();
            builder.Services.AddScoped<ICUAgregarSeguimiento, CUAgregarSeguimiento>();

            // Login
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddSession();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
