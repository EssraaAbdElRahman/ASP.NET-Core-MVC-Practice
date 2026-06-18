using Microsoft.AspNetCore.Mvc;
using WebMVCApplication.AppContext;
using WebMVCApplication.Services;
using WebMVCApplication.ViewModels.Instructor;

namespace WebMVCApplication.Controllers
{
    public class InstructorController : Controller
    {
        AppDbContext context;
        InstructorService instructorService;

        public InstructorController()
        {
            context = new AppDbContext();
            instructorService = new InstructorService(context);
        }

        public IActionResult Index()
        {
            var instructors = instructorService.GetAll();

            var instructorViewModels =
                instructors.Select(i => new InstructorDetailsViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Image = i.Image,
                    Address = i.Address,
                    Salary = i.Salary,
                    CourseName = i.Course.Name,
                    DepartmentName = i.Department.Name
                }).ToList();

            return View(instructorViewModels);
        }
        
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var instructor = instructorService.Details(id);
                if (instructor != null)
                {
                    InstructorDetailsViewModel viewModel = new InstructorDetailsViewModel()
                    {
                        Id = instructor.Id,
                        Name = instructor.Name,
                        Image = instructor.Image,
                        Address = instructor.Address,
                        Salary = instructor.Salary,
                        CourseName = instructor.Course.Name,
                        DepartmentName = instructor.Department.Name
                    };
                    return View("Details", viewModel);
                }
                return NotFound();
        }
        public IActionResult Create()
        {
            var courseList=instructorService.CoursesList().ToList();
            var department=instructorService.DepartmentList().ToList();
            var instructorViewModel = new InstructorCreateNewViewModel()
            {
                Courses= courseList,
                Departments= department
            };
            return View("Create", instructorViewModel);
        }
        [HttpPost]
        public IActionResult SaveNew(InstructorCreateNewViewModel instructorViewModel)
        {
            if (!ModelState.IsValid)
            {
                 
                instructorViewModel.Courses = instructorService.CoursesList().ToList();
                instructorViewModel.Departments = instructorService.DepartmentList().ToList();

                return View("Create",instructorViewModel);
            }
            try
            {
                instructorService.Create(
                    new()
                    {
                         Name = instructorViewModel.InstructorName,
                         Address=instructorViewModel.InstructorAddress,
                         Image=instructorViewModel.ImageUrl,
                         Salary=instructorViewModel.InstructorSalary,
                         DepartmentId=instructorViewModel.InstructorDepartmentId,
                         CourseId=instructorViewModel.InstructorCourseId
                    });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                instructorViewModel.Courses = instructorService.CoursesList().ToList();
                instructorViewModel.Departments = instructorService.DepartmentList().ToList();

                return View("Create", instructorViewModel);
            }
         }

    }
}

