using DatabaseHandler.Models;

using System.Text;

namespace PizzeriaFerluga.ReceiptExtensionMethods;

public static class ReceiptOperations
{
    public static string GetContent(this Receipt receipt)
    {
        StringBuilder content = new StringBuilder();

        content.AppendLine($"Receipt number: {receipt.Id}");
        foreach (var item in receipt.Orders)
        {
            content.AppendLine($"{item.Description,-60}{item.Price,10}$");
        }
        content.AppendLine(new string('-', 70));
        content.AppendLine($"{"Total",-60}{receipt.Price,10}$");

        return content.ToString();
    }

    public static string GetFileName(this Receipt receipt)
        => ($"Receipt_{receipt.Id}_{DateTime.Now.ToString("yyyy MM dd HH mm ss")}");
}
