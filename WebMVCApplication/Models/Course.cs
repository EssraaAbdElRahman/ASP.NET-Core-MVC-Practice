namespace WebMVCApplication.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Degree { get; set; }
        public double  MinDegree { get; set; }
        public int Houre { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
        public ICollection<CourseResult> CourseResults { get; set; } = new List<CourseResult>();
    }
}
