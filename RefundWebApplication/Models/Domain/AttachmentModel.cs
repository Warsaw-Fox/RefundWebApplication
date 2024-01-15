namespace RefundWebApplication.Models.Domain
{
    public class AttachmentModel
    {
        public Guid Id { get; set; } // Unikalny identyfikator załącznika
        public Guid ComplaintId { get; set; } // Klucz obcy do tabeli reklamacji
        public string FileName { get; set; } // Nazwa pliku
        public string FilePath { get; set; } // Ścieżka do przechowywania pliku
        public string FileType { get; set; } // Typ pliku (np. obraz, dokument)
        public DateTime UploadDate { get; set; } // Data dodania załącznika
    }
}
