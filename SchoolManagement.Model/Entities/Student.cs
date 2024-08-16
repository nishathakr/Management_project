using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Model.Entities
{
    public class Student : BaseEntity
    {
        [Required]
        public int Age { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public int RollNumber { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
    }
}
