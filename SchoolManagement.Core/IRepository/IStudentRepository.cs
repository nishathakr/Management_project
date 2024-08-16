using SchoolManagement.Model.Entities;

namespace SchoolManagement.Core.IRepository;

public interface IStudentRepository
{
    Task<List<Student>> GetStudents(string searchString, string searchClass);
    Task<bool> AddStudent(Student student);
    //Task<List<Class>> GetClasses();
}
