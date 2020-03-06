using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using St.Marys_Donor.Data;
using St.Marys_Donor.Models;

namespace St.Marys_Donor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var AdminInfo = _context.Administrators.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                if (AdminInfo == null)
                {
                    return RedirectToAction("Create", "Administrators");
                }
                else
                {
                    return RedirectToAction("Index", "Administrators");
                }
            }


            else if (User.IsInRole("Donor"))
            {
                if (User.IsInRole("Donor"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var DonorInfo = _context.Donors.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                    if (DonorInfo == null)
                    {
                        return RedirectToAction("Create", "Donors");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Donors");
                    }
                }
                else
                {
                    return View();
                }
            }
            else if (User.IsInRole("Patient"))
            {
                if (User.IsInRole("Patient"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var DonorInfo = _context.Donors.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                    if (DonorInfo == null)
                    {
                        return RedirectToAction("Create", "Patients");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Patients");
                    }
                }
                else
                {
                    return View();
                }
            }
            else if (User.IsInRole("Hospital Administrator"))
            {
                if (User.IsInRole("Hospital Administrator"))
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var DonorInfo = _context.Donors.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                    if (DonorInfo == null)
                    {
                        return RedirectToAction("Create", "Hospital_Administrator");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Hospital_Administrator");
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
