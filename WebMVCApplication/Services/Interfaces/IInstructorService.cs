using WebMVCApplication.Models;
using WebMVCApplication.ViewModels.Course;
using WebMVCApplication.ViewModels.Department;

namespace WebMVCApplication.Services.Interfaces
{
    public interface IInstructorService
    {
        IEnumerable<Instructor> GetAll();
        Instructor? Details(int id);
        void Create(Instructor instructor);
        IEnumerable<CourseListViewModel> CoursesList();

        IEnumerable<DepartmentListViewModel> DepartmentList();
    }
}
