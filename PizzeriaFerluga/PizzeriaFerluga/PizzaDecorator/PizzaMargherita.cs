namespace PizzeriaFerluga.PizzaDecorator;

internal class PizzaMargherita : IPizza
{

    public string GetDescription()
        => "Pizza Margherita";

    public decimal GetPrice()
        => 7m;
}
