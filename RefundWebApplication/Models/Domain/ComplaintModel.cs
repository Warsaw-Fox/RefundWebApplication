using NuGet.Packaging.Signing;
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
        public string ProductModel { get; set; }
        public string Email { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string IssueDescription { get; set; }
        // public string FileName { get; set; }
        // public string FilePath { get; set; }
        // public string FileType { get; set; }
        public DateTime IssueDate { get; set; }
        public string FixDescription { get; set; }
        public string Status { get; set; }
        // public string PDFName { get; set; }
        // public string PDFPath { get; set; }

    }
}

