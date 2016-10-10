using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using BookShop.Models.Entities;
using BookShop.Models.Repositories;

namespace BookShop.Controllers
{
    public class UpdateBooksGridController : ApiController
    {
        private IBook _booksRepo;


        public UpdateBooksGridController(IBook iBookRepo)
        {
            _booksRepo = iBookRepo;
        }
        [HttpPost]
        public List<Book> PostBooks([FromBody]string filter)
        {
            if (filter == null)
            {
                return _booksRepo.GetAll();
            }
            else
            {
                return _booksRepo.GetByFilter(filter);
            }
        }
        [HttpPost]
        public List<Book> GetBookById(int Id)
        {
            if (Id == 0)
            {
                return _booksRepo.GetAll();
            }
            else
            {
                return _booksRepo.GetAll();
            }
        }
    }
}