using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Livrini.Models;

namespace Livrini.Controllers
{
    public class LigneOrderController : Controller
    {
        private readonly LivriniDbContext _context;

        public LigneOrderController(LivriniDbContext context)
        {
            _context = context;
        }

        // GET: LigneOrder
        public async Task<IActionResult> Index()
        {
            var livriniDbContext = _context.LigneOrder.Include(l => l.Dish).Include(l => l.Order);
            return View(await livriniDbContext.ToListAsync());
        }

        // GET: LigneOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LigneOrder == null)
            {
                return NotFound();
            }

            var ligneOrder = await _context.LigneOrder
                .Include(l => l.Dish)
                .Include(l => l.Order)
                .FirstOrDefaultAsync(m => m.IdLigneOrder == id);
            if (ligneOrder == null)
            {
                return NotFound();
            }

            return View(ligneOrder);
        }

        // GET: LigneOrder/Create
        public IActionResult Create()
        {
            ViewData["IdDish"] = new SelectList(_context.Dish, "IdDish", "IdDish");
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder");
            return View();
        }

        // POST: LigneOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLigneOrder,Quantity,IdDish,IdOrder")] LigneOrder ligneOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ligneOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDish"] = new SelectList(_context.Dish, "IdDish", "IdDish", ligneOrder.IdDish);
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", ligneOrder.IdOrder);
            return View(ligneOrder);
        }

        // GET: LigneOrder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LigneOrder == null)
            {
                return NotFound();
            }

            var ligneOrder = await _context.LigneOrder.FindAsync(id);
            if (ligneOrder == null)
            {
                return NotFound();
            }
            ViewData["IdDish"] = new SelectList(_context.Dish, "IdDish", "IdDish", ligneOrder.IdDish);
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", ligneOrder.IdOrder);
            return View(ligneOrder);
        }

        // POST: LigneOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLigneOrder,Quantity,IdDish,IdOrder")] LigneOrder ligneOrder)
        {
            if (id != ligneOrder.IdLigneOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ligneOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LigneOrderExists(ligneOrder.IdLigneOrder))
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
            ViewData["IdDish"] = new SelectList(_context.Dish, "IdDish", "IdDish", ligneOrder.IdDish);
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", ligneOrder.IdOrder);
            return View(ligneOrder);
        }

        // GET: LigneOrder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LigneOrder == null)
            {
                return NotFound();
            }

            var ligneOrder = await _context.LigneOrder
                .Include(l => l.Dish)
                .Include(l => l.Order)
                .FirstOrDefaultAsync(m => m.IdLigneOrder == id);
            if (ligneOrder == null)
            {
                return NotFound();
            }

            return View(ligneOrder);
        }

        // POST: LigneOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LigneOrder == null)
            {
                return Problem("Entity set 'LivriniDbContext.LigneOrder'  is null.");
            }
            var ligneOrder = await _context.LigneOrder.FindAsync(id);
            if (ligneOrder != null)
            {
                _context.LigneOrder.Remove(ligneOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LigneOrderExists(int id)
        {
          return (_context.LigneOrder?.Any(e => e.IdLigneOrder == id)).GetValueOrDefault();
        }
    }
}
