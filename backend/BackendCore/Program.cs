using BackendCore.Services.InternalServices.Contracts;
using BackendCore.Utils;
using HomeManagementBackend.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog.Web;
using NLog;
using Shared;

namespace BackendCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Early init of NLog to allow startup and exception logging, before host is built
            var logger = LogManager.Setup()
                .LoadConfigurationFromAppSettings()
                .GetCurrentClassLogger();
            logger.Debug("init main");

            try
            {

                var builder = WebApplication.CreateBuilder(args);

                // NLog: Setup NLog for Dependency injection
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

                // Add services to the container.
                builder.Services.ConfigureLoggerService();
                builder.Services.ConfigureCors();

                builder.Services.AddControllers();
                    
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddAutoMapper(typeof(AssemblyReference));
                builder.Services.AddDbContext<HomeManagementDbContext>();

                var app = builder.Build();

                if (app.Environment.IsProduction())
                    app.UseHsts();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.All
                });

                app.UseCors("CorsPolicy");

                app.UseAuthorization();

                app.MapControllers();

                app.ConfigureExceptionHandler(
                    app.Services.GetRequiredService<ILoggerManager>());

                app.Run();
            }
            catch (Exception exception)
            {
                // NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
        }
    }
}
