namespace PizzeriaFerluga.PizzaDecorator;

internal class PizzaBianca : IPizza
{
    public string GetDescription()
        => "Pizza Bianca";

    public decimal GetPrice()
        => 5m;
}
