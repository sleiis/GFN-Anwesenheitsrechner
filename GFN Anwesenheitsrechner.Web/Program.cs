using Blazored.SessionStorage;
using GFN_Anwesenheitsrechner.Web.Components;
using GFN_Anwesenheitsrechner.Web.Database;
using GFN_Anwesenheitsrechner.Web.Extensions;
using GFN_Anwesenheitsrechner.Web.Lists;
using MudBlazor.Services;

namespace GFN_Anwesenheitsrechner.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SQLitePCL.Batteries.Init();
            ConnectionManager.CreateDatabase();
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddBlazoredSessionStorage(); //sesion cookies
            // Add MudBlazor services
            builder.Services.AddMudServices();
            builder.Services.AddHttpClient();
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSingleton<SQLQuery>();
            builder.Services.AddSingleton<PasswordManager>();
            builder.Services.AddSingleton<ConnectionManager>();
            builder.Services.AddScoped<PresenecManager>();
            builder.Services.AddSingleton<UsersList>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
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
}
