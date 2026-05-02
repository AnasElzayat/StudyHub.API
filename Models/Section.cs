namespace StudyHub.API.Models;

public class Section
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int DisplayOrder { get; set; }

    public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}
