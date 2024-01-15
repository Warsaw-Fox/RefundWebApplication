namespace RefundWebApplication.Models.Domain
{
    public class EmailLogsModel
    {
        public Guid Id { get; set; } // Unikalny identyfikator logu e-mail
        public Guid ComplaintId { get; set; } // Klucz obcy do tabeli reklamacji
        public DateTime SentDate { get; set; } // Data i czas wysłania e-maila
        public string RecipientEmail { get; set; } // Adres e-mail odbiorcy
        public string EmailSubject { get; set; } // Temat e-maila
        public string EmailBody { get; set; } // Treść e-maila
    }
}
