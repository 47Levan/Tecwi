using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Models.Entities;

namespace BookShop.Models.Repositories
{
    public class BooksRepository :IBook
    {
        private BooksDbContext _db = new BooksDbContext();
        public void Add(Book book)
        {
            _db.Books.Add(book);
        }

        public void Remove(Book book)
        {
            _db.Books.Attach(book);
            _db.Books.Remove(book);
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