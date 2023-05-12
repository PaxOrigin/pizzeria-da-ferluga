using Microsoft.Extensions.Hosting;

using PizzeriaFerluga.IOC;

namespace PizzeriaFerluga
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Worker.Startup().Build().Run();

        }
    }
}