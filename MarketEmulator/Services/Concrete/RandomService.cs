using MarketEmulator.Services.Abstract;

namespace MarketEmulator.Services.Concrete
{
    public class RandomService : IRandomService
    {
        private readonly Random _random = new Random();

        public decimal GetDecimal(decimal minValue, decimal maxValue)
        {
            var index = (decimal)_random.NextDouble();
            return index * (maxValue - minValue) + minValue;
        }

        public int GetInt(int minValue, int maxValue)
        {
            var @long = _random.NextInt64(minValue, maxValue);
            return int.Parse(@long.ToString());
        }

        public long GetLong(int minValue, int maxValue)
        {
            return _random.NextInt64(minValue, maxValue);
        }
    }
}
