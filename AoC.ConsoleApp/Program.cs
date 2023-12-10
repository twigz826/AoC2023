using AoC.ConsoleApp.Day1;
using AoC.ConsoleApp.Day2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<Day2App>().RunChallenges();
}
catch (Exception ex)
{
    Console.WriteLine($"Application failed: {ex.Message}");
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddTransient<Day1App>();
            services.AddTransient<Day2App>();
        });
}