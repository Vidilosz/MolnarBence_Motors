namespace Motors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Statisztika stat = new Statisztika();
            stat.ReadFromFile("motors.txt");

            Console.WriteLine("Összes motor ára: " + stat.SumPrices() + " EUR");
            Console.WriteLine("Tartalmazza-e a Yamaha R1 modellt? " + stat.Contains("R1"));
            Console.WriteLine("Legrégebbi motor: " + stat.Oldest()?.Name);
            Console.WriteLine("Suzuki motorok összértéke: " + stat.SumBasedOnBrand("Suzuki") + " EUR");

            Console.WriteLine("Rendezett motorlista teljesítmény szerint:");
            stat.Sort();
            stat.PrintMotors();
        }
    }
}
