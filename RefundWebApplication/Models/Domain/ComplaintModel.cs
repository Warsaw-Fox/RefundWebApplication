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
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string IssueDescription { get; set; }

    }
}

