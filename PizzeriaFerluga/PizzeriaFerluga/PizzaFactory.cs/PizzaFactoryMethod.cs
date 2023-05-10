using PizzeriaFerluga.PizzaDecorator;

namespace PizzeriaFerluga.PizzaFactory.cs;

internal class PizzaFactoryMethod
{
    internal IPizza GetBasePizza(string pizzaType)
        => pizzaType switch
        {
            "Margherita" => new PizzaMargherita(),
            "Bianca" => new PizzaBianca(),
            "Napoletana" => new PizzaNapoletana(),
            _ => throw new InvalidDataException("Invalid pizza type")
        };

    internal IPizza GetDecoratedPizza(string ingredient, IPizza pizza)
        => ingredient switch
        {
            "Integrale" => new ImpastoIntegrale(pizza),
            "Normale" => new ImpastoNormale(pizza),
            "Prosciutto Cotto" => new ProsciuttoCotto(pizza),
            "Prosciutto Crudo" => new ProsciuttoCrudo(pizza),
            "Funghi" => new Funghi(pizza),
            "Ananas" => new Ananas(pizza),
            _ => throw new InvalidDataException("Invalid ingredient or base")
        };
}
