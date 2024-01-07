using Microsoft.AspNetCore.Mvc;

public class WarrantyController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public WarrantyController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index()
    {
        ViewData["ShowSerialNumberInput"] = true;
        return View();
    }

    [HttpPost]
    public IActionResult CheckWarranty(string serialNumber)
    {
        bool isSerialNumberValid = CheckSerialNumberInFile(serialNumber);

        if (isSerialNumberValid)
        {
            ViewData["WarrantyStatusMessage"] = "Podany numer seryjny widnieje w naszej bazie, proszę wypełnić formularz zgłoszeniowy";
        }
        else
        {
            ViewData["WarrantyStatusMessage"] = "Podany numer nie widnieje w naszej bazie danych.";
        }

        ViewData["ShowSerialNumberInput"] = false; // Ukryj pole do wpisania numeru seryjnego

        // Zwróć widok strony głównej
        return View("~/Views/Home/Index.cshtml");
    }
    private bool CheckSerialNumberInFile(string serialNumber)
    {
        string fileName = "seryjne.txt";
        string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "App_Data", fileName);

        if (System.IO.File.Exists(filePath))
        {
            string fileContent = System.IO.File.ReadAllText(filePath);

            // Rozdziel numery seryjne na pojedyncze elementy
            string[] lines = fileContent.Split(',');

            // Usuń białe znaki z każdego numeru seryjnego
            string cleanedSerialNumber = new string(serialNumber.Where(char.IsDigit).ToArray());

            return lines.Contains(cleanedSerialNumber);
        }

        return false;
    }
}
