using AssetsBusinessLogic.BusinessLogicInterface;
using Microsoft.AspNetCore.Http.Features;

namespace Assets;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.Configure<FormOptions>(options => { options.ValueCountLimit = 2048; });
        services.AddControllersWithViews();
        services.AddServerSideBlazor();
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IAssetsBusinessLogic, AssetsBusinessLogic.BusinessLogic.AssetsBusinessLogic>();
        services.AddTransient<IDeviceGroupBusinessLogic, AssetsBusinessLogic.BusinessLogic.DeviceGroupBusinessLogic>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            endpoints.MapControllers();
            endpoints.MapBlazorHub();
        });
    }
}