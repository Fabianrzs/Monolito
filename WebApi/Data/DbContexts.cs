using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class DbContexts:DbContext
    {
        public DbContexts(DbContextOptions<DbContexts> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; } = default!;
    }
}
