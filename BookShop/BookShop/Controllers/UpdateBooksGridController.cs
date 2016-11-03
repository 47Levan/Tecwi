using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BookShop.Models.Entities;
using BookShop.Models.Repositories;
using WebHttpContext = System.Web.HttpContext;
namespace BookShop.Controllers
{
    public class UpdateBooksGridController : ApiController
    {
        private readonly IBook _booksRepo;


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
        [HttpPost]
        public async Task<List<Book>> AddBook()
        {
            
            if (Request.Content.IsMimeMultipartContent())
            {
                
                Book book = new Book
                {
                    Author = WebHttpContext.Current.Request.Params[0],
                    Title = WebHttpContext.Current.Request.Params[1],
                    Picture = WebHttpContext.Current.Request.Params[2],
                    Description = WebHttpContext.Current.Request.Params[3]
                };
                HttpPostedFile uploadedFile = null;
                if (WebHttpContext.Current.Request.Files.Count > 0)
                {
                    uploadedFile = WebHttpContext.Current.Request.Files[0];
                }
                if (uploadedFile != null)
                {
                    string pathToSave = Path.Combine(WebHttpContext.Current.Server
               .MapPath("~/Images/Books/" + uploadedFile.FileName));
                    book.Picture = "/Images/Books/" + uploadedFile.FileName;
                    uploadedFile.SaveAs(pathToSave);
                }


                _booksRepo.Add(book);
                _booksRepo.GetAll();
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "Invalid Request!"));
            }

            // _booksRepo.Add(book);
            return _booksRepo.GetAll();
        }
    }
}