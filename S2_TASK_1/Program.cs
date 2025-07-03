namespace S2_TASK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== User Registration ===");
            Console.Write("Enter a new username: ");
            string username = Console.ReadLine();
            Console.Write("Enter a new password: ");
            string password = Console.ReadLine();
            Console.WriteLine("\n Registration successful! Press any key to continue to login...\n");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("=== User Login ===");
            Console.Write("Enter your username: ");
            string username1 = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password1 = Console.ReadLine();
            if (username == username1 && password == password1)
                Console.WriteLine($"Login successful! Welcome back, {username1}");
            else
                Console.WriteLine("Login failed. Invalid username or password");
        }
    }
}
