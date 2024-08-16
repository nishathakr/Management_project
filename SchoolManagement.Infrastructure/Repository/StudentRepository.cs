using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.IRepository;
using SchoolManagement.Model.Entities;

namespace SchoolManagement.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddStudent(Student student)
        {
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Student>> GetStudents(string searchString, string searchClass)
        {
            var students = await _context.Students.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString)).ToList();
            }

            if (!string.IsNullOrEmpty(searchClass))
            {
                students = students.Where(s => s.Class == searchClass).ToList();
            }

            return students;
        }
        //public async Task<List<Class>> GetClasses()
        //{
        //    return await _context.Classes.ToListAsync();
        //}
    }
}
