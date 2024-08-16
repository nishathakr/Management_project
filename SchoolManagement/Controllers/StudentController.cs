using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using SchoolManagement.Core.IRepository;
using SchoolManagement.Model.Entities;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ITeacherRepository _teacherRepository;

        public StudentController(IStudentRepository studentRepository, IWebHostEnvironment hostEnvironment, ITeacherRepository teacherRepository)
        {
            _studentRepository = studentRepository;
            _hostEnvironment = hostEnvironment;
            _teacherRepository = teacherRepository;
        }
        public async Task<IActionResult> Index(string searchString, string searchClass)
        {
            var students = await _studentRepository.GetStudents(searchString, searchClass);
            return View(students);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Teachers"] = await _teacherRepository.GetTeachers(string.Empty);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(student.ImageFile.FileName);
                    string extension = Path.GetExtension(student.ImageFile.FileName);
                    student.ImageUrl = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await student.ImageFile.CopyToAsync(fileStream);
                    }   
                }

                await _studentRepository.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
