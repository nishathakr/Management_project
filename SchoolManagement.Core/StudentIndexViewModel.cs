
using SchoolManagement.Model.Entities;

namespace SchoolManagement.Core;

public class StudentIndexViewModel
{
    public IEnumerable<Student> Students { get; set; }
    public string SearchString { get; set; }

}
