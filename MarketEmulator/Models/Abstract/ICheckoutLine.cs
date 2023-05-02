namespace MarketEmulator.Models.Abstract
{
    public interface ICheckoutLine
    {
        public int Number { get; }
        public string MarketName { get; }
        public ConsoleColor MarketColor { get; }
        public IEnumerable<IOrder> Orders { get; set; }
        public decimal PurchasesAmount { get; }
        public void Start();
        public void AppendOrder(IOrder order);
    }
}
