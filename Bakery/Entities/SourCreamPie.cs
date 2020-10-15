using System;

namespace Bakery.Entities
{
    public class SourCreamPie : Bun
    {
        public const string BaseName = "Сметанник";

        public SourCreamPie(double fullPrice, DateTime bakedTime, DateTime controlTime, TimeSpan lifetime) 
            : base(BaseName, fullPrice, bakedTime, controlTime, lifetime) 
        {
            lossPerHour = 2;
        }
    }
}
