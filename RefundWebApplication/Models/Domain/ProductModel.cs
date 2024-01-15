namespace RefundWebApplication.Models.Domain
{
    public class ProductModel
    {
        public Guid Id { get; set; } // Unikalny identyfikator produktu
        public string Name { get; set; } // Nazwa produktu
        public string SerialNumber { get; set; } // Numer seryjny produktu
        public DateTime PurchaseDate { get; set; } // Data zakupu
        public DateTime WarrantyEndDate { get; set; } // Data zakończenia gwarancji
    }
}
