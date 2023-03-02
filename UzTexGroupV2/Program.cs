using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using UzTexGroupV2.Extensions;
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
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenLocalhost(1200);
                options.ListenLocalhost(1201, listenOptions =>
                {
                    listenOptions.UseHttps();
                });
            });
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

            app.Run();
        }
    }
}