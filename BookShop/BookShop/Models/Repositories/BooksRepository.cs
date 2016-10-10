using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BookShop.Models.Entities;

namespace BookShop.Models.Repositories
{
    public class BooksRepository :IBook
    {
        private BooksDbContext _db = new BooksDbContext();
        public void Add(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();

        }
        public void AddFew(params Book[] book)
        {
            _db.Books.AddOrUpdate(book);
            _db.SaveChanges();
        }

        public void Remove(Book book)
        {
            _db.Books.Attach(book);
            _db.Books.Remove(book);
            _db.SaveChanges();
        }

        public Book GetById(int id)
        {
            return _db.Books.FirstOrDefault(x=>x.Id==id);
        }

        public List<Book> GetAll()
        {
            return _db.Books.ToList();
        }
    }
}