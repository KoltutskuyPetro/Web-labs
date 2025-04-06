using System;
using lab2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab2.Data
{
    // Data/AppDbContext.cs
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }

}

