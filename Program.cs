using StudentResults.Services;
using StudentResults.Storage;


namespace StudentResults;
class Program
{
    static void Main()
    {

        var students = FileStorage.Load();
        var service = new StudentService(students);

        while (true)
        {

            Console.WriteLine("\nStudent Result Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Course Result");
            Console.WriteLine("3. View Transcript");
            Console.WriteLine("4. Save & Exit");
            Console.Write("Choose option: ");


            var choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    Console.Write("Student name: ");
                    service.AddStudent(Console.ReadLine() ?? "Unknown");
                    break;


                case "2":
                    Console.Write("Student name: ");
                    var student = service.GetStudentByName(Console.ReadLine() ?? "");
                    if (student == null)
                    {
                        Console.WriteLine("Student not found");
                        break;
                    }


                    Console.Write("Course code: ");
                    var course = Console.ReadLine() ?? "";


                    Console.Write("Score: ");
                    if (double.TryParse(Console.ReadLine(), out var score))
                    {
                        service.AddResult(student, course, score);
                    }
                    else
                    {
                        Console.WriteLine("Invalid score");
                    }
                    break;


                case "3":
                    Console.Write("Student name: ");
                    var s = service.GetStudentByName(Console.ReadLine() ?? "");
                    if (s == null)
                    {
                        Console.WriteLine("Student not found");
                        break;
                    }


                    Console.WriteLine($"\nTranscript for {s.Name}");
                    foreach (var r in s.Results)
                    {
                        Console.WriteLine($"{r.CourseCode} - {r.Score} ({r.Grade})");
                    }
                    Console.WriteLine($"GPA: {s.CalculateGPA()}");
                    break;


                case "4":
                    FileStorage.Save(students);
                    return;


                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}