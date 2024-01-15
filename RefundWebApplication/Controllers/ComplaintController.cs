using Microsoft.AspNetCore.Mvc;
using RefundWebApplication.Data;
using RefundWebApplication.Models.Domain;
using System;
using System.Threading.Tasks;

namespace RefundWebApplication.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly MainDbContext _dbContext;

        public ComplaintController(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitComplaint(ComplaintModel complaint)
        {
            if (ModelState.IsValid)
            {
                // Generate a new unique ID for the complaint
                complaint.Id = Guid.NewGuid();

                // You can add more processing here, such as saving attachments or sending emails.

                // Add the complaint to the database
                _dbContext.Complaints.Add(complaint);
                await _dbContext.SaveChangesAsync();

                // Redirect to a thank you page or another appropriate action
                return RedirectToAction("ThankYou");
            }

            // If the model is not valid, return to the create view with errors
            return View("Create", complaint);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
