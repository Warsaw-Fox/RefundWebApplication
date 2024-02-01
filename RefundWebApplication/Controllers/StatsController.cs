using Microsoft.AspNetCore.Mvc;

namespace RefundWebApplication.Controllers
{
    public class StatsController : Controller
    {
        private static int inProgressCount = 0;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateStatistics(string status)
        {
            if (status == "W Trakcie")
            {
                inProgressCount++;
            }

            // Przekierowanie na stronę z wynikami
            return RedirectToAction("ShowStatistics");
        }

        public IActionResult ShowStatistics()
        {
            ViewData["InProgressCount"] = inProgressCount;
            return View();
        }
    }
}
