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
    public class OpSystemController : Controller
    {
        private readonly AppDBContext _context;

        public OpSystemController(AppDBContext context)
        {
            _context = context;
        }

        // GET: OpSystem
        public async Task<IActionResult> Index()
        {
            return View(await _context.OpSystem.ToListAsync());
        }

        // GET: OpSystem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opSystem = await _context.OpSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opSystem == null)
            {
                return NotFound();
            }

            return View(opSystem);
        }

        // GET: OpSystem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpSystem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,osName")] OpSystem opSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opSystem);
        }

        // GET: OpSystem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opSystem = await _context.OpSystem.FindAsync(id);
            if (opSystem == null)
            {
                return NotFound();
            }
            return View(opSystem);
        }

        // POST: OpSystem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,osName")] OpSystem opSystem)
        {
            if (id != opSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpSystemExists(opSystem.Id))
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
            return View(opSystem);
        }

        // GET: OpSystem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opSystem = await _context.OpSystem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opSystem == null)
            {
                return NotFound();
            }

            return View(opSystem);
        }

        // POST: OpSystem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opSystem = await _context.OpSystem.FindAsync(id);
            _context.OpSystem.Remove(opSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpSystemExists(int id)
        {
            return _context.OpSystem.Any(e => e.Id == id);
        }
    }
}
