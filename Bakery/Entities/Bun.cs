using System;

namespace Bakery.Entities
{
    public class Bun
    {
        public int Id { get; set; }
        public string Name { get; protected set; }
        public double FullPrice { get; protected set; }
        public DateTime BakedTime { get; protected set; }
        public DateTime ControlTime { get; protected set; }
        public DateTime DeadTime { get; protected set; }

        private const double MAX_PRICE = 100;

        /// <summary>
        /// Loss in price per hour. In procents.
        /// </summary>
        protected double lossPerHour = 1;

        public Bun(string name, double fullPrice, 
            DateTime bakedTime, DateTime controlTime, TimeSpan lifetime)
        {
            if (fullPrice <= 0)
                throw new ArgumentException("Must be positive", nameof(fullPrice));
            if (fullPrice > MAX_PRICE)
                throw new ArgumentException($"Must be lower than {MAX_PRICE}", nameof(fullPrice));

            if (bakedTime > DateTime.Now)
                throw new ArgumentException("Must be baked now", nameof(bakedTime));
            if (controlTime < bakedTime)
                throw new ArgumentException($"Must be bigger than {nameof(bakedTime)}", nameof(controlTime));
            if (bakedTime.Add(lifetime) < DateTime.Now)
                throw new ArgumentException("Bun is already dead", nameof(lifetime));

            Name = name ?? throw new ArgumentNullException(nameof(name), "Must be not null");
            FullPrice = fullPrice;
            BakedTime = bakedTime;
            ControlTime = controlTime;
            DeadTime = bakedTime.Add(lifetime);
        }

        public double? GetCurrentPrice()
        {
            return GetCurrentPrice(DateTime.Now);
        }

        public double? GetNextPrice()
        {
            var time = GetPriceChangeTime();
            if (time == null)
                return null;

            // Add 1 ms needs to pass '>=' condition
            return GetCurrentPrice(time.Value.AddMilliseconds(1));
        }

        public virtual double? GetCurrentPrice(DateTime time)
        {
            var difference = time - BakedTime;
            var priceLoss = (int)difference.TotalHours * lossPerHour * 0.01;

            if (priceLoss >= 1 && !IsAlive())
                return null;

            return FullPrice * (1 - priceLoss);
        }

        public virtual DateTime? GetPriceChangeTime()
        {
            if (!IsAlive())
                return null;

            var difference = DateTime.Now - BakedTime;
            if (difference.TotalHours > 100 / lossPerHour)
                return null;
            return DateTime.Now.AddHours(1 - difference.TotalHours % 1);
        }

        public bool IsAlive()
        {
            return DeadTime > DateTime.Now;
        }

        // For Entity Framework
        protected Bun() { }
    }
}
