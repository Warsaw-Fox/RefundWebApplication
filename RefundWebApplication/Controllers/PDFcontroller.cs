using Microsoft.AspNetCore.Mvc;

namespace RefundWebApplication.Controllers
{
    public class PDFController : Controller
    {
        public IActionResult pdf()
        {
            return View(); // Zwróć widok
        }
    }
}
