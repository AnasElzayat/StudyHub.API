namespace StudyHub.API.Models;

public class Lecture
{
    public int Id { get; set; }
    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;

    public string Title { get; set; } = null!;
    public int DurationSeconds { get; set; }
    public bool IsPreview { get; set; }
    public string? VideoUrl { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<LectureProgress> LectureProgresses { get; set; } = new List<LectureProgress>();
}
