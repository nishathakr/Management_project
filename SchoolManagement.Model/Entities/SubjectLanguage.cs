
namespace SchoolManagement.Model.Entities;

public class SubjectLanguage
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int LanguageId { get; set; }
    public Language Language { get; set; }
}
