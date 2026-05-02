namespace StudyHub.API.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<CourseCategory> CourseCategories { get; set; } = new List<CourseCategory>();
    public ICollection<StudentCategory> StudentCategories { get; set; } = new List<StudentCategory>();
}
