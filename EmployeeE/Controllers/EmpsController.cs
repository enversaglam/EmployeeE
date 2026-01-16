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
    public class EmpsController : Controller
    {
        private readonly AppDbContext _context;

        public EmpsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Emps
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Emps.Include(e => e.DeptnoNavigation).Include(e => e.MgrNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Emps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps
                .Include(e => e.DeptnoNavigation)
                .Include(e => e.MgrNavigation)
                .FirstOrDefaultAsync(m => m.Empno == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // GET: Emps/Create
        public IActionResult Create()
        {
            ViewData["Deptno"] = new SelectList(_context.Depts, "Deptno", "Deptno");
            ViewData["Mgr"] = new SelectList(_context.Emps, "Empno", "Empno");
            return View();
        }

        // POST: Emps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empno,Ename,Job,Mgr,Hiredate,Sal,Comm,Deptno")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Deptno"] = new SelectList(_context.Depts, "Deptno", "Deptno", emp.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Emps, "Empno", "Empno", emp.Mgr);
            return View(emp);
        }

        // GET: Emps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            ViewData["Deptno"] = new SelectList(_context.Depts, "Deptno", "Deptno", emp.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Emps, "Empno", "Empno", emp.Mgr);
            return View(emp);
        }

        // POST: Emps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empno,Ename,Job,Mgr,Hiredate,Sal,Comm,Deptno")] Emp emp)
        {
            if (id != emp.Empno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpExists(emp.Empno))
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
            ViewData["Deptno"] = new SelectList(_context.Depts, "Deptno", "Deptno", emp.Deptno);
            ViewData["Mgr"] = new SelectList(_context.Emps, "Empno", "Empno", emp.Mgr);

            //ViewBag.DeptList = _context.Depts.ToList();

            return View(emp);
        }

        // GET: Emps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.Emps
                .Include(e => e.DeptnoNavigation)
                .Include(e => e.MgrNavigation)
                .FirstOrDefaultAsync(m => m.Empno == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST: Emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _context.Emps.FindAsync(id);
            if (emp != null)
            {
                _context.Emps.Remove(emp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpExists(int id)
        {
            return _context.Emps.Any(e => e.Empno == id);
        }
    }
}
