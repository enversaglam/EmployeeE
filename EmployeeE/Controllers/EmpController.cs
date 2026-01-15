using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeE.Data;
using EmployeeE.Models;

namespace EmployeeE.Controllers
{
    public class EmpController : Controller
    {
        private readonly AppDbContext _context;

        public EmpController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Emp/Index
        public async Task<IActionResult> Index()
        {
            var emps = _context.Emps.Include(e => e.DeptnoNavigation);
            return View(await emps.ToListAsync());
        }

        // GET: Emp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _context.Emps
                .Include(e => e.DeptnoNavigation)
                .FirstOrDefaultAsync(m => m.Empno == id);
            return emp == null ? NotFound() : View(emp);
        }

        // GET: Emp/Create
        public IActionResult Create()
        {
            ViewBag.DeptList = _context.Depts.ToList();
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ename,Job,Mgr,Hiredate,Sal,Comm,Deptno")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                _context.Emps.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DeptList = _context.Depts.ToList();
            return View(emp);
        }

        // GET: Emp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _context.Emps.FindAsync(id);
            if (emp == null) return NotFound();
            ViewBag.DeptList = _context.Depts.ToList();
            return View(emp);
        }

        // POST: Emp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empno,Ename,Job,Mgr,Hiredate,Sal,Comm,Deptno")] Emp emp)
        {
            if (id != emp.Empno) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DeptList = _context.Depts.ToList();
            return View(emp);
        }

        // GET: Emp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var emp = await _context.Emps
                .Include(e => e.DeptnoNavigation)
                .FirstOrDefaultAsync(m => m.Empno == id);
            return emp == null ? NotFound() : View(emp);
        }

        // POST: Emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _context.Emps.FindAsync(id);
            _context.Emps.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
