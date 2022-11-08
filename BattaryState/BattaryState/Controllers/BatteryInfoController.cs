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
    public class BatteryInfoController : Controller
    {
        private readonly AppDBContext _context;

        public BatteryInfoController(AppDBContext context)
        {
            _context = context;
        }

        // GET: BatteryInfo
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CapacitySortParm"] = sortOrder == "capacity" ? "capacity_desc" : "capacity";
            ViewData["PartnumberSortParm"] = sortOrder == "partnumber" ? "partnumber_desc" : "partnumber";
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

            var _battary = from b in _context.BatteryInfo select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                _battary = _battary.Where(t => t.name.Contains(searchString)
                                       || t.serial.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    _battary = _battary.OrderByDescending(t => t.name);
                    break;
                case "capacity":
                    _battary = _battary.OrderBy(t => t.capacity);
                    break;
                case "capacityl_desc":
                    _battary = _battary.OrderByDescending(t => t.capacity);
                    break;
                case "partnumber":
                    _battary = _battary.OrderBy(t => t.partnumber);
                    break;
                case "partnumber_desc":
                    _battary = _battary.OrderByDescending(t => t.partnumber);
                    break;
                case "serial":
                    _battary = _battary.OrderBy(t => t.serial);
                    break;
                case "serial_desc":
                    _battary = _battary.OrderByDescending(t => t.serial);
                    break;
                default:
                    _battary = _battary.OrderBy(t => t.name);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<BatteryInfo>.CreateAsync(_battary.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: BatteryInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryInfo = await _context.BatteryInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batteryInfo == null)
            {
                return NotFound();
            }

            return View(batteryInfo);
        }

        // GET: BatteryInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BatteryInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,capacity,name,partnumber,serial")] BatteryInfo batteryInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batteryInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batteryInfo);
        }

        // GET: BatteryInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryInfo = await _context.BatteryInfo.FindAsync(id);
            if (batteryInfo == null)
            {
                return NotFound();
            }
            return View(batteryInfo);
        }

        // POST: BatteryInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,capacity,name,partnumber,serial")] BatteryInfo batteryInfo)
        {
            if (id != batteryInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batteryInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatteryInfoExists(batteryInfo.Id))
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
            return View(batteryInfo);
        }

        // GET: BatteryInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryInfo = await _context.BatteryInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batteryInfo == null)
            {
                return NotFound();
            }

            return View(batteryInfo);
        }

        // POST: BatteryInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batteryInfo = await _context.BatteryInfo.FindAsync(id);
            _context.BatteryInfo.Remove(batteryInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatteryInfoExists(int id)
        {
            return _context.BatteryInfo.Any(e => e.Id == id);
        }



        public async Task<IActionResult> DetailsState(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
            var res = from bi in bmini
                      join ba in bmaxi on bi.terminalInfoId equals ba.terminalInfoId
                      select new { terminalInfoId = bi.terminalInfoId, dBegin = bi.changeTime, dEnd = ba.changeTime };
            */


            //var Bmin = bi.GroupBy(m => m.TerminalInfoId).Select(group => new Bmn {  })

            var batteryInfo = _context.LastBatteryState
                .Include(l => l.batteryInfo).Include(l => l.terminalInfo)
                .Where(m => m.BatteryInfoId == id).OrderBy(m => m.terminalInfo.name).OrderBy(m => m.beginChangeTime);

            if (batteryInfo == null)
            {
                return NotFound();
            }

            ViewBag.akbName = _context.BatteryInfo.Where(m => m.Id == id).First().name ?? "";
            return View(await batteryInfo.ToArrayAsync());

        }
    }
}
