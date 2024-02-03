using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefundWebApplication.Data;
using RefundWebApplication.Models.Domain;
using System.Net.Mail;
using System.Net;

namespace RefundWebApplication.Controllers
{
    public class ComplaintModelsController : Controller
    {
        private readonly MainDbContext _context;

        public ComplaintModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: ComplaintModels
        public async Task<IActionResult> ComplaintList(string status)
        {
            IQueryable<ComplaintModel> complaintsQuery = _context.Complaints;

            if (!string.IsNullOrEmpty(status))
            {
                complaintsQuery = complaintsQuery.Where(c => c.Status == status);
            }

            var complaints = await complaintsQuery.OrderByDescending(c => c.IssueDate).ToListAsync();
            return View(complaints);
        }

        public async Task<IActionResult> Details(Guid? id, string searchWord)
        {
            // If both id and searchWord are null or empty, display a message or handle the scenario as desired
            if (id == null && string.IsNullOrEmpty(searchWord))
            {
                // For example, you can return a view with a message indicating that no information was provided
                return View("Error");
            }

            ComplaintModel complaintModel;

            if (id != null)
            {
                // Find complaint by id if provided
                complaintModel = await _context.Complaints.FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                // Find complaint by search word if provided
                complaintModel = await _context.Complaints.FirstOrDefaultAsync(m => m.SerialNumber == searchWord);
            }

            if (complaintModel == null)
            {
                // Redirect the user to an error page (ComplaintModels/Error) if no complaint is found
                return View("Error");
            }

            return View(complaintModel);
        }


        // GET: ComplaintModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaintModel = await _context.Complaints.FindAsync(id);
            if (complaintModel == null)
            {
                return NotFound();
            }
            return View(complaintModel);
        }

        // POST: ComplaintModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Street,HouseNumber,PostalCode,City,Phone,Email,SerialNumber,PurchaseDate,IssueDescription,IssueDate,FixDescription,Status")] ComplaintModel complaintModel)
        {
            if (id != complaintModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await SendEmailAsync(complaintModel);
                    _context.Update(complaintModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplaintModelExists(complaintModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ComplaintList));
            }
            return View(complaintModel);
        }

        // GET: ComplaintModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaintModel = await _context.Complaints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complaintModel == null)
            {
                return NotFound();
            }

            return View(complaintModel);
        }

        // POST: ComplaintModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var complaintModel = await _context.Complaints.FindAsync(id);
            if (complaintModel != null)
            {
                _context.Complaints.Remove(complaintModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ComplaintList));
        }

        private bool ComplaintModelExists(Guid id)
        {
            return _context.Complaints.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ShowResultSerialNumber(string SearchWord)
        {
            return View("ComplaintList" ,await _context.Complaints.Where(j => j.SerialNumber.Contains(SearchWord)).ToListAsync());
        }
        private async Task SendEmailAsync(ComplaintModel complaintModel)
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
                mailMessage.To.Add(complaintModel.Email); // Użyj adresu e-mail pobranego z formularza
                mailMessage.Subject = "Zmiana statusu zgłoszenia: " + complaintModel.Id;
                mailMessage.Body = "Reklamacji: " + complaintModel.Id + " zmieniła status. Nowy status rekalmacji to: " + complaintModel.Status;

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
    }
}
