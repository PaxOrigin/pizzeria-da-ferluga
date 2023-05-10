namespace PizzeriaFerluga.PizzaDecorator;

internal class PizzaDecoratorPattern : IPizza
{
    private readonly IPizza _pizza;

    protected decimal _price = 0m;
    protected string _description = string.Empty;

    public PizzaDecoratorPattern(IPizza pizza)
    {
        _pizza = pizza;
    }

    public string GetDescription()
        => $"{_pizza.GetDescription()} {_description}";

    public decimal GetPrice()
        => _pizza.GetPrice() + _price;
}
