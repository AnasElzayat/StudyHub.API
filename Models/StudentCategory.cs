namespace StudyHub.API.Models;

public class StudentCategory
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
