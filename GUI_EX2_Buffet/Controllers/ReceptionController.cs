using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_EX2_Buffet.Data;
using GUI_EX2_Buffet.Data.DBModels;

namespace GUI_EX2_Buffet.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reception
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BreakfastReservations.Include(b => b.CheckInStatuses);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reception/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservations = await _context.BreakfastReservations
                .Include(b => b.CheckInStatuses)
                .FirstOrDefaultAsync(m => m.Room == id);
            if (breakfastReservations == null)
            {
                return NotFound();
            }

            return View(breakfastReservations);
        }

        // GET: Reception/Create
        public IActionResult Create()
        {
            ViewData["Room"] = new SelectList(_context.CheckInStatuses, "Room", "Room");
            return View();
        }

        // POST: Reception/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Room,NumberOfAdults,NumberOfChilds,Date")] BreakfastReservations breakfastReservations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breakfastReservations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Room"] = new SelectList(_context.CheckInStatuses, "Room", "Room", breakfastReservations.Room);
            return View(breakfastReservations);
        }

        // GET: Reception/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservations = await _context.BreakfastReservations.FindAsync(id);
            if (breakfastReservations == null)
            {
                return NotFound();
            }
            ViewData["Room"] = new SelectList(_context.CheckInStatuses, "Room", "Room", breakfastReservations.Room);
            return View(breakfastReservations);
        }

        // POST: Reception/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Room,NumberOfAdults,NumberOfChilds,Date")] BreakfastReservations breakfastReservations)
        {
            if (id != breakfastReservations.Room)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breakfastReservations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakfastReservationsExists(breakfastReservations.Room))
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
            ViewData["Room"] = new SelectList(_context.CheckInStatuses, "Room", "Room", breakfastReservations.Room);
            return View(breakfastReservations);
        }

        // GET: Reception/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservations = await _context.BreakfastReservations
                .Include(b => b.CheckInStatuses)
                .FirstOrDefaultAsync(m => m.Room == id);
            if (breakfastReservations == null)
            {
                return NotFound();
            }

            return View(breakfastReservations);
        }

        // POST: Reception/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breakfastReservations = await _context.BreakfastReservations.FindAsync(id);
            _context.BreakfastReservations.Remove(breakfastReservations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakfastReservationsExists(int id)
        {
            return _context.BreakfastReservations.Any(e => e.Room == id);
        }
    }
}
