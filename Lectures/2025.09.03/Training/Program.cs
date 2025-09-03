namespace Training
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Car car1 = new Car();
            Car car2 = new Car("BMW");
            Car car3 = new Car("Audi", "A6");
            Car car4 = new Car("Mercedes", "C200", 250);
        }
    }
}
