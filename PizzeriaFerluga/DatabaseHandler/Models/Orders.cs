namespace DatabaseHandler.Models;

public class Orders
{
    public int Id { get; set; }

    public virtual IEnumerable<PizzaOrder> PizzaOrders { get; set; } = null!;
    public virtual Receipt Receipt { get; set; } = null!;
}
