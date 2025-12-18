using Microsoft.EntityFrameworkCore;

namespace HelloWorldWebApplication.Models
{
    public class HelloWorldWebApplicationDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public HelloWorldWebApplicationDbContext(DbContextOptions<HelloWorldWebApplicationDbContext> options) : base(options)
        {
            
        }
    }
}