using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vendas.Data;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class Department1Controller : Controller
    {
        private readonly VendasContext _context;

        public Department1Controller(VendasContext context)
        {
            _context = context;
        }

        // GET: Department1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Department1.ToListAsync());
        }

        // GET: Department1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department1 = await _context.Department1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department1 == null)
            {
                return NotFound();
            }

            return View(department1);
        }

        // GET: Department1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department1 department1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department1);
        }

        // GET: Department1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department1 = await _context.Department1.FindAsync(id);
            if (department1 == null)
            {
                return NotFound();
            }
            return View(department1);
        }

        // POST: Department1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department1 department1)
        {
            if (id != department1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Department1Exists(department1.Id))
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
            return View(department1);
        }

        // GET: Department1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department1 = await _context.Department1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department1 == null)
            {
                return NotFound();
            }

            return View(department1);
        }

        // POST: Department1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department1 = await _context.Department1.FindAsync(id);
            _context.Department1.Remove(department1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Department1Exists(int id)
        {
            return _context.Department1.Any(e => e.Id == id);
        }
    }
}
