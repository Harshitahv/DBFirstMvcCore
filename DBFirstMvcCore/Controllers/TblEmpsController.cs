using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirstMvcCore.Models;

namespace DBFirstMvcCore.Controllers
{
    public class TblEmpsController : Controller
    {
        private readonly EmployeeDBContext _context;

        public TblEmpsController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: TblEmps
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblEmp.ToListAsync());
        }

        // GET: TblEmps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmp = await _context.TblEmp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblEmp == null)
            {
                return NotFound();
            }

            return View(tblEmp);
        }

        // GET: TblEmps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpName,EmpAddress,ContactNum")] TblEmp tblEmp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEmp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmp);
        }

        // GET: TblEmps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmp = await _context.TblEmp.FindAsync(id);
            if (tblEmp == null)
            {
                return NotFound();
            }
            return View(tblEmp);
        }

        // POST: TblEmps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpName,EmpAddress,ContactNum")] TblEmp tblEmp)
        {
            if (id != tblEmp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmpExists(tblEmp.Id))
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
            return View(tblEmp);
        }

        // GET: TblEmps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmp = await _context.TblEmp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblEmp == null)
            {
                return NotFound();
            }

            return View(tblEmp);
        }

        // POST: TblEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblEmp = await _context.TblEmp.FindAsync(id);
            _context.TblEmp.Remove(tblEmp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpExists(int id)
        {
            return _context.TblEmp.Any(e => e.Id == id);
        }
    }
}
