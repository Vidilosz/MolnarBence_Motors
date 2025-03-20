using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors
{
    class Statisztika
    {
        private List<Motor> motors = new List<Motor>();

        public void ReadFromFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName).Skip(1); // Első sor kihagyása (fejléc)
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue; // Üres sorok kihagyása

                var parts = line.Split(';');
                if (parts.Length != 5) continue; // Biztosítjuk, hogy minden sor 5 elemet tartalmazzon

                try
                {
                    string brand = parts[0];
                    string name = parts[1];
                    int releaseYear = int.Parse(parts[2]);
                    double performance = double.Parse(parts[3], System.Globalization.CultureInfo.InvariantCulture);
                    double priceInEur = double.Parse(parts[4], System.Globalization.CultureInfo.InvariantCulture);

                    motors.Add(new Motor(brand, name, releaseYear, performance, priceInEur));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Hibás adatformátum a következő sorban: {line}");
                    Console.WriteLine($"Hiba: {ex.Message}");
                }
            }
        }

        public int SumPrices() => (int)motors.Sum(m => m.PriceInEur);

        public bool Contains(string motorName) => motors.Any(m => m.Name.Equals(motorName, StringComparison.OrdinalIgnoreCase));

        public Motor Oldest() => motors.OrderBy(m => m.ReleaseYear).FirstOrDefault();

        public int SumBasedOnBrand(string brandName) => (int)motors.Where(m => m.Brand.Equals(brandName, StringComparison.OrdinalIgnoreCase)).Sum(m => m.PriceInEur);

        public void Sort() => motors = motors.OrderByDescending(m => m.Performance).ToList();

        public void PrintMotors()
        {
            foreach (var motor in motors)
            {
                Console.WriteLine($"{motor.Brand} {motor.Name} - {motor.Performance} HP, {motor.PriceInEur} EUR");
            }
        }
    }
}
