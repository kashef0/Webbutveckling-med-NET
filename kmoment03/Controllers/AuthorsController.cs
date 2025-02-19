using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksDirectory.Data;
using BooksDirectory.Models;

namespace kmoment03.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BooksContext _context;

        public AuthorsController(BooksContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            ViewBag.Class = "Author";
            return View(await _context.Authors.ToListAsync());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author_data = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author_data == null)
            {
                return NotFound();
            }

            return View(author_data);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,About")] Author_data author_data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author_data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author_data);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author_data = await _context.Authors.FindAsync(id);
            if (author_data == null)
            {
                return NotFound();
            }
            return View(author_data);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,About")] Author_data author_data)
        {
            if (id != author_data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author_data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Author_dataExists(author_data.Id))
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
            return View(author_data);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author_data = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author_data == null)
            {
                return NotFound();
            }

            return View(author_data);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author_data = await _context.Authors.FindAsync(id);
            if (author_data != null)
            {
                _context.Authors.Remove(author_data);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Author_dataExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
