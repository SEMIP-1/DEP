using Project1.Class;

namespace Project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            double num1 = 10.5;
            double num2 = 5.2;
            Console.WriteLine("Basic Arithmetic Operations for:");
            Console.WriteLine($"num1 = {num1}, num2 = {num2}");

            Console.WriteLine($"Addition: {num1} + {num2} = {Maths.Add(num1, num2)}");
            Console.WriteLine($"Subtraction: {num1} - {num2} = {Maths.Subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {Maths.Multiply(num1, num2)}");
            Console.WriteLine($"Division: {num1} / {num2} = {Maths.Divide(num1, num2)}");

        }
    }
}
