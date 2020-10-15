using Bakery.Entities;
using System;

namespace Bakery.Models
{
    public class GetBunModel
    {
        public GetBunModel(Bun bun)
        {
            if (bun == null)
                throw new ArgumentNullException(nameof(bun));

            Id = bun.Id;
            Name = bun.Name;
            FullPrice = bun.FullPrice;
            BakedTime = bun.BakedTime;
            ControlTime = bun.ControlTime;
            DeadTime = bun.DeadTime;

            ChangeTime = bun.GetPriceChangeTime();
            NextPrice = bun.GetNextPrice();
            CurrentPrice = bun.GetCurrentPrice();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double FullPrice { get; set; }
        public DateTime BakedTime { get; set; }
        public DateTime ControlTime { get; set; }
        public DateTime DeadTime { get; set; }

        public DateTime? ChangeTime { get; set; }
        public double? NextPrice { get; set; }
        public double? CurrentPrice { get; set; }
    }
}
