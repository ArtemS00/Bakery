using System;

namespace Bakery.Entities
{
    public class Pretzel : Bun
    {
        public const string BaseName = "Крендель";

        public Pretzel(double fullPrice, DateTime bakedTime, DateTime controlTime, TimeSpan lifetime) 
            : base(BaseName, fullPrice, bakedTime, controlTime, lifetime) { }

        public override double? GetCurrentPrice(DateTime time)
        {
            if (!IsAlive())
                return null;
            if (time >= ControlTime)
                return FullPrice / 2;
            return FullPrice;
        }

        public override DateTime? GetPriceChangeTime()
        {
            if (!IsAlive())
                return null;

            if (DateTime.Now > ControlTime)
                return DeadTime;
            return ControlTime;
        }
    }
}
