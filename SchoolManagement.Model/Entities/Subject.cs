using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.Entities
{
    public class Subject : BaseEntity
    {
        [Required]
        public string Class { get; set; }
        public List<Language> Languages { get; set; }
        public List<SubjectLanguage> SubjectLanguages { get; set; }
 
    }
}
