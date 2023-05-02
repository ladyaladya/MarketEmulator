using MarketEmulator.Models.Abstract;
using System.Globalization;

namespace MarketEmulator.Models.Concrete
{
    public class Order : IOrder
    {
        public decimal Amount { get; }
        public string MarketName { get; }
        public ConsoleColor MarketColor { get; }
        public int CheckoutLineNumber { get; }
        private string AmountString => Amount.ToString("N2");

        public Order(decimal amount, int checkoutLineNumber, string marketName, ConsoleColor color)
        {
            Amount = amount;
            MarketName = marketName;
            MarketColor = color;
            CheckoutLineNumber = checkoutLineNumber;
        }

        public void AnnounceOrderPurchased()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            Console.ForegroundColor = MarketColor;
            Console.WriteLine($"Order purchased with amount - ${AmountString} in the {MarketName} on checkout line {CheckoutLineNumber}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
