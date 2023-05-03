using MarketEmulator.Models.Abstract;
using MarketEmulator.Models.Concrete;
using MarketEmulator.Services.Abstract;
using MarketEmulator.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
            .AddSingleton<IRandomService, RandomService>()
            .BuildServiceProvider();

var randomService = serviceProvider.GetService<IRandomService>() ?? new RandomService();

var marketsList = new List<IMarket>()
{
    new Market(randomService, "Silpo", ConsoleColor.DarkYellow)
        .AddCheckoutLines()
        .AppendOrders(),
    new Market(randomService, "ATB", ConsoleColor.Blue)
        .AddCheckoutLines()
        .AppendOrders(),
    new Market(randomService, "Auchan", ConsoleColor.Red)
        .AddCheckoutLines()
        .AppendOrders()
};

foreach (var market in marketsList)
{
    market.StartInThread();
}

foreach (var market in marketsList)
{
    market.Join();
}

foreach (var market in marketsList)
{
    market.PrintResultedData();
}

