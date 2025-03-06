using BlazorExercise.Demo.Components;

namespace BlazorExercise.Demo;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);

        WebApplication app = builder.Build();
        ConfigureApp(app);

        await app.RunAsync();
    }

    private static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        IServiceCollection services = builder.Services;
        services
            .AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();
    }
}
