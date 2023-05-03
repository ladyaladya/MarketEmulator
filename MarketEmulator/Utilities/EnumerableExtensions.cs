using MarketEmulator.Models.Abstract;
using MarketEmulator.Models.Concrete;
using MarketEmulator.Services.Abstract;
using MarketEmulator.Services.Concrete;

namespace MarketEmulator.Utilities
{
    public static class EnumerableExtensions
    {
        private static readonly IRandomService _randomService = new RandomService();
        public static void Start(this IEnumerable<ICheckoutLine> checkoutLines)
        {
            foreach (var line in checkoutLines)
            {
                line.Start();
            }
        }

        public static void StartInThread(this IEnumerable<ICheckoutLine> checkoutLines)
        {
            foreach (var line in checkoutLines)
            {
                line.StartInThread();
            }

            foreach (var line in checkoutLines)
            {
                line.Join();
            }

        }

        public static void AppendOrders(this IEnumerable<ICheckoutLine> checkoutLines)
        {
            foreach (var line in checkoutLines)
            {
                var orderCount = GetOrderCount();
                for (var i = 1; i <= orderCount; i++)
                {
                    var order = new Order(GetOrderPrice(), line.Number, line.MarketName, line.MarketColor);
                    line.AppendOrder(order);
                }
            }
        }

        private static int GetOrderCount()
        {
            return _randomService.GetInt(50, 100);
        }

        private static decimal GetOrderPrice()
        {
            return _randomService.GetDecimal(5, 1000);
        }
    }
}
