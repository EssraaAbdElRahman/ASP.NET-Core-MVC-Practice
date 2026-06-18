using WebMVCApplication.Models;
using WebMVCApplication.ViewModels.Department;

namespace WebMVCApplication.Services.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAll();
        Course? Details(int Id);
        void Create(Course course);
        IEnumerable<DepartmentListViewModel> DepartmentList();
    }
}
