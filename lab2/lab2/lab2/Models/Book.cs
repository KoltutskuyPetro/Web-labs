using System;
namespace lab2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}

