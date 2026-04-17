using Microsoft.EntityFrameworkCore;

namespace StudyHub.API.Data
{
    public class StudyHubContext : DbContext
    {
        public StudyHubContext(DbContextOptions<StudyHubContext> options) : base(options)
        {
        }
        
        // Add your DbSets here later
    }
}
