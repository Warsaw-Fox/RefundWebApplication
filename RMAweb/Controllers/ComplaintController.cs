using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RMAweb.Models;

public class ComplaintController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public ComplaintController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index()
    {
        return View("ComplaintIndex");
    }

    [HttpPost]
    public IActionResult SubmitComplaint(ComplaintModel complaint)
    {
        // Logika obsługi formularza

        // Zapisz dane do pliku tekstowego
        SaveToTextFile(complaint);

        // Inne operacje, przekierowanie itp.
        return View("Confirmation");
    }

    private void SaveToTextFile(ComplaintModel complaint)
    {
        string fileName = "complaints.txt";
        string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "App_Data", fileName);

        // Generowanie unikalnego numeru reklamacji (ID)
        string complaintId = Guid.NewGuid().ToString("N").Substring(0, 4);

        // Tworzenie lub dopisywanie do pliku tekstowego
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"Numer reklamacji: {complaintId}");
            writer.WriteLine($"Imię: {complaint.FirstName}");
            writer.WriteLine($"Nazwisko: {complaint.LastName}");
            writer.WriteLine($"Ulica: {complaint.Street}");
            writer.WriteLine($"Numer domu/mieszkania: {complaint.HouseNumber}");
            writer.WriteLine($"Kod pocztowy: {complaint.PostalCode}");
            writer.WriteLine($"Miejscowość: {complaint.City}");
            writer.WriteLine($"Telefon: {complaint.Phone}");
            writer.WriteLine($"Email: {complaint.Email}");
            writer.WriteLine($"Numer seryjny: {complaint.SerialNumber}");
            writer.WriteLine($"Data zakupu: {complaint.PurchaseDate.ToString("dd.MM.yyyy")}");
            writer.WriteLine($"Opis usterki: {complaint.IssueDescription}");
            writer.WriteLine(); // Dodaj pustą linię dla czytelności
        }
    }

}