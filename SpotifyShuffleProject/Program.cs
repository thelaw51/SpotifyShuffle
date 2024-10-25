using AspNet.Security.OAuth.Spotify;
using Blazored.LocalStorage;
using MudBlazor.Services;
using SpotifyShuffleProject.Components;
using SpotifyShuffleProject.Services;
using SpotifyShuffleProject.Services.Interfaces;
using DotNetEnv;


Env.Load("stuff.env");

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();


// Add services to the container.
builder.Services.AddRazorComponents()
   .AddInteractiveServerComponents()
   .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<IAuthService, AuthService>();

// Add controller services
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseWebAssemblyDebugging();
}
else
{
   app.UseExceptionHandler("/Error", createScopeForErrors: true);
   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAntiforgery();

app.UseAuthorization();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AddInteractiveWebAssemblyRenderMode()
   .AddAdditionalAssemblies(typeof(SpotifyShuffleProject.Client._Imports).Assembly);

// Map controller routes
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();