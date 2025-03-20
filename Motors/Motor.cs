using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors
{
    class Motor
    {
        public string Brand { get; }
        public string Name { get; }
        public int ReleaseYear { get; }
        public double Performance { get; }
        public double PriceInEur { get; }

        public Motor(string brand, string name, int releaseYear, double performance, double priceInEur)
        {
            Brand = brand;
            Name = name;
            ReleaseYear = releaseYear;
            Performance = performance;
            PriceInEur = priceInEur;
        }
    }
}
