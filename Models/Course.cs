namespace StudyHub.API.Models;

public class Course
{
    public int Id { get; set; }
    public int InstructorId { get; set; }
    public InstructorProfile Instructor { get; set; } = null!;

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public CourseLevel Level { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? Language { get; set; }
    public CourseStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<CourseCategory> CourseCategories { get; set; } = new List<CourseCategory>();
    public ICollection<Section> Sections { get; set; } = new List<Section>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
