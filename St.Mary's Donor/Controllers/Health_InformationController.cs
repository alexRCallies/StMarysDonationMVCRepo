using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using St.Marys_Donor.Data;
using St.Marys_Donor.Models;

namespace St.Marys_Donor.Controllers
{
    public class Health_InformationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Health_InformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Health_Information
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Health_Information.Include(h => h.Donor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Health_Information/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var health_Information = await _context.Health_Information
                .Include(h => h.Donor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (health_Information == null)
            {
                return NotFound();
            }

            return View(health_Information);
        }

        // GET: Health_Information/Create
        public IActionResult Create()
        {
            ViewData["DonorId"] = new SelectList(_context.Donors, "Id", "Id");
            return View();
        }

        // POST: Health_Information/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DonorId,BloodType,OnMedication,Height,Weight,IsMale,Ethnicity")] Health_Information health_Information)
        {
            if (ModelState.IsValid)
            {
                _context.Add(health_Information);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonorId"] = new SelectList(_context.Donors, "Id", "Id", health_Information.DonorId);
            return View(health_Information);
        }

        // GET: Health_Information/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var health_Information = await _context.Health_Information.FindAsync(id);
            if (health_Information == null)
            {
                return NotFound();
            }
            ViewData["DonorId"] = new SelectList(_context.Donors, "Id", "Id", health_Information.DonorId);
            return View(health_Information);
        }

        // POST: Health_Information/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DonorId,BloodType,OnMedication,Height,Weight,IsMale,Ethnicity")] Health_Information health_Information)
        {
            if (id != health_Information.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(health_Information);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Health_InformationExists(health_Information.Id))
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
            ViewData["DonorId"] = new SelectList(_context.Donors, "Id", "Id", health_Information.DonorId);
            return View(health_Information);
        }

        // GET: Health_Information/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var health_Information = await _context.Health_Information
                .Include(h => h.Donor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (health_Information == null)
            {
                return NotFound();
            }

            return View(health_Information);
        }

        // POST: Health_Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var health_Information = await _context.Health_Information.FindAsync(id);
            _context.Health_Information.Remove(health_Information);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Health_InformationExists(int id)
        {
            return _context.Health_Information.Any(e => e.Id == id);
        }
    }
}
