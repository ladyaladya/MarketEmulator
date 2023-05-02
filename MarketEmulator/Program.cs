using MarketEmulator.Models.Concrete;
using MarketEmulator.Services.Abstract;
using MarketEmulator.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
            .AddSingleton<IRandomService, RandomService>()
            .BuildServiceProvider();

var randomService = serviceProvider.GetService<IRandomService>() ?? new RandomService();

var market = new Market(randomService, "Silpo", ConsoleColor.DarkYellow)
    .AddCheckoutLines()
    .AppendOrders();

market.Start();
market.PrintResultedData();


