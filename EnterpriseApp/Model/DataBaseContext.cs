using System.Data.Entity;

namespace EnterpriseApp.Model
{
    public class DataBaseContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
