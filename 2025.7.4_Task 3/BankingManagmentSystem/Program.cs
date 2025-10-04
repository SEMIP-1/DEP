namespace BankingManagmentSystem
{
    internal class Program
    {
        class Clinet
        {
            public string Name { get; set; }

            public int BalanceCode { get; set; }

            public Double Balance { get; set; }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose your Bank \t ( Alex - Cairo - Fesal) ");
            string BankName = Console.ReadLine();
            if (BankName.Equals("Cairo", StringComparison.OrdinalIgnoreCase) || BankName.Equals("Alex", StringComparison.OrdinalIgnoreCase) || BankName.Equals("Fesal", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Welcome to " + BankName + " Bank");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter The Number Of Custumors : ");
                int NumberOfCustomers;
                while (!int.TryParse(Console.ReadLine(), out NumberOfCustomers) || NumberOfCustomers <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number of customers.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                List<Clinet> Customers = new List<Clinet>();
                float TotalDrawn = 0f;
                float TotalDeposited = 0f;

                for (int i = 1; i <= NumberOfCustomers; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Customer {i} Credentials : ");
                    int BalanceCode;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter Balance Code :  ");
                    while (!int.TryParse(Console.ReadLine(), out BalanceCode) || BalanceCode <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid balance code.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter Customer Name : ");
                    string CustomerName = Console.ReadLine();

                    float initialBalance;
                    Console.Write("Enter the Initial Balance : ");
                    while (!float.TryParse(Console.ReadLine(), out initialBalance) || initialBalance <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid initial balance.");
                    }
                    Clinet customer = new Clinet { Name = CustomerName, Balance = initialBalance, BalanceCode = BalanceCode };

                    Console.WriteLine("Choose An Operation (Draw || Deposit)");
                    string Operation = Console.ReadLine();

                    if (Operation.Equals("Draw", StringComparison.OrdinalIgnoreCase))
                    {

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        float drawAmount;
                        Console.WriteLine("How much do you want to draw : ");
                        while (!float.TryParse(Console.ReadLine(), out drawAmount) || drawAmount <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid amount to draw.");
                        }
                        if (drawAmount <= customer.Balance)
                        {
                            customer.Balance -= drawAmount;
                            TotalDrawn += drawAmount;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You have successfully drawn {drawAmount} from your account. New balance is {customer.Balance}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Insufficient balance to draw this amount.");
                        }
                    }
                    else if (Operation.Equals("Deposit", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        float depositAmount;
                        Console.WriteLine("How much do you want to deposit : ");
                        while (!float.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid amount to deposit.");
                        }
                        customer.Balance += depositAmount;
                        TotalDeposited += depositAmount;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"You have successfully deposited {depositAmount} into your account. New balance is {customer.Balance}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid operation. Please choose either 'Draw' or 'Deposit'.");
                    }

                    Customers.Add(customer);
                }
                foreach (var customer in Customers)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Customer Name: {customer.Name}, Balance Code: {customer.BalanceCode}, Current Balance: {customer.Balance}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Total Drawn: {TotalDrawn}");
                Console.WriteLine($"Total Deposited: {TotalDeposited}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("We Do Not Deal with this BANK!!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        
        }
    }
}
