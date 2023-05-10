namespace PizzeriaFerluga.PizzaDecorator;

internal class ImpastoNormale : PizzaDecoratorPattern
{
    public ImpastoNormale(IPizza pizza) : base(pizza)
    {
        _description = "Impasto Normale";
        _price = 0;
    }
}
