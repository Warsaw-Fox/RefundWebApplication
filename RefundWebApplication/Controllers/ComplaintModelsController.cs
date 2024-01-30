using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefundWebApplication.Data;
using RefundWebApplication.Models.Domain;

namespace TestApp2.Controllers
{
    public class ComplaintModelsController : Controller
    {
        private readonly MainDbContext _context;

        public ComplaintModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: ComplaintModels
        public async Task<IActionResult> ComplaintList()
        {
            return View(await _context.Complaints.ToListAsync());
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

        // GET: ComplaintModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComplaintModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Street,HouseNumber,PostalCode,City,Phone,Email,SerialNumber,PurchaseDate,IssueDescription")] ComplaintModel complaintModel)
        {
            if (ModelState.IsValid)
            {
                complaintModel.Id = Guid.NewGuid();
                _context.Add(complaintModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ComplaintList));
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Street,HouseNumber,PostalCode,City,Phone,Email,SerialNumber,PurchaseDate,IssueDescription")] ComplaintModel complaintModel)
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
                return RedirectToAction(nameof(Index));
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
    }
}
