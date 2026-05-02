namespace StudyHub.API.Models;

public class Student
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public ICollection<LectureProgress> LectureProgresses { get; set; } = new List<LectureProgress>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<StudentCategory> StudentCategories { get; set; } = new List<StudentCategory>();
}
