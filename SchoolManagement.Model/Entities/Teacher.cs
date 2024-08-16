using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Model.Entities
{
    public class Teacher : BaseEntity
    {

        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
      
    }
}
