using Microsoft.AspNetCore.Mvc;
using WebMVCApplication.AppContext;
using WebMVCApplication.Services;
using WebMVCApplication.Services.Interfaces;
using WebMVCApplication.ViewModels.Course;
using WebMVCApplication.ViewModels.Instructor;

namespace WebMVCApplication.Controllers
{
    public class CourseController : Controller
    {
        AppDbContext context;
        CourseService courseService;

        public CourseController()
        {
            context = new AppDbContext();
            courseService = new CourseService(context);
        }

        public IActionResult Index()
        {
            var courses = courseService.GetAll();
            var courseDetailsModelView = courses.Select(
                c => new CourseDetailsViewModel()
                {
                    CourseId = c.Id,
                    CourseName = c.Name,
                    CourseDegree = c.Degree,
                    CourseMinDegree = c.MinDegree,
                    DeptName = c.Department.Name,
                }).ToList();
            return View("Index", courseDetailsModelView);
        }
        public IActionResult Create()
        {
            var departments = courseService.DepartmentList().ToList();
            var viewModel = new CourseCreateNewViewModel()
            {
                Departments = departments
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        public IActionResult SaveNew(CourseCreateNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.Departments = courseService.DepartmentList().ToList();
                return View("Create", viewModel);
            }
            try
            {
                courseService.Create(new()
                {
                    Name = viewModel.CourseName,
                    Degree = viewModel.CourseDegee,
                    MinDegree = viewModel.CourseMinDegee,
                    DepartmentId = viewModel.CourseDeptId
                });

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                viewModel.Departments = courseService.DepartmentList().ToList();

                return View("Create", viewModel);
            }
        }
        public IActionResult Details(int Id)
        {
            if (Id <= 0)
            {
                return NotFound();
            }
            var course = courseService.Details(Id);
            if (course != null)
            {
                CourseDetailsViewModel viewModel = new CourseDetailsViewModel()
                {
                    CourseId = course.Id,
                    CourseName = course.Name,
                    DeptName = course.Department.Name,
                    CourseDegree = course.Degree,
                    CourseMinDegree = course.MinDegree
                };
                return View("Details", viewModel);
            }
            return NotFound();
        }
    }
}
