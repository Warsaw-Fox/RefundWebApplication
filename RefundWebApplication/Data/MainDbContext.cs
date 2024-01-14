using Microsoft.EntityFrameworkCore;
using RefundWebApplication.Models.Domain;

namespace RefundWebApplication.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        // Definicje tabel
        public DbSet<ComplaintModel> Complaints { get; set; }
        
    }
}