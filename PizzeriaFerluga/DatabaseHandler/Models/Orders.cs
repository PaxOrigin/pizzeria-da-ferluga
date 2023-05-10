namespace DatabaseHandler.Models;

public class Orders
{
    public int Id { get; set; }


    public virtual Receipt Receipt { get; set; } = null!;
}
