using Microsoft.EntityFrameworkCore;
using StudyHub.API.Models;

namespace StudyHub.API.Data;

public class StudyHubContext : DbContext
{
    public StudyHubContext(DbContextOptions<StudyHubContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<InstructorProfile> InstructorProfiles => Set<InstructorProfile>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseCategory> CourseCategories => Set<CourseCategory>();
    public DbSet<StudentCategory> StudentCategories => Set<StudentCategory>();
    public DbSet<Section> Sections => Set<Section>();
    public DbSet<Lecture> Lectures => Set<Lecture>();
    public DbSet<LectureProgress> LectureProgresses => Set<LectureProgress>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.Email).HasMaxLength(320);
            entity.Property(u => u.FullName).HasMaxLength(256);
            entity.Property(u => u.PasswordHash).HasMaxLength(512);
            entity.HasOne(u => u.StudentProfile)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(u => u.InstructorProfile)
                .WithOne(i => i.User)
                .HasForeignKey<InstructorProfile>(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(s => s.UserId);
        });

        modelBuilder.Entity<InstructorProfile>(entity =>
        {
            entity.HasKey(i => i.UserId);
            entity.Property(i => i.Headline).HasMaxLength(512);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(c => c.Name).HasMaxLength(128);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.Property(c => c.Title).HasMaxLength(512);
            entity.Property(c => c.Description).HasMaxLength(8000);
        });

        modelBuilder.Entity<CourseCategory>(entity =>
        {
            entity.HasKey(x => new { x.CourseId, x.CategoryId });
            entity.HasOne(x => x.Course)
                .WithMany(c => c.CourseCategories)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Category)
                .WithMany(c => c.CourseCategories)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<StudentCategory>(entity =>
        {
            entity.HasKey(x => new { x.StudentId, x.CategoryId });
            entity.HasOne(x => x.Student)
                .WithMany(s => s.StudentCategories)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Category)
                .WithMany(c => c.StudentCategories)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasOne(s => s.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.Property(s => s.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasOne(l => l.Section)
                .WithMany(s => s.Lectures)
                .HasForeignKey(l => l.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.Property(l => l.Title).HasMaxLength(512);
            entity.Property(l => l.VideoUrl).HasMaxLength(2048);
        });

        modelBuilder.Entity<LectureProgress>(entity =>
        {
            entity.HasKey(lp => new { lp.LectureId, lp.StudentId });
            entity.HasOne(lp => lp.Lecture)
                .WithMany(l => l.LectureProgresses)
                .HasForeignKey(lp => lp.LectureId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(lp => lp.Student)
                .WithMany(s => s.LectureProgresses)
                .HasForeignKey(lp => lp.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.CourseId });
            entity.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasIndex(r => new { r.StudentId, r.CourseId }).IsUnique();
            entity.HasOne(r => r.Student)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(r => r.Course)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(o => o.Student)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(i => i.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(i => i.Course)
                .WithMany(c => c.OrderItems)
                .HasForeignKey(i => i.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasIndex(p => p.OrderId).IsUnique();
            entity.Property(p => p.PaymentMethod).HasMaxLength(64);
            entity.Property(p => p.TransactionNo).HasMaxLength(256);
        });
    }
}
