using JUAN_MARIA_P1_AP1.Components;
using static JUAN_MARIA_P1_AP1.Components.DAL.Contexo;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();


        // add agregamos ConStr para la base de datos
        var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

        //agregando contexto
        object value = builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(ConStr));


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();


        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}