using mvcwebapplication.Models;
using Microsoft.EntityFrameworkCore;

namespace mvcwebapplication.Dao
{
    public class MvcWebApplicationDbContext : DbContext
    {
        public MvcWebApplicationDbContext(DbContextOptions<MvcWebApplicationDbContext> options)
            : base(options) {}

        // Add DbSet(s) here
        public DbSet<BlogPost> BlogPosts {get;set;}
        public DbSet<Author> Authors {get;set;}
    }
}