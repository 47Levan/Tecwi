using System.Collections.Generic;
using BookShop.Models.Entities;

namespace BookShop.Models.Repositories
{
    public interface IBook
    {
        void Add(Book book);
        void AddFew(params Book[] book);
        void Remove(Book book);
        Book GetById(int id);
        List<Book> GetAll();

    }
}
