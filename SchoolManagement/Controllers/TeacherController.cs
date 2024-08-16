using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SchoolManagement.Core.IRepository;
using SchoolManagement.Model.Entities;

namespace SchoolManagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IStudentRepository _studentRepository;

        public TeacherController(ITeacherRepository teacherRepository, IWebHostEnvironment hostEnvironment, IStudentRepository studentRepository)
        {
            _teacherRepository = teacherRepository;
            _hostEnvironment = hostEnvironment;
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var teachers = await _teacherRepository.GetTeachers(searchString);
            return View(teachers);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                if (teacher.ImageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(teacher.ImageFile.FileName);
                    string extension = Path.GetExtension(teacher.ImageFile.FileName);
                    teacher.ImageUrl = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await teacher.ImageFile.CopyToAsync(fileStream);
                    }
                }

                await _teacherRepository.AddTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }
    }
}

