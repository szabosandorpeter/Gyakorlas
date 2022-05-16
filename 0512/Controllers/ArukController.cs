using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _0512.Data;
using _0512.Models;
using Microsoft.AspNetCore.Authorization;

namespace _0512.Controllers
{
    public class ArukController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArukController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aruk
        public async Task<IActionResult> Index(string Megnevezes, string Beszallito)
        {
            var model = new Arukeres();
            var aruk = _context.Aru.Select(x => x);
            if (!string.IsNullOrEmpty(Megnevezes))
            {
                aruk = aruk.Where(x => x.Megnevezes.Contains(Megnevezes));
                model.Megnevezes = Megnevezes;
            }
            if (!string.IsNullOrEmpty(Beszallito))
            {
                aruk = aruk.Where(x => x.Beszallito.Equals(Beszallito));
                model.Beszallito = Beszallito;
            }

            model.AruLista = await aruk.OrderBy(x => x.Megnevezes).ToListAsync();
            SelectList selectList = new SelectList(await _context.Aru.Select(x => x.Beszallito).Distinct().OrderBy(x => x).ToListAsync());
            model.Beszallitolista = selectList;




            return View(model);
        }

        // GET: Aruk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aru = await _context.Aru
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aru == null)
            {
                return NotFound();
            }

            return View(aru);
        }

        // GET: Aruk/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aruk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Megnevezes,Beszallito,Ar")] Aru aru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aru);
        }

        // GET: Aruk/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aru = await _context.Aru.FindAsync(id);
            if (aru == null)
            {
                return NotFound();
            }
            return View(aru);
        }

        // POST: Aruk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Megnevezes,Beszallito,Ar")] Aru aru)
        {
            if (id != aru.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AruExists(aru.Id))
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
            return View(aru);
        }

        // GET: Aruk/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aru = await _context.Aru
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aru == null)
            {
                return NotFound();
            }

            return View(aru);
        }

        // POST: Aruk/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aru = await _context.Aru.FindAsync(id);
            _context.Aru.Remove(aru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AruExists(int id)
        {
            return _context.Aru.Any(e => e.Id == id);
        }
    }
}
