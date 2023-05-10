using FileSystemManager.Concrete;

namespace PizzeriaFerluga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new FileRepository("dawawdawawd");
            string path = a.GetFolderMainPath();
            Console.WriteLine(path);
            Console.WriteLine(a.ProcessedOrders.FullName);
            Console.WriteLine(a.UnprocessedOrders.FullName);
        }
    }
}