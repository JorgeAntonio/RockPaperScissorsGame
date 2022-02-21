using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RockPaperScissors;
using RockPaperScissors.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//REGISTRAR LA CLASE PARA SER INJECTADO EN COMPONENTE
builder.Services.AddSingleton<Choices>();
builder.Services.AddSingleton<WinningRules>();

await builder.Build().RunAsync();
