using System;

namespace Bakery.Models
{
    public class PostBunModel
    {
        public string Name { get; set; }
        public double FullPrice { get; set; }
        public DateTime BakedTime { get; set; }
        public DateTime ControlTime { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}
