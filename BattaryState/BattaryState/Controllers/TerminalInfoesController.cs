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
    public class TerminalInfoesController : Controller
    {
        private readonly AppDBContext _context;

        public TerminalInfoesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: TerminalInfoes
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SerialSortParm"] = sortOrder == "serial" ? "serial_desc" : "serial";

            ViewData["CurrentSort"] = sortOrder;
            ViewBag.sortOrder = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var _terminal = from t in _context.TerminalInfo select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                _terminal = _terminal.Where(t => t.name.Contains(searchString)
                                       || t.serial.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    _terminal = _terminal.OrderByDescending(t => t.name);
                    break;
                case "serial":
                    _terminal = _terminal.OrderBy(t => t.serial);
                    break;
                case "serial_desc":
                    _terminal = _terminal.OrderByDescending(t => t.serial);
                    break;

                default:
                    _terminal = _terminal.OrderBy(t => t.name);
                    break;
            }

            _terminal = _terminal.Include(t => t.sklad).Include(t => t.opsystem).Include(t =>t.modelTSD);

            int pageSize = 15;
            return View(await PaginatedList<TerminalInfo>.CreateAsync(_terminal.AsNoTracking(), pageNumber ?? 1, pageSize));

            //var appDBContext = _context.TerminalInfo.Include(t => t.opsystem).Include(t => t.sklad);
            //return View(await appDBContext.ToListAsync());
        }

        // GET: TerminalInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminalInfo = await _context.TerminalInfo
                .Include(t => t.opsystem)
                .Include(t => t.sklad)
                .Include(t => t.modelTSD)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terminalInfo == null)
            {
                return NotFound();
            }

            return View(terminalInfo);
        }

        // GET: TerminalInfoes/Create
        public IActionResult Create()
        {
            ViewData["OpSystemId"] = new SelectList(_context.OpSystem, "Id", "osName");
            ViewData["SkladId"] = new SelectList(_context.Sklad, "Id", "sklName");
            ViewData["ModelTSDId"] = new SelectList(_context.ModelTSD, "Id", "modName");
            return View();
        }

        // POST: TerminalInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,serial,ModelTSDId,prodYear,garantSrok,otvetstv,macadr,isDamage,dateDamage,dismNotes,isReserv,isRemont,remNotes,SkladId,OpSystemId")] TerminalInfo terminalInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terminalInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OpSystemId"] = new SelectList(_context.OpSystem, "Id", "osName", terminalInfo.OpSystemId);
            ViewData["SkladId"] = new SelectList(_context.Sklad, "Id", "sklName", terminalInfo.SkladId);
            ViewData["ModelTSDId"] = new SelectList(_context.ModelTSD, "Id", "modName", terminalInfo.ModelTSDId);
            return View(terminalInfo);
        }

        // GET: TerminalInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminalInfo = await _context.TerminalInfo.FindAsync(id);
            if (terminalInfo == null)
            {
                return NotFound();
            }
            ViewData["OpSystemId"] = new SelectList(_context.OpSystem, "Id", "osName", terminalInfo.OpSystemId);
            ViewData["SkladId"] = new SelectList(_context.Sklad, "Id", "sklName", terminalInfo.SkladId);
            ViewData["ModelTSDId"] = new SelectList(_context.ModelTSD, "Id", "modName", terminalInfo.ModelTSDId);
            return View(terminalInfo);
        }

        // POST: TerminalInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,serial,ModelTSDId,prodYear,garantSrok,otvetstv,macadr,isDamage,dateDamage,dismNotes,isReserv,isRemont,remNotes,SkladId,OpSystemId")] TerminalInfo terminalInfo)
        {
            if (id != terminalInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terminalInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminalInfoExists(terminalInfo.Id))
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
            ViewData["OpSystemId"] = new SelectList(_context.OpSystem, "Id", "osName", terminalInfo.OpSystemId);
            ViewData["SkladId"] = new SelectList(_context.Sklad, "Id", "sklName", terminalInfo.SkladId);
            ViewData["ModelTSDId"] = new SelectList(_context.ModelTSD, "Id", "modName", terminalInfo.ModelTSDId);
            return View(terminalInfo);
        }

        // GET: TerminalInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminalInfo = await _context.TerminalInfo
                .Include(t => t.opsystem)
                .Include(t => t.sklad)
                .Include(t => t.modelTSD)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (terminalInfo == null)
            {
                return NotFound();
            }

            return View(terminalInfo);
        }

        // POST: TerminalInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var terminalInfo = await _context.TerminalInfo.FindAsync(id);
            _context.TerminalInfo.Remove(terminalInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerminalInfoExists(int id)
        {
            return _context.TerminalInfo.Any(e => e.Id == id);
        }
    }
}
