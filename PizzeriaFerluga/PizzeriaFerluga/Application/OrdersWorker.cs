using CSVInterpeter;

using DatabaseHandler;
using DatabaseHandler.Models;

using FileSystemManager.Abstract;
using FileSystemManager.Concrete;

using Microsoft.Extensions.Hosting;

using PizzeriaFerluga.PizzaProcesser;
using PizzeriaFerluga.ReceiptExtensionMethods;

namespace PizzeriaFerluga.Application;

internal class OrdersWorker : IHostedService
{

    private readonly IFileRepository _fileRepository;
    private readonly PizzeriaContext _context;
    private readonly CSVReader _csvReader;
    private readonly IPizzaOrdersProcesser _pizzaProcesser;
    private readonly IFileReader _reader;

    public OrdersWorker(IFileRepository fileRepository, PizzeriaContext context, CSVReader csvReader, IPizzaOrdersProcesser pizzaProcesser, IFileReader reader)
    {
        _fileRepository = fileRepository;
        _context = context;
        _csvReader = csvReader;
        _pizzaProcesser = pizzaProcesser;
        _reader = reader;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Process started.");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("File structure main directory at: ");
        Console.ResetColor();
        Console.WriteLine($"{_fileRepository.GetFolderMainPath()}");
        Console.WriteLine();
        int ordersCount = 0;

        do
        {
            FileInfo? unprocessedFile = _fileRepository.UnprocessedOrders.GetFiles().FirstOrDefault();


            try
            {

                if (unprocessedFile is null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("no orders to process");
                    Console.ResetColor();
                    break;
                }

                Receipt receipt = new Receipt();

                var content = _reader.ReadFile(unprocessedFile.FullName);
                List<List<string>> csvOrders = _csvReader.GetAllOrders(content!);
                List<PizzaOrder> allPizzaOrders = _pizzaProcesser.GetPizzaOrders(csvOrders);

                receipt.Orders = allPizzaOrders;
                receipt.Price = allPizzaOrders.Sum(o => o.Price);
                _context.Receipts.Add(receipt);
                _context.PizzaOrders.AddRange(allPizzaOrders);
                _context.SaveChanges();

                File.WriteAllText(_fileRepository.GetReceiptFullPath(receipt.GetFileName()), receipt.GetContent());
                File.Move(unprocessedFile.FullName, Path.Combine(_fileRepository.ProcessedOrders.FullName, unprocessedFile.Name));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The process of the order n. {ordersCount} succedeed.");
                Console.WriteLine("Receipt created in the Receipt folder. ");
                Console.ResetColor();
            }
            catch (Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The process of the order n. {ordersCount} failed.");
                Console.WriteLine("Order File has been moved to the failed orders directory.");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                File.Move(unprocessedFile!.FullName, Path.Combine(_fileRepository.FailedOrders.FullName, unprocessedFile.Name));
            }

            Console.WriteLine();
            ordersCount++;
        }
        while (_fileRepository.UnprocessedOrders.GetFiles().Count() != 0);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Process ended.");
        Console.ResetColor();
        Console.WriteLine();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {

    }
}
