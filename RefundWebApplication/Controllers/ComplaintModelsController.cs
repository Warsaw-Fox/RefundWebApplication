using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefundWebApplication.Data;
using RefundWebApplication.Models.Domain;

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

        // GET: ComplaintModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
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
    }
}
