using System.Globalization;

namespace Task
{
    internal class Program
    {
        #region Part1
        public enum SecurityLevel
        {
            Guest,
            Developer,
            Secretary,
            DBA,
            SecurityOfficer // full permissions
        }
        public class HiringDate
        {
            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }

            public HiringDate(int day, int month, int year)
            {
                if (day < 1 || day > 31) throw new ArgumentException("Invalid day");
                if (month < 1 || month > 12) throw new ArgumentException("Invalid month");
                if (year < 1900 || year > DateTime.Now.Year) throw new ArgumentException("Invalid year");

                Day = day;
                Month = month;
                Year = year;
            }

            public override string ToString()
            {
                return $"{Day:D2}/{Month:D2}/{Year}";
            }
        }
        public class Employee : IComparable<Employee>
        {
            public int ID { get; set; }
            public string Name { get; set; }

            private char gender;
            public char Gender
            {
                get { return gender; }
                set
                {
                    if (value == 'M' || value == 'F')
                        gender = value;
                    else
                        throw new ArgumentException("Gender must be M or F");
                }
            }

            public double Salary { get; set; }
            public SecurityLevel Security { get; set; }
            public HiringDate HireDate { get; set; }

            public Employee(int id, string name, char gender, double salary, SecurityLevel security, HiringDate hireDate)
            {
                ID = id;
                Name = name;
                Gender = gender;
                Salary = salary;
                Security = security;
                HireDate = hireDate;
            }

            public override string ToString()
            {
                return $"ID: {ID}, Name: {Name}, Gender: {Gender}, " +
                       $"Salary: {Salary.ToString("C", CultureInfo.CurrentCulture)}, " +
                       $"Security: {Security}, HireDate: {HireDate}";
            }

            // Sort employees by HireDate (Year → Month → Day)
            public int CompareTo(Employee other)
            {
                if (other == null) return 1;

                DateTime thisDate = new DateTime(HireDate.Year, HireDate.Month, HireDate.Day);
                DateTime otherDate = new DateTime(other.HireDate.Year, other.HireDate.Month, other.HireDate.Day);

                return thisDate.CompareTo(otherDate);
            }
        }
        #endregion
        #region Part2
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }

            public Book(string title, string author, string isbn)
            {
                Title = title;
                Author = author;
                ISBN = isbn;
            }

            public virtual void DisplayInfo()
            {
                Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}");
            }
        }
        public class EBook : Book
        {
            public double FileSizeMB { get; set; }

            public EBook(string title, string author, string isbn, double fileSize)
                : base(title, author, isbn)
            {
                FileSizeMB = fileSize;
            }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"File Size: {FileSizeMB} MB");
            }
        }
        public class PrintedBook : Book
        {
            public int PageCount { get; set; }

            public PrintedBook(string title, string author, string isbn, int pages)
                : base(title, author, isbn)
            {
                PageCount = pages;
            }

            public override void DisplayInfo()
            {
                base.DisplayInfo();
                Console.WriteLine($"Pages: {PageCount}");
            }
        } 
        #endregion
        static void Main(string[] args)
        {
            // Part 1: Employee Management
            Console.WriteLine("Hello, World!");
            Employee[] EmpArr = new Employee[3];

            EmpArr[0] = new Employee(1, "Ali", 'M', 5000, SecurityLevel.DBA,
                         new HiringDate(12, 5, 2020));

            EmpArr[1] = new Employee(2, "Sara", 'F', 3000, SecurityLevel.Guest,
                         new HiringDate(1, 1, 2022));

            EmpArr[2] = new Employee(3, "Omar", 'M', 7000, SecurityLevel.SecurityOfficer,
                         new HiringDate(25, 12, 2018));

            Console.WriteLine("=== Employees Before Sorting ===");
            foreach (var emp in EmpArr)
                Console.WriteLine(emp);

            Array.Sort(EmpArr); // Uses CompareTo

            Console.WriteLine("\n=== Employees After Sorting by Hire Date ===");
            foreach (var emp in EmpArr)
                Console.WriteLine(emp);
            Console.WriteLine("\nNote: Sorting caused boxing/unboxing when using IComparable interface.");

            // Part 2: Library System
            Book ebook = new EBook("C# in Depth", "Jon Skeet", "123456", 15.2);
            Book pbook = new PrintedBook("Clean Code", "Robert C. Martin", "654321", 464);

            Console.WriteLine("\n=== Library Books ===");
            ebook.DisplayInfo();
            Console.WriteLine();
            pbook.DisplayInfo();



        }
    }
}
