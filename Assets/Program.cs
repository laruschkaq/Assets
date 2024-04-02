using Assets;
using Serilog;
using Serilog.Events;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        try
        {
            Log.Information("Starting Project");
            CreateHostBuilder(args).Build().Run();

        }
        catch (Exception e)
        {
            Log.Fatal(e, "Terminated");

            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog((context, provider, configure) =>
            {
                configure.ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(provider)
                    .Enrich.FromLogContext();

            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseIISIntegration();
                webBuilder.UseStartup<Startup>();
            });
}