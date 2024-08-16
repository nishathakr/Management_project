using SchoolManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.IRepository
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetTeachers(string searchString);
        Task<bool> AddTeacher(Teacher teacher);
    }
}
