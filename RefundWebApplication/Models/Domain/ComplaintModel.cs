using System;
using System.ComponentModel.DataAnnotations;

namespace RefundWebApplication.Models.Domain
{
    public class ComplaintModel
    {
        public Guid Id { get; set; } // Unikalny identyfikator zgłoszenia
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string IssueDescription { get; set; }
        // Define a collection of attachments related to this complaint
        public ICollection<AttachmentModel> Attachments { get; set; }
        public ICollection<ComplaintHistoryModel> History { get; set; }
        public ICollection<CustomerModel> Customer { get; set; }
        public ICollection<EmailLogsModel> EmailLogs { get; set; }
        public ICollection<ProductModel> Products { get; set; }

    }
}

