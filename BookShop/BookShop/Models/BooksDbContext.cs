﻿using System.Data.Entity;
using BookShop.Models.Entities;

namespace BookShop.Models
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext():base("BooksConnection")
        {
            
        }
        public virtual DbSet<Book> Books { get; set; }
    }
}