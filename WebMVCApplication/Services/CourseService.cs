using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebMVCApplication.AppContext;
using WebMVCApplication.Models;
using WebMVCApplication.Services.Interfaces;
using WebMVCApplication.Validator;
using WebMVCApplication.ViewModels.Department;

namespace WebMVCApplication.Services
{
    public class CourseService : ICourseService
    {
        AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<DepartmentListViewModel> DepartmentList()
        {
            return _context.Departments.Select(d => new DepartmentListViewModel
            {
                DeptId = d.Id,
                DeptName = d.Name
            });
        }

        public void Create(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            ValidateCourse(course);

            _context.Courses.Add(course);
            _context.SaveChanges();

        }
        private void ValidateCourse(Course course)
        {
            var validator = new CourseValidator();
            validator.ValidateAndThrow(course);
            if (!DepartmentExists(course.DepartmentId))
            {
                throw new InvalidOperationException("Department not found.");
            }

        }

        private bool DepartmentExists(int departmentId)
        {
            return _context.Departments.Any(d => d.Id == departmentId);
        }

        public Course? Details(int Id)
        {
            return _context.Courses
                  .Include(i => i.Department)
                     .SingleOrDefault(i => i.Id == Id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(i => i.Department).ToList();
        }
    }
}
