using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using BookShop.Models.Entities;
using BookShop.Models.Repositories;

namespace BookShop.Controllers
{
    public class UpdateBooksGridController :ApiController
    {
        private IBook _booksRepo;


        public UpdateBooksGridController(IBook iBookRepo)
        {
            _booksRepo = iBookRepo;
        }
        public List<Book> GetAllBooks()
        {
            return _booksRepo.GetAll();
        }
    }
}