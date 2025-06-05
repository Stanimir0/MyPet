using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPet.Data;
using MyPet.Models;

namespace MyPet.Controllers
{
    public class DogAgesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogAgesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DogAges
        public async Task<IActionResult> Index()
        {
            return View(await _context.DogAge.ToListAsync());
        }

        // GET: DogAges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogAge = await _context.DogAge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogAge == null)
            {
                return NotFound();
            }

            return View(dogAge);
        }

        // GET: DogAges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogAges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Age")] DogAge dogAge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogAge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogAge);
        }

        // GET: DogAges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogAge = await _context.DogAge.FindAsync(id);
            if (dogAge == null)
            {
                return NotFound();
            }
            return View(dogAge);
        }

        // POST: DogAges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Age")] DogAge dogAge)
        {
            if (id != dogAge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogAge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogAgeExists(dogAge.Id))
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
            return View(dogAge);
        }

        // GET: DogAges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogAge = await _context.DogAge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogAge == null)
            {
                return NotFound();
            }

            return View(dogAge);
        }

        // POST: DogAges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogAge = await _context.DogAge.FindAsync(id);
            if (dogAge != null)
            {
                _context.DogAge.Remove(dogAge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogAgeExists(int id)
        {
            return _context.DogAge.Any(e => e.Id == id);
        }
    }
}
