namespace S3_TASK_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            bool ExitMainMenu = false;
            int SelectedBank;
            string Choice;
            int user_Choice;
            List<Bank> BanksList = new List<Bank>();
            List<Customer> customerList = new List<Customer>();
            BanksList.AddRange(new List<Bank> { new Bank(1, "Alex", 20180347), new Bank(2, "Cairo", 20180348), new Bank(3, "Fesal", 20180349) });

            while (!exit)
            {
                ExitMainMenu = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("================== Welcome To Banks system  ==================");
                Console.WriteLine("Please choose a Bank");
                Console.ResetColor();

                foreach (Bank bank in BanksList)
                {
                    bank.DisplayBankList();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Plese type exit to end the program.");
                Choice = Console.ReadLine();
                Console.ResetColor();
                int.TryParse(Choice, out SelectedBank);
                {
                    if (Choice == "exit")
                    {
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Thank You For using Our Banking system");
                        Console.ResetColor();
                    }
                    else if (SelectedBank < 4 && SelectedBank > 0)
                    {
                        while (!ExitMainMenu)
                        {
                            Console.Clear();
                            Console.WriteLine($"================== Welcome To {BanksList[SelectedBank - 1].Name}  ==================");
                            MainMenu();
                            string MainMenuChoice = Console.ReadLine();
                            switch (MainMenuChoice)
                            {
                                case "1":

                                    int NumberOfCustomers;
                                    string customerName;
                                    decimal CustomerInialBalance;
                                    int balanceCode;

                                    Console.WriteLine("Please enter numbers of Users You want to add");
                                    if (int.TryParse(Console.ReadLine(), out NumberOfCustomers) && NumberOfCustomers > 0)
                                    {
                                        for (int i = 0; i < NumberOfCustomers; i++)
                                        {
                                            Console.WriteLine("Please Enter Customer Name : ");
                                            customerName = Console.ReadLine();

                                            Console.WriteLine("Please Enter Customer Inital Balance : ");
                                            while (!decimal.TryParse(Console.ReadLine(), out CustomerInialBalance))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"Invalid Balance Please enter a right format ");
                                                Console.ResetColor();
                                            }

                                            Console.WriteLine("Please Enter Customer Balace Code : ");
                                            while (!int.TryParse(Console.ReadLine(), out balanceCode))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"Invalid operation! Operation skipped");
                                                Console.ResetColor();
                                            }

                                            var customer = new Customer(BanksList[SelectedBank - 1].CustomersList.Count + 1, customerName, CustomerInialBalance, balanceCode);
                                            BanksList[SelectedBank - 1].AddUser(customer);

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"User {customer.Name} has been add to {BanksList[SelectedBank - 1].Name} successfully !");
                                            Console.ResetColor();
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid Number of Customers");
                                        Console.ResetColor();
                                    }
                                    pause();
                                    break;
                                case "2":

                                    int userId;
                                    decimal AmoutToDeposit_WithDraw;
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("please enter a user id");
                                    Console.ResetColor();
                                    if (int.TryParse(Console.ReadLine(), out userId) && userId > 0 && BanksList[SelectedBank - 1].CustomersList.Count >= userId)
                                    {
                                        Console.WriteLine("Please choose an Operation");
                                        Console.WriteLine("Please enter 1 for Withdraw or 2 for Deposit");

                                        if (int.TryParse(Console.ReadLine(), out user_Choice) && user_Choice > 0 && user_Choice < 3)
                                        {
                                            if (user_Choice == 1)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Please enter the amount you want to Withdraw");
                                                Console.ResetColor();
                                                while (!decimal.TryParse(Console.ReadLine(), out AmoutToDeposit_WithDraw))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"Invalid Balance Code Please enter a right format ");
                                                    Console.ResetColor();
                                                }
                                                BanksList[SelectedBank - 1].CustomersList[userId - 1].WithDrawOperation(AmoutToDeposit_WithDraw);

                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                Console.WriteLine("Please enter the amount you want to deposit");
                                                Console.ResetColor();
                                                while (!decimal.TryParse(Console.ReadLine(), out AmoutToDeposit_WithDraw))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"Invalid operation! Operation skipped ");
                                                    Console.ResetColor();
                                                }
                                                BanksList[SelectedBank - 1].CustomersList[userId - 1].DepositOperation(AmoutToDeposit_WithDraw);

                                            }
                                            pause();
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid user ID. Please try again.");
                                            Console.ResetColor();
                                            pause();
                                        }
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    decimal TotalBalanceAllCutomers = 0;
                                    foreach (Customer customer in BanksList[SelectedBank - 1].CustomersList)
                                    {
                                        TotalBalanceAllCutomers += customer.Balance;
                                    }
                                    Console.WriteLine($"Total Balance of all Customers = {TotalBalanceAllCutomers}");
                                    Console.WriteLine($"Total Amount of money Deposited = {Bank.TotalAmoutDeposit}");
                                    Console.WriteLine($"Total Amount of money withdrawed = {Bank.TotalAmountWithdraw}");
                                    pause();
                                    break;
                                case "4":
                                    Console.Clear();
                                    BanksList[SelectedBank - 1].DispalyCustomerList();
                                    Console.WriteLine($"Total Number Of operation Today is {Bank.DepositCount + Bank.WithdrawCount}");
                                    pause();
                                    break;
                                case "5":
                                    Console.Clear();
                                    ExitMainMenu = true;
                                    break;
                                case "6":
                                    Console.WriteLine("Thank You For using Our Banking system");
                                    ExitMainMenu = true;
                                    exit = true;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Please Enter a Valid Bank Id");
                        Console.ResetColor();
                        pause();
                    }
                }
            }
        }
        public static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 -  Add Users");
            Console.WriteLine("2 -  Make an Operation ( deposite or withdraw ) ");
            Console.WriteLine("3 -  Collection of final data ");
            Console.WriteLine("4 -  End of day report");
            Console.WriteLine("5 - Back to Bank Selection");
            Console.WriteLine("6 - Exit");

        }
        public static void pause()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to proced ");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

    // Bank Class
    class Bank
    {
        int Id { set; get; }
        public String Name { set; get; }
        public List<Customer> CustomersList = new List<Customer>();
        public static int DepositCount = 0;
        public static int WithdrawCount = 0;
        public static decimal TotalAmoutDeposit = 0;
        public static decimal TotalAmountWithdraw = 0;

        public Bank(int id, String name, int Balance_code)
        {
            Id = id;
            Name = name;
        }

        public void DisplayBankList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Bank Id {Id}  Bank Name : {Name}");
            Console.ResetColor();
        }

        public void AddUser(Customer customer)
        {
            CustomersList.Add(customer);
        }
        public void DispalyCustomerList()
        {
            foreach (Customer customer in CustomersList)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Customer Name : {customer.Name}");
                Console.WriteLine($"Customer Balance : {customer.Balance}");
                Console.WriteLine($"Customer Balance Code : {customer.BalnceCode}");
                Console.ResetColor();
                Console.WriteLine("-------------------------------------------------- \n ");
            }
        }
    }

    // Customer Class
    class Customer
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public Decimal Balance { set; get; }
        public int BalnceCode { set; get; }

        public Customer(int id, string name, decimal InitialBalance, int balnceCode)
        {
            Id = id;
            Name = name;
            Balance = InitialBalance;
            BalnceCode = balnceCode;
        }
        public void DepositOperation(decimal DepositedMoney)
        {
            if (DepositedMoney <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Deposit amount must be greater than 0.");
                Console.ResetColor();
                return;
            }
            Balance += DepositedMoney;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully deposited {DepositedMoney:C}. New balance: {Balance:C}");
            Console.ResetColor();
            Bank.DepositCount++;
            Bank.TotalAmoutDeposit += DepositedMoney;
        }
        public void WithDrawOperation(decimal WithdrawedMoney)
        {
            if (Balance < WithdrawedMoney)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Insufficient balance! Operation skipped. \n Your current Balance is {Balance}");
                Console.ResetColor();
                return;
            }
            Balance -= WithdrawedMoney;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully withdrawed {WithdrawedMoney:C}   New balance: {Balance:C} ");
            Bank.WithdrawCount++;
            Bank.TotalAmountWithdraw += WithdrawedMoney;


            Console.ResetColor();
        }
    }
}
