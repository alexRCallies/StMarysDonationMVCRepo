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
        public async Task<IActionResult> Index()
        {
            var listPatients = _context.Patients.Include(p => p.IdentityUser);
            return View(await listPatients.ToListAsync());
        }

        // GET: Donors/Details/5
        public async Task<IActionResult> Details(Donor donor)
        {
            if (donor.IdentityUserId == null)
            {
                return NotFound();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Donor> donorsAPI = new List<Donor>();
            using (var response = await _client.Client.GetAsync("/api/donor/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                donorsAPI = JsonConvert.DeserializeObject<List<Donor>>(apiResponse);
            }
            var donorLoggedIn = donorsAPI.Find(d => d.IdentityUserId == userId);
            return View(donorLoggedIn);
        }

        // GET: Donors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,IdentityUserId")] Donor donor)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            donor.FirstName = donor.FirstName.ToLower();
            donor.LastName = donor.LastName.ToLower();
            donor.IdentityUserId = userId;
            Donor newDonor = new Donor();
            StringContent content = new StringContent(JsonConvert.SerializeObject(donor), Encoding.UTF8, "application/json");

            using (var response = await _client.Client.PostAsync("/api/donor",content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    newDonor = JsonConvert.DeserializeObject<Donor>(apiResponse);
                }
            return RedirectToAction("Index","Donors");
        }

        // GET: Donors/Edit/5
        public async Task<IActionResult> Edit()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Donor> donorsAPI = new List<Donor>();
            using (var response = await _client.Client.GetAsync("/api/donor/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                donorsAPI = JsonConvert.DeserializeObject<List<Donor>>(apiResponse);
            }
            var donorLoggedIn = donorsAPI.Find(d => d.IdentityUserId == userId);
            return View(donorLoggedIn);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Donor donor)
        {

            if (ModelState.IsValid)
            {
                Donor donorLoggedIn = donor;
                StringContent content = new StringContent(JsonConvert.SerializeObject(donor), Encoding.UTF8, "application/json");

                using (var response = await _client.Client.PutAsync("/api/donor", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    donorLoggedIn = JsonConvert.DeserializeObject<Donor>(apiResponse);
                }
            }
            return RedirectToAction("Index", "Donors");
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

            return RedirectToAction("Index","Donors");
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
