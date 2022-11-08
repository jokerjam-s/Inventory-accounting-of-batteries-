using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BattaryState.Models;

namespace BattaryState.Controllers
{
    public class SkladController : Controller
    {
        private readonly AppDBContext _context;

        public SkladController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Sklad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sklad.ToListAsync());
        }

        // GET: Sklad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sklad = await _context.Sklad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sklad == null)
            {
                return NotFound();
            }

            return View(sklad);
        }

        // GET: Sklad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sklad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,sklName")] Sklad sklad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sklad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sklad);
        }

        // GET: Sklad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sklad = await _context.Sklad.FindAsync(id);
            if (sklad == null)
            {
                return NotFound();
            }
            return View(sklad);
        }

        // POST: Sklad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,sklName")] Sklad sklad)
        {
            if (id != sklad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sklad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkladExists(sklad.Id))
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
            return View(sklad);
        }

        // GET: Sklad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sklad = await _context.Sklad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sklad == null)
            {
                return NotFound();
            }

            return View(sklad);
        }

        // POST: Sklad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sklad = await _context.Sklad.FindAsync(id);
            _context.Sklad.Remove(sklad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkladExists(int id)
        {
            return _context.Sklad.Any(e => e.Id == id);
        }
    }
}
