namespace StudentGradingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of students: ");
            int studentCount;
            while (!int.TryParse(Console.ReadLine(), out studentCount) || studentCount <= 0)
            {
                Console.Write("Please enter a correct number: ");
            }

            Console.Write("Enter the number of subjects: ");
            int subjectCount;
            while (!int.TryParse(Console.ReadLine(), out subjectCount) || subjectCount <= 0)
            {
                Console.Write("Please enter a correct number: ");
            }


            string[] studentNames = new string[studentCount];
            double[,] grades = new double[studentCount, subjectCount];

            // Input student names and grades
            for (int Student = 0; Student < studentCount; Student++)
            {
                Console.Write($"\nEnter name for student N.{Student + 1}: ");
                studentNames[Student] = Console.ReadLine()!;

                for (int grade = 0; grade < subjectCount; grade++)
                {
                    Console.Write($"Enter grade for subject N.{grade + 1}: ");
                    grades[Student, grade] = double.Parse(Console.ReadLine()!);
                }
            }

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Print top three students based on average grades");
                Console.WriteLine("2. Print data of all students");
                Console.WriteLine("3. Search for a student by name and print their grades");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ( 1 || 2 || 3 ) ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // To get averages of each student
                        double[] averages = new double[studentCount];
                        for (int i = 0; i < studentCount; i++)
                        {
                            double sum = 0;
                            for (int j = 0; j < subjectCount; j++)
                                sum += grades[i, j];
                            averages[i] = sum / subjectCount;
                        }

                        // To Find top three students
                        int[] topIndices = new int[Math.Min(3, studentCount)];
                        bool[] selected = new bool[studentCount];
                        for (int t = 0; t < topIndices.Length; t++)
                        {
                            double maxAvg = double.MinValue;
                            int maxIdx = -1;
                            for (int i = 0; i < studentCount; i++)
                            {
                                if (!selected[i] && averages[i] > maxAvg)
                                {
                                    maxAvg = averages[i];
                                    maxIdx = i;
                                }
                            }
                            if (maxIdx != -1)
                            {
                                topIndices[t] = maxIdx;
                                selected[maxIdx] = true;
                            }
                        }

                        Console.WriteLine("\nTop Students:");
                        for (int t = 0; t < topIndices.Length; t++)
                        {
                            int idx = topIndices[t];
                            Console.WriteLine($"{t + 1}. {studentNames[idx]} - Average: {averages[idx]:F2}");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nAll Students Data:");
                        for (int i = 0; i < studentCount; i++)
                        {
                            Console.Write($"{studentNames[i]}: ");
                            for (int j = 0; j < subjectCount; j++)
                            {
                                Console.Write($"{grades[i, j]} ");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case "3":
                        Console.Write("\nEnter student name to search: ");
                        string searchName = Console.ReadLine()!;
                        bool found = false;
                        for (int i = 0; i < studentCount; i++)
                        {
                            if (studentNames[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"Grades for {studentNames[i]}:");
                                for (int j = 0; j < subjectCount; j++)
                                {
                                    Console.WriteLine($"Subject #{j + 1}: {grades[i, j]}");
                                }
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }    
    }
}
