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
    public class RestaurantController : Controller
    {
        private readonly LivriniDbContext _context;

        public RestaurantController(LivriniDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        public async Task<IActionResult> Index()
        {
              return _context.Restaurent != null ? 
                          View(await _context.Restaurent.ToListAsync()) :
                          Problem("Entity set 'LivriniDbContext.Restaurent'  is null.");
        }

        // GET: Restaurant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Restaurent == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurent
                .FirstOrDefaultAsync(m => m.IdRestaurant == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRestaurant,Title,Rate,DeliveryTime,DeliveryPrice,ImagePath,PositionLongitude,PositionLatitude,PlaceName")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Restaurent == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurent.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRestaurant,Title,Rate,DeliveryTime,DeliveryPrice,ImagePath,PositionLongitude,PositionLatitude,PlaceName")] Restaurant restaurant)
        {
            if (id != restaurant.IdRestaurant)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.IdRestaurant))
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
            return View(restaurant);
        }

        // GET: Restaurant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Restaurent == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurent
                .FirstOrDefaultAsync(m => m.IdRestaurant == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Restaurent == null)
            {
                return Problem("Entity set 'LivriniDbContext.Restaurent'  is null.");
            }
            var restaurant = await _context.Restaurent.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurent.Remove(restaurant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
          return (_context.Restaurent?.Any(e => e.IdRestaurant == id)).GetValueOrDefault();
        }
    }
}
