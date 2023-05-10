namespace DatabaseHandler.Models;

public class PizzaOrder
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public virtual Receipt Receipt { get; set; } = null!;


}
