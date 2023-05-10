using CSVInterpeter;

using DatabaseHandler;

using FileSystemManager.Abstract;
using FileSystemManager.Concrete;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using PizzeriaFerluga.Application;
using PizzeriaFerluga.PizzaProcesser;

namespace PizzeriaFerluga.IOC
{
    public static class Worker
    {
        public static IHostBuilder Startup()
        {
            var myConfig = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();


            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    var connectionString = context.Configuration.GetConnectionString("DB1");
                    var filePath = context.Configuration.GetSection("Folders").GetValue<string>("MainFolder") ?? string.Empty;
                    filePath = Directory.Exists(filePath) ? filePath : Path.GetTempPath();
                    services.AddHostedService<OrdersWorker>();
                    services.AddDbContext<PizzeriaContext>(options => options.UseSqlServer(connectionString));
                    services.AddTransient<IFileRepository>(_ => new FileRepository(filePath));
                    services.AddTransient<CSVReader>();
                    services.AddTransient<IFileReader, FileReader>();
                    services.AddTransient<IPizzaOrdersProcesser, PizzaOrdersProcesser>();
                });
        }

    }
}
