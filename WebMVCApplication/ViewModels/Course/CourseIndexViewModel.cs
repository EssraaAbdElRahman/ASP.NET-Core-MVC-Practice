namespace WebMVCApplication.ViewModels.Course
{
    public class CourseIndexViewModel
    {
        public List<CourseDetailsViewModel> Courses { get; set; } = [];

        public string? Search { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
