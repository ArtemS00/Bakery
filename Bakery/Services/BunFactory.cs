using Bakery.Entities;
using System;

namespace Bakery.Services
{
    public class BunFactory : IBunFactory
    {
        public Bun Create(string name, double fullPrice, 
            DateTime bakedTime, DateTime controlTime, TimeSpan lifetime)
        {
            switch (name)
            {
                case SourCreamPie.BaseName: return new SourCreamPie(fullPrice, bakedTime, controlTime, lifetime);
                case Pretzel.BaseName: return new Pretzel(fullPrice, bakedTime, controlTime, lifetime);
                default: return new Bun(name, fullPrice, bakedTime, controlTime, lifetime);
            }
        }
    }
}
