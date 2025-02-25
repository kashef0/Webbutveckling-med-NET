using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongApi.Data;
using SongCategoryApi.Models;

namespace kmoment04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SongContext _context;

        public CategoryController(SongContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongCategory>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongCategory>> GetSongCategory(int id)
        {
            var songCategory = await _context.Categories.FindAsync(id);

            if (songCategory == null)
            {
                return NotFound();
            }

            return songCategory;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongCategory(int id, SongCategory songCategory)
        {
            if (id != songCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(songCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongCategory>> PostSongCategory(SongCategory songCategory)
        {
            _context.Categories.Add(songCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongCategory", new { id = songCategory.Id }, songCategory);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongCategory(int id)
        {
            var songCategory = await _context.Categories.FindAsync(id);
            if (songCategory == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(songCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongCategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
