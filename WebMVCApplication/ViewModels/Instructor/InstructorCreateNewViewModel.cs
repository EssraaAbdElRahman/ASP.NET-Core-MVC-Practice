using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebMVCApplication.ViewModels.Course;
using WebMVCApplication.ViewModels.Department;

namespace WebMVCApplication.ViewModels.Instructor
{
    public class InstructorCreateNewViewModel
    {
        [Required]
        [DisplayName("Instructor Name")]
        public string InstructorName { get; set; } = string.Empty;
        public string ImageUrl { get; set; }= string.Empty;
        public string InstructorAddress { get; set; }=string.Empty;
        public decimal InstructorSalary { get; set; }
        public int InstructorCourseId { get; set; }
        public int InstructorDepartmentId { get; set; }
        public List<DepartmentListViewModel> Departments { get; set; } = [];

        public List<CourseListViewModel> Courses { get; set; } = [];

    }
}
