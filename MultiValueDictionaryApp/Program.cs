using Microsoft.Extensions.DependencyInjection;
using MultiValueDictionaryApp;
using MultiValueDictionaryApp.Interfaces;
using MultiValueDictionaryApp.Services;

StartApp();

static IServiceCollection InitServices()
{
    IServiceCollection? services = new ServiceCollection()
       .AddTransient<App>()
       .AddSingleton<IMessageService, MessageService>()
       .AddSingleton<ICommandService, CommandService>()
       .AddSingleton<IPrintResultService, PrintResultService>();

    return services;
}

static void StartApp()
{
    IServiceCollection? services = InitServices();
    ServiceProvider provider = services.BuildServiceProvider();
    var app = provider.GetService<App>();

    try
    {
        app.Run();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}