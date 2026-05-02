namespace StudyHub.API.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string? Bio { get; set; }
    public string PasswordHash { get; set; } = null!;
    public string? ProfileImageUrl { get; set; }
    public UserRole Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public Student? StudentProfile { get; set; }
    public InstructorProfile? InstructorProfile { get; set; }
}
