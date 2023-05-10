using DatabaseHandler.Models;

namespace PizzeriaFerluga.PizzaProcesser
{
    public interface IPizzaOrdersProcesser
    {
        List<PizzaOrder> GetPizzaOrders(List<List<string>> orders);
    }
}