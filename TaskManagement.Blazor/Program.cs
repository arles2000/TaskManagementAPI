using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaskManagement.Blazor;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registrar el handler para incluir la API Key en cada solicitud HTTP
builder.Services.AddTransient<ApiKeyHandler>();



// Configurar HttpClient para UserService con el handler ApiKeyHandler
builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/");
}).AddHttpMessageHandler<ApiKeyHandler>();

// Configurar HttpClient para TaskService con el handler ApiKeyHandler
builder.Services.AddHttpClient<ITaskService, TaskService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/");
}).AddHttpMessageHandler<ApiKeyHandler>();


await builder.Build().RunAsync();
