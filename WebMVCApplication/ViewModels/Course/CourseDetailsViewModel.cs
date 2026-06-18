namespace WebMVCApplication.ViewModels.Course
{
    public class CourseDetailsViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public double CourseDegree { get; set; }
        public double CourseMinDegree { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
