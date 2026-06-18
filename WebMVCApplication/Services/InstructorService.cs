using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebMVCApplication.AppContext;
using WebMVCApplication.Models;
using WebMVCApplication.Services.Interfaces;
using WebMVCApplication.Validator;
using WebMVCApplication.ViewModels.Course;
using WebMVCApplication.ViewModels.Department;

namespace WebMVCApplication.Services
{
    public class InstructorService : IInstructorService
    {
        AppDbContext _context;
        public InstructorService(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Instructor instructor)
        {
            if (instructor == null)
            {
                throw new ArgumentNullException(nameof(instructor));
            }           
            ValidateInstructor(instructor);

            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        private void ValidateInstructor(Instructor instructor)
        {
            var validator = new InstructorValidator();
            validator.ValidateAndThrow(instructor);
            if (!DepartmentExists(instructor.DepartmentId))
            {
                throw new InvalidOperationException("Department not found.");
            }
            if (!CourseExists(instructor.CourseId))
            {
                throw new InvalidOperationException("Course not found.");
            }
        }

        private bool CourseExists(int courseId)
        {
            return _context.Courses.Any(d => d.Id == courseId);
        }

        private bool DepartmentExists(int departmentId)
        {
            return _context.Departments.Any(d => d.Id == departmentId);
        }

        public Instructor? Details(int id)
        {           
                return _context.Instructors.Include(i => i.Course)
                                              .Include(i => i.Department)
                                              .SingleOrDefault(i => i.Id == id);
        }
        public IEnumerable<Instructor> GetAll()
        {
            return  _context.Instructors
                           .Include(i => i.Course)
                           .Include(i => i.Department).ToList();
        }
        public IEnumerable<CourseListViewModel> CoursesList()
        {
            return _context.Courses
                .Select(c => new CourseListViewModel
                {
                    CourseId = c.Id,
                    CourseName = c.Name
                })
                .ToList();
        }

        public IEnumerable<DepartmentListViewModel> DepartmentList()
        {
            return _context.Departments
                .Select(c => new DepartmentListViewModel
                {
                    DeptId = c.Id,
                    DeptName = c.Name
                })
                .ToList();
        }
    }
}
