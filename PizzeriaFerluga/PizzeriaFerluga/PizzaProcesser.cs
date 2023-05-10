using DatabaseHandler.Models;

using PizzeriaFerluga.PizzaDecorator;
using PizzeriaFerluga.PizzaFactory.cs;

namespace PizzeriaFerluga;

public class PizzaOrdersProcesser : IPizzaOrdersProcesser
{
    public List<PizzaOrder> GetPizzaOrders(List<List<string>> orders)
    {
        PizzaFactoryMethod pizzaFactory = new PizzaFactoryMethod();
        List<PizzaOrder> pizzaOrders = new List<PizzaOrder>();
        PizzaOrder pizzaOrder = new PizzaOrder();

        foreach (var order in orders)
        {
            IPizza? pizza = null;
            foreach (int index in Enumerable.Range(0, order.Count()))
            {
                if (index == 0)
                    pizza = pizzaFactory.GetBasePizza(order[index]);
                else
                    pizza = pizzaFactory.GetDecoratedPizza(order[index], pizza!);

            }
            decimal price = order.Contains("Ananas") ? 0m : pizza!.GetPrice();
            pizzaOrders.Add(new() { Description = pizza!.GetDescription(), Price = price });
        }
        return pizzaOrders;
    }
}
