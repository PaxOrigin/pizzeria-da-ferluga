using CSVInterpeter;

using DatabaseHandler;
using DatabaseHandler.Models;

using FileSystemManager.Concrete;

using System.Text;

namespace PizzeriaFerluga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new FileRepository("aaa");
            List<PizzaOrder> pizzaOrders = new List<PizzaOrder>();
            PizzeriaContext context = new PizzeriaContext();
            CSVReader csvReader = new CSVReader();
            PizzaOrdersProcesser pizzaProcesser = new PizzaOrdersProcesser();
            FileReader reader = new FileReader();
            do
            {

                Receipt receipt = new Receipt();
                if (a.UnprocessedOrders.GetFiles().Count() == 0)
                    break;
                var content = reader.ReadFile(a.UnprocessedOrders.GetFiles()[0].FullName);
                List<List<string>> csvOrders = csvReader.GetAllOrders(content!);
                List<PizzaOrder> allPizzaOrders = pizzaProcesser.GetPizzaOrders(csvOrders);
                receipt.Orders = allPizzaOrders;
                receipt.Price = allPizzaOrders.Sum(o => o.Price);
                context.Receipts.Add(receipt);
                context.PizzaOrders.AddRange(allPizzaOrders);
                string receiptFilePath = Path.Combine(a.Receipts.FullName, $"Receipt_{receipt.Id}");
                StringBuilder receiptDescription = new StringBuilder();
                receiptDescription.AppendLine($"Receipt number: {receipt.Id}");
                foreach (var item in allPizzaOrders)
                {
                    receiptDescription.AppendLine($"{item.Description,-50}{item.Price,10}$");
                }
                receiptDescription.AppendLine(new string('-', 60));
                receiptDescription.AppendLine($"{"Total",-60}{receipt.Price,10}");

                File.WriteAllText(receiptFilePath, receiptDescription!.ToString());
                File.Move(a.UnprocessedOrders.GetFiles()[0].FullName, Path.Combine(a.ProcessedOrders.FullName, a.UnprocessedOrders.GetFiles()[0].Name));

            }
            while (a.UnprocessedOrders.GetFiles().Count() != 0);

        }
    }
}