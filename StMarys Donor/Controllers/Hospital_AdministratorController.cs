﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [Authorize(Roles = "Hospital Administrator")]
    public class Hospital_AdministratorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DonorAPIClient _client;
        public Hospital_AdministratorController(ApplicationDbContext context, DonorAPIClient client)
        {
            _context = context;
            _client = client;
        }

        // GET: Hospital_Administrator
       [HttpGet]
       public async Task<IActionResult> Index()
        {
            List<Donor> donors = new List<Donor>();
            var listofDonors = await _client.Client.GetAsync("/api/donor");
            listofDonors.EnsureSuccessStatusCode();
            var responseStream = await listofDonors.Content.ReadAsStringAsync();
            donors = JsonConvert.DeserializeObject<List<Donor>>(responseStream);
            return Ok(donors);
        }

        // GET: Hospital_Administrator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital_Administrator = await _context.Hospital_Administrators
                .Include(h => h.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospital_Administrator == null)
            {
                return NotFound();
            }

            return View(hospital_Administrator);
        }

        // GET: Hospital_Administrator/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Hospital_Administrator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HosName,IdentityUserID")] Hospital_Administrator hospital_Administrator)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                hospital_Administrator.IdentityUserID = userId;
                _context.Add(hospital_Administrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", hospital_Administrator.IdentityUserID);
            return View(hospital_Administrator);
        }

        // GET: Hospital_Administrator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital_Administrator = await _context.Hospital_Administrators.FindAsync(id);
            if (hospital_Administrator == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", hospital_Administrator.IdentityUserID);
            return View(hospital_Administrator);
        }

        // POST: Hospital_Administrator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HosName,IdentityUserID")] Hospital_Administrator hospital_Administrator)
        {
            if (id != hospital_Administrator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospital_Administrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Hospital_AdministratorExists(hospital_Administrator.Id))
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
            ViewData["IdentityUserID"] = new SelectList(_context.Users, "Id", "Id", hospital_Administrator.IdentityUserID);
            return View(hospital_Administrator);
        }

        // GET: Hospital_Administrator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital_Administrator = await _context.Hospital_Administrators
                .Include(h => h.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hospital_Administrator == null)
            {
                return NotFound();
            }

            return View(hospital_Administrator);
        }

        // POST: Hospital_Administrator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospital_Administrator = await _context.Hospital_Administrators.FindAsync(id);
            _context.Hospital_Administrators.Remove(hospital_Administrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Hospital_AdministratorExists(int id)
        {
            return _context.Hospital_Administrators.Any(e => e.Id == id);
        }
    }
}
