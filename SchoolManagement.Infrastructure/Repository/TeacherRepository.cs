using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.IRepository;
using SchoolManagement.Model.Entities;

namespace SchoolManagement.Infrastructure.Repository;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _context;
    public TeacherRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> AddTeacher(Teacher teacher)
    {
        try
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<Teacher>> GetTeachers(string searchString)
    {
        var teachers = await _context.Teachers.ToListAsync();

        if (!string.IsNullOrEmpty(searchString))
        {
            teachers = teachers.Where(s => s.Name.Contains(searchString)).ToList();
        }
        return teachers;
    }
}
