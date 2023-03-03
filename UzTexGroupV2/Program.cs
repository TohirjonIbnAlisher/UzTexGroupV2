using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using UzTexGroupV2.Extensions;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.MIddlewares;

namespace UzTexGroupV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("UztexGroupV2 is starting...");
            Console.Title = "UztexGroupV2";
            Console.WriteLine("Process Id: {0}", Environment.ProcessId);
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseUrls("http://*:1200");
            builder.Services
                .AddDbContexts(builder.Configuration)
                .ConfigureRepositories()
                .AddMiddlewares()
                .AddApplication()
                .AutentificationService(builder.Configuration);

            builder.AdSeridLogg(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Any", policyBuilder =>
                {
                    policyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .Build();
                });
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("Any");
            app.UseHttpsRedirection();
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseMiddleware<CorsPolicy>();
            app.UseStaticFiles(new StaticFileOptions()
            {
                HttpsCompression = HttpsCompressionMode.Compress
            });
            app.UseMiddleware<LocalizationTrackerMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute("default",
                "/{langCode=uz}/{controller=User}/{action=Index}",
                defaults: new { langCode = "uz" });

            Console.WriteLine("Migrating Database....");
            var dbService = app.Services.CreateScope().ServiceProvider.GetService<UzTexGroupDbContext>();
            dbService?.Database.EnsureDeleted();
            dbService?.Database.Migrate();
            app.Run();
        }
    }
}