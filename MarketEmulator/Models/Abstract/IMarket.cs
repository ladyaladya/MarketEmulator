namespace MarketEmulator.Models.Abstract
{
    public interface IMarket
    {
        public IEnumerable<ICheckoutLine> CheckoutLines { get; set; }
        public string Name { get; }
        public ConsoleColor Color { get; }
        public decimal PurchasesAmount { get; }
        public IMarket AppendOrders();
        public IMarket Start();
        public void PrintResultedData();
    }
}
