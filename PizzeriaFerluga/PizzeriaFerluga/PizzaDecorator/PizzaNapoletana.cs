namespace PizzeriaFerluga.PizzaDecorator;

internal class PizzaNapoletana : IPizza
{
    public string GetDescription()
        => "Pizza Napoletana";

    public decimal GetPrice()
        => 3m;
}
