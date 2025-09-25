using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Services.Base64;
using Services.Hashing;
using Services.Hashing.Strategy;
using Services.Url;
using theonlytool;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();
return;

static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(baseAddress) });
    services.AddMudServices();
    
    // Services
    services.AddSingleton<Base64Service>();
    services.AddSingleton<UrlService>();
    // Hash service
    services.AddSingleton<IHashService, HashService>();
    services.AddSingleton<IHashProcessor<SupportedHash>, Md5Processor>();
    services.AddSingleton<IHashProcessor<SupportedHash>, Sha1Processor>();
    services.AddSingleton<IHashProcessor<SupportedHash>, Sha256Processor>();
    services.AddSingleton<IHashProcessor<SupportedHash>, Sha384Processor>();
    services.AddSingleton<IHashProcessor<SupportedHash>, Sha512Processor>();

#if DEBUG
    services.AddSassCompiler();
#endif
}