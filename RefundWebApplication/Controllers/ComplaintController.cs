using Microsoft.AspNetCore.Mvc;
using RefundWebApplication.Data;
using RefundWebApplication.Models.Domain;
using System;
using System.Net.Mail;
using System.Net;
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
                complaint.IssueDate = DateTime.Now;

                // You can add more processing here, such as saving attachments or sending emails.
                await SendEmailAsync(complaint);
                // Add the complaint to the database
                _dbContext.Complaints.Add(complaint);
                await _dbContext.SaveChangesAsync();
                // Redirect to a thank you page or another appropriate action
                return RedirectToAction("ThankYou");
            }

            // If the model is not valid, return to the create view with errors
            return View("Create", complaint);
        }

        private async Task SendEmailAsync(ComplaintModel complaint)
        {
            try
            {
                // Konfiguruj klienta SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("majster@serwismklsolutions.com", "pspw hxhn rirw buum");
                smtpClient.EnableSsl = true;

                // Twórz wiadomość e-mail
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("majster@serwismklsolutions.com");
                mailMessage.To.Add(complaint.Email); // Użyj adresu e-mail pobranego z formularza
                mailMessage.Subject = "Nowe zgłoszenie reklamacyjne";
                mailMessage.Body = "Nowa reklamacja została złożona. Numer reklamacji: " + complaint.Id;

                // Wyślij e-mail
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Obsłuż błąd wysyłania e-maila, na przykład zapisz go do dziennika lub zwróć błąd użytkownikowi
                // Możesz również zaimplementować ponowną próbę wysłania e-maila w przypadku błędu
                Console.WriteLine("Błąd wysyłania e-maila: " + ex.Message);
            }
        }
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
