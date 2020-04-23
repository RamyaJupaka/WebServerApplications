using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_examABC_Employee.Models;

namespace Final_examABC_Employee.Controllers
{
    public class JobAssignmentsController : Controller
    {
        private readonly ABCEmployeeJobContext _context;

        public JobAssignmentsController(ABCEmployeeJobContext context)
        {
            _context = context;
        }

        // GET: JobAssignments
        public async Task<IActionResult> Index()
        {
            var aBCEmployeeJobContext = _context.JobAssignments.Include(j => j.IdNavigation).Include(j => j.JobCodeNavigation);
            return View(await aBCEmployeeJobContext.ToListAsync());
        }

        // GET: JobAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobAssignments = await _context.JobAssignments
                .Include(j => j.IdNavigation)
                .Include(j => j.JobCodeNavigation)
                .FirstOrDefaultAsync(m => m.JobAssignmentsId == id);
            if (jobAssignments == null)
            {
                return NotFound();
            }

            return View(jobAssignments);
        }

        // GET: JobAssignments/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Employees, "Id", "Email");
            ViewData["JobCode"] = new SelectList(_context.Jobs, "JobCode", "JobCode");
            return View();
        }

        // POST: JobAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobAssignmentsId,JobCode,Id,AssignemtDate")] JobAssignments jobAssignments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobAssignments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Employees, "Id", "Email", jobAssignments.Id);
            ViewData["JobCode"] = new SelectList(_context.Jobs, "JobCode", "JobCode", jobAssignments.JobCode);
            return View(jobAssignments);
        }

        // GET: JobAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobAssignments = await _context.JobAssignments.FindAsync(id);
            if (jobAssignments == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Employees, "Id", "Email", jobAssignments.Id);
            ViewData["JobCode"] = new SelectList(_context.Jobs, "JobCode", "JobCode", jobAssignments.JobCode);
            return View(jobAssignments);
        }

        // POST: JobAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobAssignmentsId,JobCode,Id,AssignemtDate")] JobAssignments jobAssignments)
        {
            if (id != jobAssignments.JobAssignmentsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobAssignments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobAssignmentsExists(jobAssignments.JobAssignmentsId))
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
            ViewData["Id"] = new SelectList(_context.Employees, "Id", "Email", jobAssignments.Id);
            ViewData["JobCode"] = new SelectList(_context.Jobs, "JobCode", "JobCode", jobAssignments.JobCode);
            return View(jobAssignments);
        }

        // GET: JobAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobAssignments = await _context.JobAssignments
                .Include(j => j.IdNavigation)
                .Include(j => j.JobCodeNavigation)
                .FirstOrDefaultAsync(m => m.JobAssignmentsId == id);
            if (jobAssignments == null)
            {
                return NotFound();
            }

            return View(jobAssignments);
        }

        // POST: JobAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobAssignments = await _context.JobAssignments.FindAsync(id);
            _context.JobAssignments.Remove(jobAssignments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobAssignmentsExists(int id)
        {
            return _context.JobAssignments.Any(e => e.JobAssignmentsId == id);
        }
    }
}
