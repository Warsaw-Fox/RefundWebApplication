namespace RefundWebApplication.Models.Domain
{
    public class CustomerModel
    {
       public Guid Id { get; set; }   // Unikalny identyfikator klienta
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
