using Bakery.Entities;
using System;

namespace Bakery.Services
{
    public interface IBunFactory
    {
        Bun Create(string name, double fullPrice,
            DateTime bakedTime, DateTime controlTime, TimeSpan lifetime);
    }
}