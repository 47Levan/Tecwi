using System.Collections.Generic;
using BookShop.Models.Entities;

namespace BookShop.Models.Repositories
{
    interface IBook
    {
        void Add(Book book);
        void Remove(Book book);
        Book GetById(int id);
        List<Book> GetAll();

    }
}
