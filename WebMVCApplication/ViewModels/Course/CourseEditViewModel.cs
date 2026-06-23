using System.ComponentModel.DataAnnotations;
using WebMVCApplication.Attributes;
using WebMVCApplication.ViewModels.Department;

namespace WebMVCApplication.ViewModels.Course
{
    public class CourseEditViewModel
    {
        public int CourseId  { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Course can't be more than 100 characters ")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        public string CourseName { get; set; } = string.Empty;
        [Range(50, 100, ErrorMessage = "Degree must be between 50 and 100")]
        public double CourseDegree { get; set; }
        [LessThan(nameof(CourseDegree), ErrorMessage = "Min Degree must be less than Degree")]
        public double CourseMinDegree { get; set; }
        [DivisibleByThree(ErrorMessage = "Course hours must be divisible by 3")]
        public int CourseHours { get; set; }
        public int CourseDeptId { get; set; }
        public List<DepartmentListViewModel> Departments { get; set; } = [];
    }
}
