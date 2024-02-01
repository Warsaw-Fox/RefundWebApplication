using Microsoft.AspNetCore.Mvc;
using RefundWebApplication.Data;
using System.Linq;

namespace RefundWebApplication.Controllers
{
    public class StatsController : Controller
    {
        private readonly MainDbContext _context;

        public StatsController(MainDbContext context)
        {
            _context = context;
        }

        public IActionResult stats()
        {
            // Pobierz liczbę reklamacji w różnych statusach
            var newCount = _context.Complaints.Count(c => c.Status == "Nowy");
            var inProgressCount = _context.Complaints.Count(c => c.Status == "W Trakcie");
            var completedCount = _context.Complaints.Count(c => c.Status == "Zakończone");

            // Oblicz liczbę wszystkich reklamacji
            var totalComplaints = newCount + inProgressCount + completedCount;

            // Przekazujemy liczbę reklamacji do widoku
            ViewData["NewCount"] = newCount;
            ViewData["InProgressCount"] = inProgressCount;
            ViewData["CompletedCount"] = completedCount;
            ViewData["TotalComplaints"] = totalComplaints;

            return View();
        }
    }
}
