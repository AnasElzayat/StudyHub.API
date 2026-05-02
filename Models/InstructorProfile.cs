namespace StudyHub.API.Models;

public class InstructorProfile
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string? Headline { get; set; }

    public decimal? AverageRating { get; set; }
    public int TotalCourses { get; set; }
    public int TotalStudents { get; set; }
    public decimal TotalProfit { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
