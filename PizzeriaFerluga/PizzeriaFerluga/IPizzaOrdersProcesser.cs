using DatabaseHandler.Models;

namespace PizzeriaFerluga
{
    public interface IPizzaOrdersProcesser
    {
        List<PizzaOrder> GetPizzaOrders(List<List<string>> orders);
    }
}