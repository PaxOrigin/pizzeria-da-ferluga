namespace PizzeriaFerluga.PizzaDecorator;

internal class ProsciuttoCrudo : PizzaDecoratorPattern
{
    public ProsciuttoCrudo(IPizza pizza) : base(pizza)
    {
        _description = "Prosciutto Crudo";
        _price = 2m;
    }
}
