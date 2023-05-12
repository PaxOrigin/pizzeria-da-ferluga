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
                if (string.IsNullOrWhiteSpace(csvLine))
                    continue;

                pizzaDescription = csvLine.Split(';').ToList();

                if (csvLine.Count(p => p == ';') != 2)
                {
                    throw new InvalidDataException("The string in the order file is not in a correct format");
                }

                if (pizzaDescription.Count() == 3 && !String.IsNullOrWhiteSpace(pizzaDescription[2]))
                {
                    List<string> Ingredients = pizzaDescription[2].Split(',').ToList();
                    pizzaDescription.RemoveAt(2);
                    pizzaDescription.AddRange(Ingredients);
                }
                pizzaDescription = pizzaDescription.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
                orders.Add(pizzaDescription);
            }

            return orders;
        }
    }
}