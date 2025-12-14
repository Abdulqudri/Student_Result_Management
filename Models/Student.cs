namespace StudentResults.Models
{
    public class Student
    {
        public Guid Id {get;set;} = Guid.NewGuid();
        public string Name {get; set;} = string.Empty();
        public List<CourseResult> Results {set; get;} = new();

        public double CalculateGPA()
        {
            if (Results.Count == 0) return 0.0;

            var totalGP = Results.Sum(r => r.GradePoint);
            return Math.Round((double)totalGP / Results.Count, 2);
        }
    }
}