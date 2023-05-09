using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Odonto.Data;
using Odonto.Models;


namespace Odonto.Controllers
{
    public class DateController : Controller
    {
        private readonly DateContext _context;

        public DateController(DateContext context)
        {
            _context = context;
        }

        // GET: Date
        public async Task<IActionResult> Index()
        {
            var dateContext = _context.Date.Include(d => d.Doctor).Include(d => d.Patient);
            return View(await dateContext.ToListAsync());
        }

        // GET: Date/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Date == null)
            {
                return NotFound();
            }

            var date = await _context.Date
                .Include(d => d.Doctor)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // GET: Date/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id");
            return View();
        }

        // POST: Date/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,PatientId,Observation,Id")] Date date)
        {
            if (ModelState.IsValid)
            {
                _context.Add(date);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Id", date.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id", date.PatientId);
            return View(date);
        }

        // GET: Date/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Date == null)
            {
                return NotFound();
            }

            var date = await _context.Date.FindAsync(id);
            if (date == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Id", date.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id", date.PatientId);
            return View(date);
        }

        // POST: Date/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,PatientId,Observation,Id")] Date date)
        {
            if (id != date.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(date);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DateExists(date.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Id", date.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Id", date.PatientId);
            return View(date);
        }

        // GET: Date/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Date == null)
            {
                return NotFound();
            }

            var date = await _context.Date
                .Include(d => d.Doctor)
                .Include(d => d.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // POST: Date/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Date == null)
            {
                return Problem("Entity set 'DateContext.Date'  is null.");
            }
            var date = await _context.Date.FindAsync(id);
            if (date != null)
            {
                _context.Date.Remove(date);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DateExists(int id)
        {
          return (_context.Date?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
