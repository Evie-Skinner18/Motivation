using Microsoft.EntityFrameworkCore;
using Motivation.Data.Models;


namespace Motivation.Data
{
    public class MotivationDbContext : DbContext
    {
        public MotivationDbContext() { }

        public MotivationDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Message> Messages { get; set; }
    }
}
