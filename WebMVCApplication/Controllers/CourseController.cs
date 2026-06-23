using Microsoft.AspNetCore.Mvc;
using WebMVCApplication.AppContext;
using WebMVCApplication.Services;
using WebMVCApplication.ViewModels.Course;

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

        public IActionResult Index(string? search, int page = 1)
        {
            int pageSize = 5;

            var query = courseService.GetAll().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();

                query = query.Where(c =>
                    c.Name.Contains(search) ||
                    c.Department.Name.Contains(search));
            }
            int totalItems = query.Count();

            var courses = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var result = new CourseIndexViewModel
            {
                Courses = courses.Select(c => new CourseDetailsViewModel()
                {
                    CourseId = c.Id,
                    CourseName = c.Name,
                    CourseDegree = c.Degree,
                    CourseMinDegree = c.MinDegree,
                    DeptName = c.Department.Name,
                    CourseHours = c.Houre
                }).ToList(),
                Search = search,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };

            return View(result);
        }

        public IActionResult Index1()
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
                    CourseHours=c.Houre
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
                    Degree = viewModel.CourseDegree,
                    MinDegree = viewModel.CourseMinDegree,
                    DepartmentId = viewModel.CourseDeptId,
                    Houre=viewModel.CourseHours
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
                    CourseMinDegree = course.MinDegree,
                    CourseHours=course.Houre                

                    
                };
                return View("Details", viewModel);
            }
            return NotFound();
        }
        public IActionResult Edit(int Id)
        {
            var departments = courseService.DepartmentList().ToList();
          
            var course = courseService.Details(Id);
            if (course != null)
            {
                var viewModel = new CourseEditViewModel()
                {
                    CourseId = course.Id,
                    CourseName = course.Name,
                    CourseDegree = course.Degree,
                    CourseMinDegree = course.MinDegree,
                    Departments = departments,
                    CourseHours=course.Houre,
                    CourseDeptId=course.DepartmentId                


                };
                return View("Edit", viewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult SaveEdit(CourseEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.Departments = courseService.DepartmentList().ToList();
                return View("Edit", viewModel);
            }
            try
            {
                courseService.Edit(new()
                {
                    Id=viewModel.CourseId,
                    Name = viewModel.CourseName,
                    Degree = viewModel.CourseDegree,
                    MinDegree = viewModel.CourseMinDegree,
                    DepartmentId = viewModel.CourseDeptId,
                    Houre = viewModel.CourseHours
                });

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                viewModel.Departments = courseService.DepartmentList().ToList();

                return View("Edit", viewModel);
            }
        }
    }
}
