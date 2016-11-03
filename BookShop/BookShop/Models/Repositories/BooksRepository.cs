using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BookShop.Models.Entities;
using MoreLinq;
namespace BookShop.Models.Repositories
{
    public class BooksRepository : IBook
    {
        private BooksDbContext _db = new BooksDbContext();

        public BooksRepository()
        {
            
        }
        public BooksRepository(BooksDbContext context)
        {
            _db = context;
        }
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
            return _db.Books.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetByFilter(string filter)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in _db.Books)
            {
                if (book.Title.Split().Any(x => x.StartsWith(filter)) || book.Title == filter
                    || book.Author.Split().Any(x => x.StartsWith(filter)) || book.Author == filter)
                {
                    result.Add(book);
                }
            }
            return result;
        }

        public List<Book> GetAll()
        {
            List<Book> result = _db.Books.ToList();
            return result;
        }
    }
}