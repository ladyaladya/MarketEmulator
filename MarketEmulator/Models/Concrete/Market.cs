using MarketEmulator.Models.Abstract;
using MarketEmulator.Services.Abstract;
using MarketEmulator.Utilities;

namespace MarketEmulator.Models.Concrete
{
    public class Market : IMarket
    {
        private readonly IRandomService _randomService;
        public IEnumerable<ICheckoutLine> CheckoutLines { get; set; } = Enumerable.Empty<ICheckoutLine>();
        public string Name { get; }
        public ConsoleColor Color { get; }
        public decimal PurchasesAmount { get { return GetPurchasesAmount(); }}

        public Market(IRandomService randomService, string name, ConsoleColor color)
        {
            _randomService = randomService;
            Name = name;
            Color = color;

            AnnounceMarketCreated();
        }

        public IMarket AddCheckoutLines()
        {
            var checkoutCount = _randomService.GetInt(2, 5);
            for (int i = 1; i <= checkoutCount; i++)
            {
                CheckoutLines = CheckoutLines.Append(new CheckoutLine(_randomService, i, Name, Color));
            }
            return this;
        }

        public IMarket AppendOrders()
        {
            CheckoutLines.AppendOrders();
            return this;
        }

        public IMarket Start()
        {
            CheckoutLines.Start();
            return this;
        }

        public void PrintResultedData()
        {
            Console.ForegroundColor = Color;

            Console.WriteLine($"Makret {Name} was successfully finish it's work.");
            Console.WriteLine($"There was ${PurchasesAmount.ToString("N2")} erned");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private decimal GetPurchasesAmount()
        {
            decimal amount = 0;
            foreach (var purchaseAmount in CheckoutLines)
            {
                amount += purchaseAmount.PurchasesAmount;
            }
            return amount;
        }

        private void AnnounceMarketCreated()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Created new Market - {Name} with color {Color}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
