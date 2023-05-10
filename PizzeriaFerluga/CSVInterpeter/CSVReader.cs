namespace CSVInterpeter
{
    public class CSVReader
    {
        public List<List<String>> GetAllOrders(IEnumerable<string> csvFileConverted)
        {
            List<string> pizzaDescription = new List<string>();
            List<List<string>> orders = new List<List<string>>();

            foreach (string csvLine in csvFileConverted)
            {
                pizzaDescription = csvLine.Split(new char[] { ',', ';' }).ToList();
                pizzaDescription = pizzaDescription.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
                orders.Add(pizzaDescription);
            }

            return orders;
        }
    }
}