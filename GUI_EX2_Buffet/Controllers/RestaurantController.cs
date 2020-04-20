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
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckInStatuses.ToListAsync());
        }

        // GET: Restaurant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInStatus = await _context.CheckInStatuses
                .FirstOrDefaultAsync(m => m.Room == id);
            if (checkInStatus == null)
            {
                return NotFound();
            }

            return View(checkInStatus);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumberOfAdultsCheckedIn,NumberOfChildsCheckedIn,Room")] CheckInStatus checkInStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkInStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkInStatus);
        }

        // GET: Restaurant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInStatus = await _context.CheckInStatuses.FindAsync(id);
            if (checkInStatus == null)
            {
                return NotFound();
            }
            return View(checkInStatus);
        }

        // POST: Restaurant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumberOfAdultsCheckedIn,NumberOfChildsCheckedIn,Room")] CheckInStatus checkInStatus)
        {
            if (id != checkInStatus.Room)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkInStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckInStatusExists(checkInStatus.Room))
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
            return View(checkInStatus);
        }

        // GET: Restaurant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInStatus = await _context.CheckInStatuses
                .FirstOrDefaultAsync(m => m.Room == id);
            if (checkInStatus == null)
            {
                return NotFound();
            }

            return View(checkInStatus);
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkInStatus = await _context.CheckInStatuses.FindAsync(id);
            _context.CheckInStatuses.Remove(checkInStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckInStatusExists(int id)
        {
            return _context.CheckInStatuses.Any(e => e.Room == id);
        }
    }
}
