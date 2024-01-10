using Microsoft.EntityFrameworkCore;
using Sisteminha.Data;
using Sisteminha.Helper;
using Sisteminha.Repository;
using Sisteminha.Repositorys;

namespace Sisteminha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Adciona o HTTP Context para Logar e Deslogar
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Adiciona Servi?o do SQL Server no Contexto de BancoConext
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            //Adicionar Interface
            builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
            builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
            builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddScoped<IEmail, Email>();

            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=login}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
