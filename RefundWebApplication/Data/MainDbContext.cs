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
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ComplaintHistoryModel> ComplaintHistories { get; set; }
        public DbSet<AttachmentModel> Attachments { get; set; }
        public DbSet<EmailLogsModel> EmailLogs { get; set; }


    }
}