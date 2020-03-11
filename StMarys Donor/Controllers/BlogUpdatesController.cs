using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using St.Marys_Donor.Data;
using St.Marys_Donor.Models;

namespace StMarys_Donor.Controllers
{
    public class BlogUpdatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogUpdatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlogUpdates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BlogUpdates.Include(b => b.BlogPost);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BlogUpdates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogUpdate = await _context.BlogUpdates
                .Include(b => b.BlogPost)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogUpdate == null)
            {
                return NotFound();
            }

            return View(blogUpdate);
        }

        // GET: BlogUpdates/Create
        public IActionResult Create()
        {
            ViewData["BlogPostId"] = new SelectList(_context.BlogPosts, "Id", "Id");
            return View();
        }

        // POST: BlogUpdates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Body,Time,BlogPostId")] BlogUpdate blogUpdate)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var blog = _context.BlogPosts.Where(b => b.Patient.IdentityUserId == userId).FirstOrDefault();
                blogUpdate.Time = DateTime.Now;
                _context.Add(blogUpdate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogPostId"] = new SelectList(_context.BlogPosts, "Id", "Id", blogUpdate.BlogPostId);
            return View(blogUpdate);
        }

        // GET: BlogUpdates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogUpdate = await _context.BlogUpdates.FindAsync(id);
            if (blogUpdate == null)
            {
                return NotFound();
            }
            ViewData["BlogPostId"] = new SelectList(_context.BlogPosts, "Id", "Id", blogUpdate.BlogPostId);
            return View(blogUpdate);
        }

        // POST: BlogUpdates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Body,Time,BlogPostId")] BlogUpdate blogUpdate)
        {
            if (id != blogUpdate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogUpdateExists(blogUpdate.Id))
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
            ViewData["BlogPostId"] = new SelectList(_context.BlogPosts, "Id", "Id", blogUpdate.BlogPostId);
            return View(blogUpdate);
        }

        // GET: BlogUpdates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogUpdate = await _context.BlogUpdates
                .Include(b => b.BlogPost)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogUpdate == null)
            {
                return NotFound();
            }

            return View(blogUpdate);
        }

        // POST: BlogUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogUpdate = await _context.BlogUpdates.FindAsync(id);
            _context.BlogUpdates.Remove(blogUpdate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogUpdateExists(int id)
        {
            return _context.BlogUpdates.Any(e => e.Id == id);
        }
        
    }
}
