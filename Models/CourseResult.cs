namespace StudentResults.Models
{
    public class CourseResult
    {
        public string CourseCode { get; set; } = string.Empty;
        public double Score { get; set;  }

        public Grade Grade => Score switch
        {
            >= 70 => Grade.A,
            >= 60 => Grade.B,
            >= 50 => Grade.C,
            >= 40 => Grade.D,
            >= 30 => Grade.E,   
            _ => Grade.F
        };

        public int GradePoint => Grade switch
        {
            Grade.A => 5,
            Grade.B => 4, 
            Grade.C => 3,
            Grade.D => 2,
            Grade.E => 1,
            Grade.F => 0
        };
    }
}