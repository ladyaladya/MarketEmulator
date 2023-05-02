namespace MarketEmulator.Services.Abstract
{
    public interface IRandomService
    {
        public decimal GetDecimal(decimal minValue, decimal maxValue);
        public long GetLong(int minValue, int maxValue);
        public int GetInt(int minValue, int maxValue);
    }
}
