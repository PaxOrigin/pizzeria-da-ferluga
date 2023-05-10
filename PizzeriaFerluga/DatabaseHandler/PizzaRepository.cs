using DatabaseHandler.Models;

namespace DatabaseHandler;

public class PizzaRepository
{
    private PizzeriaContext _context;

    public PizzaRepository(PizzeriaContext context)
    {
        _context = context;
    }

    public void AddPizzaOrders(List<PizzaOrder> pizzaOrders)
        => _context.PizzaOrders.AddRange(pizzaOrders);

    public void AddReceipts(List<Receipt> receipts)
        => _context.Receipts.AddRange(receipts);

}
