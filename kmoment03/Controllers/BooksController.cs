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
    public class BooksController : Controller
    {
        private readonly BooksContext _context;

        public BooksController(BooksContext context)
        {
            _context = context;
        }

        // GET: Books
        
        public async Task<IActionResult> Index(string search)
        {
            ViewBag.Class = "Books";
            if (_context.Books == null) {
                return Problem("there is no books");
            }
            var bookQuery = from b in _context.Books select b;
            var booksContext = _context.Books.Include(b => b.Author);
            if (!string.IsNullOrEmpty(search)) {
                bookQuery = bookQuery.Where(s => s.Title.ToUpper().Contains(search.ToUpper()));
            }
            var books= await bookQuery.ToListAsync();
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            return View();
        }


        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,AuthorId")] Book book)
        {
            try
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                Console.WriteLine($"An error occurred: {err.Message}");
                ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
                return View(book);
            }
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,AuthorId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
           if (!ModelState.IsValid) // Ensure model validation is checked
                {
                    try
                    {
                        _context.Update(book);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        if (!BookExists(book.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            // Log the concurrency exception (optional)
                            Console.WriteLine("Concurrency error: " + ex.Message);
                            ModelState.AddModelError(string.Empty, "The record you attempted to edit was modified by another user. Please refresh and try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the general exception (optional)
                        Console.WriteLine("Error: " + ex.Message);
                        ModelState.AddModelError(string.Empty, "An error occurred while updating the book. Please try again.");
                    }
                }

            // If we got this far, something failed; repopulate the AuthorId dropdown and return the view
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
