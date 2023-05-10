namespace PizzeriaFerluga.PizzaDecorator;

internal class Ananas : PizzaDecoratorPattern
{
    public Ananas(IPizza pizza) : base(pizza)
    {
        _description = "Ananas";
        _price = 0;
    }
}
