using Microsoft.EntityFrameworkCore;
using testing_site_wil.Models;

namespace testing_site_wil.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Shopping> Shopping{get; set;}

        public DbSet<Event> Events{get; set;}
    }
}
