using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.IRepository;
using SchoolManagement.Model.Entities;

namespace SchoolManagement.Infrastructure.Repository;

public class SubjectRepository : ISubjectRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public SubjectRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Subject>> GetSubjects()
    {
        var subjects = await _applicationDbContext.Subjects
            .ToListAsync();
        return subjects;
    }

    public async Task<bool> AddSubject(Subject subject)
    {
        try
        {
            await _applicationDbContext.AddAsync(subject);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<List<Language>> GetLanguages()
    {
        return await _applicationDbContext.Languages.ToListAsync();
    }
}
