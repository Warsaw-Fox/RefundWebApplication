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
           /* modelBuilder.Entity<CustomerModel>().HasData(
                new CustomerModel
                {
                    Id = Guid.NewGuid(), // Assign a unique Guid as the Id
                    FirstName = "John",
                    LastName = "Doe",
                    Street = "123 Main Street",
                    HouseNumber = "Apt 4B",
                    PostalCode = "12345",
                    City = "Example City",
                    Phone = "555-555-5555",
                    Email = "john.doe@example.com"
                }); */

            /* modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel
                {
                    Id = Guid.NewGuid(), // Assign a unique Guid as the Id
                    Name = "Example Product",
                    SerialNumber = "1234567890",
                    PurchaseDate = DateTime.Now.AddMonths(-3),
                    WarrantyEndDate = DateTime.Parse("2023-01-15")
                }); */
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
           /* modelBuilder.Entity<ComplaintHistoryModel>().HasData(
                new ComplaintHistoryModel
                {
                    Id = Guid.NewGuid(), // Generate a unique ID
                    ComplaintId = Guid.Parse(V),
                    ActionDate = DateTime.Now.AddMonths(-1), // Adjust action date as needed
                    Action = "Change status", // Provide the action description
                    Status = "Resolved", // Provide the status
                    Details = "Complaint has been resolved." // Provide details
                }); ; */

            /* modelBuilder.Entity<AttachmentModel>().HasData(
        new AttachmentModel
        {
            Id = Guid.NewGuid(), // Generate a unique ID
            ComplaintId = Guid.Parse(V),
            FileName = "example.jpg", // Provide the file name
            FilePath = "/uploads/example.jpg", // Provide the file path
            FileType = "image", // Provide the file type
            UploadDate = DateTime.Now.AddMonths(-1) // Adjust upload date as needed
        }); */

           /* modelBuilder.Entity<EmailLogsModel>().HasData(
                new EmailLogsModel
                {
                    Id = Guid.NewGuid(), // Generate a unique ID
                    ComplaintId = Guid.Parse(V),
                    SentDate = DateTime.Now.AddMonths(-1), // Adjust sent date as needed
                    RecipientEmail = "recipient@example.com", // Provide the recipient's email address
                    EmailSubject = "Sample Email", // Provide the email subject
                    EmailBody = "This is a sample email body." // Provide the email body
                }); */





            base.OnModelCreating(modelBuilder);
        }


    }
}