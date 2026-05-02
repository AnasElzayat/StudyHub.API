namespace StudyHub.API.Models;

public class LectureProgress
{
    public int LectureId { get; set; }
    public Lecture Lecture { get; set; } = null!;

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int WatchedSeconds { get; set; }
    public int? DurationSecondsSnapshot { get; set; }
    public DateTime LastAccessedAt { get; set; }
    public bool IsCompleted { get; set; }
}
