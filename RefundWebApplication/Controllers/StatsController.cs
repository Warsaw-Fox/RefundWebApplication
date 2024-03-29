﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Stats(string status)
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

            // Tutaj możesz wywołać metodę, która pobiera dane z bazy danych
            var complaints = _context.Complaints.Where(c => c.Status == status).ToList();

            // Przekazanie danych do widoku
            ViewBag.Complaints = complaints;

            return View();
        }
    }
}
