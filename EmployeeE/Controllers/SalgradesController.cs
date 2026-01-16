using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeE.Data;
using EmployeeE.Models;

namespace EmployeeE.Controllers
{
    public class SalgradesController : Controller
    {
        private readonly AppDbContext _context;

        public SalgradesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Salgrades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salgrades.ToListAsync());
        }

        // GET: Salgrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salgrade = await _context.Salgrades
                .FirstOrDefaultAsync(m => m.Grade == id);
            if (salgrade == null)
            {
                return NotFound();
            }

            return View(salgrade);
        }

        // GET: Salgrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salgrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Grade,Losal,Hisal")] Salgrade salgrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salgrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salgrade);
        }

        // GET: Salgrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salgrade = await _context.Salgrades.FindAsync(id);
            if (salgrade == null)
            {
                return NotFound();
            }
            return View(salgrade);
        }

        // POST: Salgrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Grade,Losal,Hisal")] Salgrade salgrade)
        {
            if (id != salgrade.Grade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salgrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalgradeExists(salgrade.Grade))
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
            return View(salgrade);
        }

        // GET: Salgrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salgrade = await _context.Salgrades
                .FirstOrDefaultAsync(m => m.Grade == id);
            if (salgrade == null)
            {
                return NotFound();
            }

            return View(salgrade);
        }

        // POST: Salgrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salgrade = await _context.Salgrades.FindAsync(id);
            if (salgrade != null)
            {
                _context.Salgrades.Remove(salgrade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalgradeExists(int id)
        {
            return _context.Salgrades.Any(e => e.Grade == id);
        }
    }
}
