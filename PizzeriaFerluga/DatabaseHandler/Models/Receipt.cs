
namespace DatabaseHandler.Models;

public class Receipt
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    public virtual IEnumerable<PizzaOrder> Orders { get; set; } = null!;
}
