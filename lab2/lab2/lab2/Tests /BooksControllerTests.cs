using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using lab2.Controllers;
using lab2.Models;
using lab2.Data;
using lab2.Controllers;
using lab2.Data;
using lab2.Models;
using Microsoft.EntityFrameworkCore;

public class BooksControllerTests
{
    private readonly BooksController _controller;
    private readonly Mock<AppDbContext> _mockContext;

    public BooksControllerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        _mockContext = new Mock<AppDbContext>(options);
        _controller = new BooksController(_mockContext.Object);
    }

    [Fact]
    public async Task GetAllBooks_ReturnsBooksList()
    {
        var books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = new Author { Name = "Author 1" } },
            new Book { Id = 2, Title = "Book 2", Author = new Author { Name = "Author 2" } }
        };

        _mockContext.Setup(c => c.Books).ReturnsDbSet(books);

        var result = await _controller.GetAll(1, 5, "title");
        var okResult = result as OkObjectResult;
        var returnedBooks = okResult?.Value as List<Book>;

        Assert.NotNull(returnedBooks);
        Assert.Equal(2, returnedBooks.Count);
    }

    [Fact]
    public async Task GetBookReviews_WithValidBookId_ReturnsReviews()
    {
        var bookId = 1;
        var books = new List<Book>
        {
            new Book
            {
                Id = bookId, Title = "Book 1", Author = new Author { Name = "Author 1" }, Reviews = new List<Review>
                {
                    new Review { Id = 1, Content = "Great Book!", Rating = 5 }
                }
            }
        };

        _mockContext.Setup(c => c.Books).ReturnsDbSet(books);

        var booksResult = await _controller.GetAll(1, 5, "title");
        var okResult = booksResult as OkObjectResult;
        var returnedBooks = okResult?.Value as List<Book>;
        var bookToFetchReviewsFor = returnedBooks?.FirstOrDefault();

        List<Review> reviews = new List<Review>();
        if (bookToFetchReviewsFor != null)
        {
            reviews = await _controller.GetReviews(bookToFetchReviewsFor.Id);
        }

        Assert.NotNull(reviews);
        Assert.Equal(1, reviews.Count);
        Assert.Equal("Great Book!", reviews.First().Content);
    }

    [Fact]
    public async Task GetAllBooks_ReturnsError_WhenExceptionOccurs()
    {
        _mockContext.Setup(c => c.Books).ThrowsAsync(new System.Exception("Database Error"));

        var result = await _controller.GetAll(1, 5, "title");
        var badRequestResult = result as BadRequestObjectResult;

        Assert.NotNull(badRequestResult);
        Assert.Equal("An error occurred while fetching books.", badRequestResult.Value);
    }

    [Fact]
    public async Task GetAllBooks_ReturnsNoBooksFound_WhenBooksAreEmpty()
    {
        var books = new List<Book>();
        _mockContext.Setup(c => c.Books).ReturnsDbSet(books);

        var result = await _controller.GetAll(1, 5, "title");
        var okResult = result as OkObjectResult;
        var returnedBooks = okResult?.Value as List<Book>;

        Assert.Empty(returnedBooks);
    }
}
