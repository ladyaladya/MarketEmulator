using MarketEmulator.Models.Abstract;
using MarketEmulator.Services.Abstract;

namespace MarketEmulator.Models.Concrete
{
    public class CheckoutLine : ICheckoutLine
    {
        private readonly IRandomService _randomService;
        public int Number { get; }
        public string MarketName { get; }
        public ConsoleColor MarketColor { get; }
        public IEnumerable<IOrder> Orders { get; set; } = Enumerable.Empty<IOrder>();
        public decimal PurchasesAmount { get { return GetPurchasesAmount(); }}
        private Thread _thread;

        public CheckoutLine(IRandomService randomService, int lineId, string marketName, ConsoleColor color)
        {
            _randomService = randomService;
            Number = lineId;
            MarketName = marketName;
            MarketColor = color;
            _thread = new Thread(Start);

            AnnounceCheckoutLineCreated();
        }

        public void AppendOrder(IOrder order)
        {
            if (order == null) return;
            Orders = Orders.Append(order);
        }

        public void Start()
        {
            foreach (var order in Orders) 
            {
                EmulatePause();
                order.AnnounceOrderPurchased();
            }
        }

        public void StartInThread()
        {
            _thread.Start();
        }

        public void Join()
        {
            _thread.Join();
        }

        private void AnnounceCheckoutLineCreated()
        {
            Console.ForegroundColor = MarketColor;
            Console.WriteLine($"Checkout Line statred, number - {Number}, market {MarketName}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private decimal GetPurchasesAmount()
        {
            decimal amount = 0;
            foreach (var order in Orders)
            {
                amount += order.Amount;
            }
            return amount;
        }

        private void EmulatePause()
        {
            var milisecondsToStop = _randomService.GetInt(2, 5) * 100;
            Thread.Sleep(milisecondsToStop);
        }
    }
}
