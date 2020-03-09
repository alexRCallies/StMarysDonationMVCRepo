using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using St.Marys_Donor.Data;
using St.Marys_Donor.Models;
using StMarys_Donor;

namespace St.Marys_Donor.Controllers
{
    [Authorize(Roles = "Donor")]
    public class DonorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DonorAPIClient _client;

        public DonorsController(ApplicationDbContext context, DonorAPIClient client)
        {
            _context = context;
            _client = client;
        }

        // GET: Donors
        public async Task<IActionResult> Index(Donor donor)
        {
            var donors = donor;
            return View(donors);
        }

        // GET: Donors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .Include(d => d.Address)
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // GET: Donors/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,IdentityUserId")] Donor donor)
        {
            // make isActive = true
            // firstName and lastName are only values passed from create view
            donor.isActive = true;
            donor.AddressId = null;
            donor.FirstName = donor.FirstName.ToLower();
            donor.LastName = donor.LastName.ToLower();
            Donor newDonor = new Donor();
            StringContent content = new StringContent(JsonConvert.SerializeObject(donor), Encoding.UTF8, "application/json");

            using (var response = await _client.Client.PostAsync("/api/donor",content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    newDonor = JsonConvert.DeserializeObject<Donor>(apiResponse);
                }
            return RedirectToAction("Index","Donors",newDonor);
        }

        // GET: Donors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", donor.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", donor.IdentityUserId);
            return View(donor);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,isActive,IdentityUserId,AddressId")] Donor donor)
        {
            if (id != donor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(donor.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", donor.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", donor.IdentityUserId);
            return View(donor);
        }

        // GET: Donors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .Include(d => d.Address)
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorExists(int id)
        {
            return _context.Donors.Any(e => e.Id == id);
        }
    }
}
