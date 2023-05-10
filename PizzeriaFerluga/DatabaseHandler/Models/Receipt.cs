namespace DatabaseHandler.Models;

public class Receipt
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    public virtual Orders Order { get; set; } = null!;
}
