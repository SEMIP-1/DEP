// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

namespace OOP_Task_2
{
    //Task OOP second session: 
    //1.	Define a struct "Person" with properties "Name" and "Age". Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.

    //2.	Create a struct called "Point" to represent a 2D point with properties "X" and   "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.

    //3.	Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.

    //4.Create a struct named Rectangle that represents a rectangle with the following fields:
    //width (type: double)
    //height (type: double)
    //Implement encapsulation by making the fields private and provide public properties  access and modify these values. Ensure the following conditions are met:
    //The width and height should not be negative. If a negative value is provided, the setter should not update the field and should instead print an error message.
    //Implement a public read-only property Area that calculates and returns the area of the rectangle (Area = width * height).
    //Implement a method DisplayInfo that prints the rectangle's dimensions and area.
    //Write a program to demonstrate the usage of this struct by creating an instance, setting values via properties, and displaying the area.

    public struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void DisplayInfo(Person person)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }

    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public void CalculateDistance(Point p1, Point p2)
        {
            double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            Console.WriteLine($"Distance between points: {distance}");
        }
    }

    public struct Rectangle
    {
        private double width;
        private double height;

        public double Width
        {
            get { return width; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Width cannot be negative.");
                else
                    width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Height cannot be negative.");
                else
                    height = value;
            }
        }

        public double Area
        {
            get { return width * height; }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Width: {width}, Height: {height}, Area: {Area}");
        }
    }
    public class MyTaskInterface()
    {
        public void Task1()
        {
            Person[] persons = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                Person person = new Person();
                Console.Write("Enter name: ");
                person.Name = Console.ReadLine();
                Console.Write("Enter age: ");
                person.Age = int.Parse(Console.ReadLine());
                persons[i] = person;
            }
            for (int i = 0; i < 3; i++)
            {
                persons[i].DisplayInfo(persons[i]);
            }
        }
        public void Task2()
        { 
            Point p1 = new Point();
            Point p2 = new Point();
            Console.Write("Enter X for Point 1: ");
            p1.X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y for Point 1: ");
            p1.Y = double.Parse(Console.ReadLine());
            Console.Write("Enter X for Point 2: ");
            p2.X = double.Parse(Console.ReadLine());
            Console.Write("Enter Y for Point 2: ");
            p2.Y = double.Parse(Console.ReadLine());
            p1.CalculateDistance(p1, p2);
        }
        public void Task3()
        { 
            Person[] persons = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                Person person = new Person();
                Console.Write("Enter name: ");
                person.Name = Console.ReadLine();
                Console.Write("Enter age: ");
                person.Age = int.Parse(Console.ReadLine());
                persons[i] = person;
            }
            Person oldest = persons[0];
            for (int i = 1; i < 3; i++)
            {
                if (persons[i].Age > oldest.Age)
                    oldest = persons[i];
            }
            Console.WriteLine($"Oldest Person: Name: {oldest.Name}, Age: {oldest.Age}");
        }
        public void Task4()
        {
            Rectangle rect = new Rectangle();
            Console.Write("Enter width: ");
            rect.Width = double.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            rect.Height = double.Parse(Console.ReadLine());
            rect.DisplayInfo();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyTaskInterface myTask = new MyTaskInterface();
            Console.WriteLine("Enter Task Number To present (1-4): ");
            int taskNumber = int.Parse(Console.ReadLine());
            switch(taskNumber)
            {
                case 1:
                    myTask.Task1();
                    break;
                case 2:
                    myTask.Task2();
                    break;
                case 3:
                    myTask.Task3();
                    break;
                case 4:
                    myTask.Task4();
                    break;
                default:
                    Console.WriteLine("Invalid Task Number");
                    break;
            }
        }
    }
}
