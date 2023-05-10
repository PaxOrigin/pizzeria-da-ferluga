namespace PizzeriaFerluga.PizzaDecorator
{
    internal class ImpastoIntegrale : PizzaDecoratorPattern
    {
        public ImpastoIntegrale(IPizza pizza) : base(pizza)
        {
            _description = "Impasto Integrale";
            _price = 1m;
        }
    }
}
