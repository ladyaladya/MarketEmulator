namespace MarketEmulator.Models.Abstract
{
    public interface IOrder
    {
        public decimal Amount { get; }
        public string MarketName { get; }
        public ConsoleColor MarketColor { get; }
        public int CheckoutLineNumber { get; }
        public void AnnounceOrderPurchased();
    }
}
