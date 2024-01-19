using Microsoft.EntityFrameworkCore;
using RefundWebApplication.Models.Domain;

namespace RefundWebApplication.Data
{
    public class MainDbContext : DbContext
    {
        private const string V = "F117825F-F03C-413F-A51A-EFCC90F0AF4F";

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }
        public DbSet<ComplaintModel> Complaints { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplaintModel>().HasData(
            new ComplaintModel
            {
                Id = Guid.NewGuid(), // Generate a unique ID
                FirstName = "Jane",
                LastName = "Smith",
                Street = "456 Oak St",
                HouseNumber = "Suite 101",
                PostalCode = "54321",
                City = "Sample Town",
                Phone = "555-987-6543",
                Email = "jane.smith@example.com",
                SerialNumber = "0987654321",
                PurchaseDate = DateTime.Now.AddMonths(-3), // Adjust purchase date as needed
                IssueDescription = "Product issue description goes here"
            });
       
            base.OnModelCreating(modelBuilder);
        }


    }
}