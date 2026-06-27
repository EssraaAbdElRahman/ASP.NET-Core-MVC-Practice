using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Validation;
using WebMVCApplication.AppContext;
using WebMVCApplication.Models;
using WebMVCApplication.Services.Interfaces;
using WebMVCApplication.Validator.Courses;
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
            course.Name = course.Name.Trim();
          
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
 
            if (NameExiste(course))
            {
                throw new InvalidOperationException("Course Name can't repeat in department.");
            }

        }
        private bool NameExiste(Course course)
        {
            return _context.Courses.Any(c =>
                    c.Name == course.Name &&
                    c.DepartmentId == course.DepartmentId && c.Id != course.Id);
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

        public IQueryable<Course> GetAll()
        {
            return _context.Courses.Include(i => i.Department);
        }

        public void Edit(Course course)
        {
            var currentCourse =_context.Courses.SingleOrDefault(c => c.Id == course.Id);

            if (currentCourse == null)
                throw new InvalidOperationException("Course not found.");

            course.Name = course.Name.Trim();

            ValidateCourse(course);

            currentCourse.Name = course.Name;
            currentCourse.Degree = course.Degree;
            currentCourse.MinDegree = course.MinDegree;
            currentCourse.DepartmentId = course.DepartmentId;
            currentCourse.Houre = course.Houre;
            _context.SaveChanges();

        }
    }
}
