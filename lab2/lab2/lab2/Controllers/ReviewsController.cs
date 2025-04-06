using System;
using lab2.Data;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab2.Controllers
{
    [ApiController]
    [Route("api/books/{bookId}/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReviewsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetByBook(int bookId)
        {
            var reviews = await _context.Reviews.Where(r => r.BookId == bookId).ToListAsync();
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int bookId, Review review)
        {
            review.BookId = bookId;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByBook), new { bookId }, review);
        }
    }

}

