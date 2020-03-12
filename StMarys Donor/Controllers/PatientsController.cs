using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using St.Marys_Donor.Data;
using St.Marys_Donor.Models;
using St.Marys_Donor.ViewModels;
using Stripe;

namespace St.Marys_Donor.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PatientsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }
        // GET: Patients
        //public IActionResult Index(Patient patient)
        //{
        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var patient1 = _context.Patients.Where(x => x.IdentityUserId == userId).FirstOrDefault();
        //    return View(patient1);
        //}
        public async Task<IActionResult> Index()
        { 
            var applicationDbContext = _context.Patients.Include(p => p.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Patients/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patient = await _context.Patients
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }
        // GET: Patients/Create
        [Authorize(Roles = "Patient")]
        public IActionResult Create()
        {
            var hospitalList = _context.Hospital_Administrators;
            var patient = new PatientViewModel();
            patient.Hospital_Administrators = new List<Hospital_Administrator>();
            foreach (Hospital_Administrator hospital in hospitalList)
            {
                patient.Hospital_Administrators.Add(hospital);
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(patient);
        }
        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Patient patient = new Patient
                {
                    IdentityUserId = userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FirstName + " " + model.LastName,
                    Requirements = model.Requirements,
                    Bio = model.Bio,
                    Hospital_AdministratorId = model.Hospital_AdministratorId,
                    ProfilePicture = uniqueFileName,
                };
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Hospital_AdministratorId"] = new SelectList(_context.Hospital_Administrators, "Id", "HosName", model.Hospital_Administrators.FirstOrDefault().Id);
            return View();
        }
        // GET: Patients/Edit/5
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", patient.IdentityUserId);
            return View(patient);
        }
        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Requirement,Bio,IdentityUserId")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", patient.IdentityUserId);
            return View(patient);
        }
        // GET: Patients/Delete/5
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var patient = await _context.Patients
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }
        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
        private string UploadedFile(PatientViewModel model)
        {
            string uniqueFileName = null;
            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> CreateBlog()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingBlog = _context.BlogPosts.Where(b => b.Patient.IdentityUserId == userId).FirstOrDefault();
            if (existingBlog == null)
            {
                return RedirectToAction("Create", "BlogPosts");
            }
            else
            {
                return RedirectToAction("Index", "BlogPosts");
            }
        }
        public IActionResult Donate()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["pk_test_0xjB7lds8TdnekxeDbgecAVg00Zq0woYF9"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            // further application specific code goes here

            return View();
        }
    }
}
