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
    public class ModelTSDController : Controller
    {
        private readonly AppDBContext _context;

        public ModelTSDController(AppDBContext context)
        {
            _context = context;
        }

        // GET: ModelTSD
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelTSD.ToListAsync());
        }

        // GET: ModelTSD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelTSD = await _context.ModelTSD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelTSD == null)
            {
                return NotFound();
            }

            return View(modelTSD);
        }

        // GET: ModelTSD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelTSD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,modName")] ModelTSD modelTSD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelTSD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelTSD);
        }

        // GET: ModelTSD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelTSD = await _context.ModelTSD.FindAsync(id);
            if (modelTSD == null)
            {
                return NotFound();
            }
            return View(modelTSD);
        }

        // POST: ModelTSD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,modName")] ModelTSD modelTSD)
        {
            if (id != modelTSD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelTSD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelTSDExists(modelTSD.Id))
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
            return View(modelTSD);
        }

        // GET: ModelTSD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelTSD = await _context.ModelTSD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelTSD == null)
            {
                return NotFound();
            }

            return View(modelTSD);
        }

        // POST: ModelTSD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelTSD = await _context.ModelTSD.FindAsync(id);
            _context.ModelTSD.Remove(modelTSD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelTSDExists(int id)
        {
            return _context.ModelTSD.Any(e => e.Id == id);
        }
    }
}
