using SchoolManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.IRepository
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetSubjects();
        Task<bool> AddSubject(Subject subject);
        Task<List<Language>> GetLanguages();
    }
}
