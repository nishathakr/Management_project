using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Core.IRepository;
using SchoolManagement.Infrastructure.Repository;
using SchoolManagement.Model.Entities;

namespace SchoolManagement.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentRepository _studentRepository;
        public SubjectController(ISubjectRepository subjectRepository, IStudentRepository studentRepository)
        {
            _subjectRepository = subjectRepository;
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var subjects = await _subjectRepository.GetSubjects();
            return View(subjects);
        }

        public async Task<IActionResult> Create()
            {
            ViewData["Create"] = await _subjectRepository.GetLanguages();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                await _subjectRepository.AddSubject(subject);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Languages"] = await _subjectRepository.GetLanguages();
            return View(subject);
        }
    }
}
