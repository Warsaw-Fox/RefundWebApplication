using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System;
using System.IO;
using RefundWebApplication.Models.Domain;

public class PdfController : Controller
{
    [HttpPost]
    public IActionResult GeneratePdf(ComplaintModel model)
    {
        // Utwórz nowy dokument PDF.
        PdfDocument document = new PdfDocument();
        // Dodaj stronę do dokumentu.
        PdfPage page = document.Pages.Add();
        // Utwórz grafikę PDF dla strony.
        PdfGraphics graphics = page.Graphics;
        // Ustaw standardową czcionkę.
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

              // Dane z formularza
        string id = model.Id.ToString();
        string firstName = model.FirstName;
        string lastName = model.LastName;
        string street = model.Street;
        string houseNumber = model.HouseNumber;
        string postalCode = model.PostalCode;
        string city = model.City;
        string phone = model.ProductModel;
        string email = model.Email;
        string serialNumber = model.SerialNumber;
        string issueDescription = model.IssueDescription;
        string fixDescription = model.FixDescription;


        string text = "Dokument reklamacyjny";

        // Przykładowe użycie danych z formularza w dokumencie PDF
        string dataText = $"ID: {id}\nFirst Name: {firstName}\nLast Name: {lastName}\nStreet: {street}\nHouse Number: {houseNumber}\nPostal Code: {postalCode}\nCity: {city}\nPhone: {phone}\nEmail: {email}\nSerial Number: {serialNumber}\nIssue Description: {issueDescription}\nFix Description: {fixDescription}";

        // Łączymy tekst
        string finalText = $"{text}\n\n{dataText}";

        // Ustawienie położenia tekstu
        PointF location = new PointF(10, 10); // Deklaracja zmiennej location

        // Wyświetlenie tekstu na stronie
        graphics.DrawString(finalText, font, PdfBrushes.Black, location); // Użycie zmiennej location


        // Zapisz dokument PDF do strumienia pamięci.
        MemoryStream stream = new MemoryStream();
        document.Save(stream);
        // Ustaw pozycję na '0'.
        stream.Position = 0;
        // Pobierz dokument PDF w przeglądarce.
        FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

        // Ustaw nazwę pliku do pobrania.
        string fileName = $"GeneratedPDF_{DateTime.Now.ToString("yyyyMMddHHmmss")}.pdf";
        fileStreamResult.FileDownloadName = fileName;

        return fileStreamResult;
    }
}
