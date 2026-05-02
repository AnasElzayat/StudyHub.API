namespace StudyHub.API.Models;

public enum UserRole
{
    Student = 0,
    Instructor = 1
}

public enum CourseLevel
{
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2
}

public enum CourseStatus
{
    Draft = 0,
    Published = 1,
    Archived = 2
}

public enum OrderStatus
{
    Pending = 0,
    Paid = 1,
    Cancelled = 2,
    Refunded = 3
}

public enum PaymentStatus
{
    Pending = 0,
    Completed = 1,
    Failed = 2,
    Refunded = 3
}
