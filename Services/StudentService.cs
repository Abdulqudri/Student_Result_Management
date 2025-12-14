namespace StudentResults.Services
{
    public class StudentService
    {
        private readonly List<Student> _students;
        public StudentService(List<Student> students)
        {
            _students = students;
        }
        public void AddStudent(string name)
        {
            _students.Add(new Student{Name=name});
        }

        public Student? GetStudentByName(string name)
        {
            return _students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        } 

        public void AddResult(Student student, string courseCode, double score)
        {
            student.Results.Add(
                new CourseResult
                {
                    CourseCode = courseCode,
                    Score=score
                }
            );
        }
        public List<Student> GetAllStudent() => _students;
    }
}