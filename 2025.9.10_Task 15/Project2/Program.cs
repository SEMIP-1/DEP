using Project1.Class;

namespace Project2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Testing constructors
            Duration D1 = new Duration(1, 10, 15);
            Console.WriteLine($"D1: {D1}");

            Duration D2 = new Duration(3600);
            Console.WriteLine($"D2: {D2}");

            Duration D3 = new Duration(7800);
            Console.WriteLine($"D3: {D3}");

            Duration D4 = new Duration(666);
            Console.WriteLine($"D4: {D4}");

            // Testing operator overloading
            Console.WriteLine("\n--- Operator Overloading Tests ---");

            Duration result = D1 + D2;
            Console.WriteLine($"D1 + D2: {result}");

            result = D1 + 7800;
            Console.WriteLine($"D1 + 7800: {result}");

            result = 666 + D3;
            Console.WriteLine($"666 + D3: {result}");

            result = ++D1;
            Console.WriteLine($"++D1: {result}");

            result = --D2;
            Console.WriteLine($"--D2: {result}");

            result = D1 - D2;
            Console.WriteLine($"D1 - D2: {result}");

            Console.WriteLine($"D1 > D2: {D1 > D2}");
            Console.WriteLine($"D1 <= D2: {D1 <= D2}");
            Console.WriteLine($"If(D1): {(D1 ? "True" : "False")}");

            DateTime dateTimeObj = (DateTime)D1;
            Console.WriteLine($"DateTime from D1: {dateTimeObj}");
        }
    }
}
