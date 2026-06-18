namespace WebMVCApplication.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public double Degree { get; set; }
        public int DepartmentId  { get; set; }
        public Department Department { get; set; } 
        public ICollection<CourseResult> CourseResults { get; set; } = new List<CourseResult>();
 
    }
}
