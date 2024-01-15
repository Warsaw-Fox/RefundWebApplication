namespace RefundWebApplication.Models.Domain
{
    public class ComplaintHistoryModel
    {
        public Guid Id { get; set; } // Unikalny identyfikator historii reklamacji
        public Guid ComplaintId { get; set; } // Klucz obcy do tabeli reklamacji
        public DateTime ActionDate { get; set; } // Data wykonania akcji
        public string Action { get; set; } // Opis wykonanej akcji (np. zmiana statusu, dodanie komentarza)
        public string Status { get; set; } // Aktualny status reklamacji po wykonaniu akcji
        public string Details { get; set; } // Szczegółowe informacje o akcji (np. treść komentarza)
    }
}
