using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebMVCApplication.ViewModels.Department;

namespace WebMVCApplication.ViewModels.Course
{
    public class CourseCreateNewViewModel
    {
        [Required]
        public string CourseName { get; set; } = string.Empty;
        public double CourseDegee { get; set; }
        public double CourseMinDegee { get; set; }
        public int CourseDeptId { get; set; }
        public List<DepartmentListViewModel> Departments { get; set; } = [];
    }
}
