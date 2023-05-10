namespace PizzeriaFerluga.PizzaDecorator;

internal class ProsciuttoCotto : PizzaDecoratorPattern
{
    public ProsciuttoCotto(IPizza pizza) : base(pizza)
    {
        _description = "Prosciutto Cotto";
        _price = 1m;
    }
}
