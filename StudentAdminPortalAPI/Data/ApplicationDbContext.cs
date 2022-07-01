using Microsoft.EntityFrameworkCore;
using StudentAdminPortalAPI.Model;

namespace StudentAdminPortalAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}
