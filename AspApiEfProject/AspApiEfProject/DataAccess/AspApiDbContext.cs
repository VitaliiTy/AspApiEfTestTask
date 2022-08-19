using AspApiEfProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AspApiEfProject.DataAccess
{
    public class AspApiDbContext : DbContext
    {
        public AspApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Account> Account { get; set; }
        public DbSet<Incident> Incident { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}
