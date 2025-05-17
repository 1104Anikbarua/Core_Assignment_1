using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Assignment_1.DBContext;
using Core_Assignment_1.Models;

namespace Core_Assignment_1.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AppDBContext _context;

        public RegistrationController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Registration
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registrations.ToListAsync());
        }

        // GET: Registration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationClass = await _context.Registrations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registrationClass == null)
            {
                return NotFound();
            }

            return View(registrationClass);
        }

        // GET: Registration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,Password")] RegistrationClass registrationClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrationClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrationClass);
        }

        // GET: Registration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationClass = await _context.Registrations.FindAsync(id);
            if (registrationClass == null)
            {
                return NotFound();
            }
            return View(registrationClass);
        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,Password")] RegistrationClass registrationClass)
        {
            if (id != registrationClass.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationClassExists(registrationClass.ID))
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
            return View(registrationClass);
        }

        // GET: Registration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationClass = await _context.Registrations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registrationClass == null)
            {
                return NotFound();
            }

            return View(registrationClass);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationClass = await _context.Registrations.FindAsync(id);
            if (registrationClass != null)
            {
                _context.Registrations.Remove(registrationClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationClassExists(int id)
        {
            return _context.Registrations.Any(e => e.ID == id);
        }
    }
}
