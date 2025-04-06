
using System;
using lab2.Data;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthorsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Authors.Include(a => a.Books).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
            return author == null ? NotFound() : Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Author author)
        {
            if (id != author.Id) return BadRequest();
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return NotFound();
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}

