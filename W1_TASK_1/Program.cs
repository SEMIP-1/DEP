namespace W1_TASK_1
{
    //Salah Eldin Mohamad Hussein
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Welcome to login page");
            Console.WriteLine("please Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("please Enter Password:");
            string password = Console.ReadLine();
            if (username == "admin" && password == "admin")
                Console.WriteLine("You are logged in");
            else
                Console.WriteLine("Wrong Username or Password");

        }
    }
}
