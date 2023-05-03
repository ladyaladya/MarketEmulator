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

        private Thread _thread;

        public Market(IRandomService randomService, string name, ConsoleColor color)
        {
            _randomService = randomService;
            Name = name;
            Color = color;
            _thread = new Thread(Start);

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

        public void Start()
        {
            CheckoutLines.StartInThread();
        }

        public void StartInThread()
        {
            _thread.Start();
        }

        public void Join()
        {
            _thread.Join();
        }

        public void PrintResultedData()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine();

            Console.WriteLine($"Makret {Name} was successfully finish it's work.");
            Console.WriteLine($"{Name} has been open {CheckoutLines.Count()} checkout lines.");

            foreach (var line in CheckoutLines)
            {
                Console.WriteLine($"Checkount line number {line.Number} has served {line.Orders.Count()} orders. Line has been earned ${line.PurchasesAmount.ToString("N2")}");
            }

            Console.WriteLine($"All checkout lines have been earned ${PurchasesAmount.ToString("N2")}");
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
