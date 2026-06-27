using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebMVCApplication.Attributes;
using WebMVCApplication.ViewModels.Course;
using WebMVCApplication.ViewModels.Department;

namespace WebMVCApplication.ViewModels.Instructor
{
    public class InstructorCreateNewViewModel
    {
        [Required]
        [DisplayName("Instructor Name")]
        public string InstructorName { get; set; } = string.Empty;
        [Required]
        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "File size cannot exceed 2 MB.")]
        public IFormFile? ImageFile { get; set; }
        public string InstructorAddress { get; set; }=string.Empty;
        public string ImageUrl { get; set; }=string.Empty;
        public decimal InstructorSalary { get; set; }
        public int InstructorCourseId { get; set; }
        public int InstructorDepartmentId { get; set; }
        public List<DepartmentListViewModel> Departments { get; set; } = [];

        public List<CourseListViewModel> Courses { get; set; } = [];

    }
}
