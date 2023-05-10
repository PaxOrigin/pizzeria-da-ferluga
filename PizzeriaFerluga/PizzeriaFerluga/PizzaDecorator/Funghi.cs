namespace PizzeriaFerluga.PizzaDecorator;

internal class Funghi : PizzaDecoratorPattern
{
    public Funghi(IPizza pizza) : base(pizza)
    {
        _description = "Funghi";
        _price = 2;
    }
}
