using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using BookShop.Models;
using BookShop.Models.Entities;
using BookShop.Models.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoreLinq;
namespace BookShopTests
{

    [TestClass]
    public class BooksDatabaseTest
    {
        Mock<BooksDbContext> MockContext = new Mock<BooksDbContext>();
        Mock<DbSet<Book>> MockSet = new Mock<DbSet<Book>>();

        [TestMethod]
        public void AddBook()
        {
            MockContext.Setup(x => x.Books).Returns(MockSet.Object);
            BooksRepository repo = new BooksRepository(MockContext.Object);
            repo.Add(new Book
            {
                Title = "Some book",
                Author = "Jack",
                Picture = "SomePicture",
                Description = "Some decription",
            });
            MockSet.Verify(x => x.Add(It.IsAny<Book>()), Times.Once);
            MockContext.Verify(x => x.SaveChanges(), Times.Once);
        }


        [TestMethod]
        public void RemoveBook()
        {
            MockContext.Setup(x => x.Books).Returns(MockSet.Object);
            BooksRepository repo = new BooksRepository(MockContext.Object);
            Book book = new Book()
            {
                Title = "Some book",
                Author = "Jack",
                Picture = "SomePicture",
                Description = "Some decription",
            };
            repo.Add(book);
            repo.Remove(book);
            MockSet.Verify(x => x.Remove(It.IsAny<Book>()), Times.Once);
            MockContext.Verify(x => x.SaveChanges(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void GetAllBooks()
        {
            IQueryable<Book> books = new List<Book>
            {
                new Book()
                {
                    Title = "Some book2",
                    Author = "Jack2",
                    Picture = "SomePicture2",
                    Description = "Some decription2",
                },
                new Book()
                {
                    Title = "Some book2",
                    Author = "Jack2",
                    Picture = "SomePicture2",
                    Description = "Some decription2",
                },
                new Book()
                {
                    Title = "Some book3",
                    Author = "Jack3",
                    Picture = "SomePicture3",
                    Description = "Some decription3",
                }
            }.AsQueryable();
            MockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            MockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            MockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            MockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => books.GetEnumerator());
            MockContext.Setup(x => x.Books).Returns(MockSet.Object);
            BooksRepository repo = new BooksRepository(MockContext.Object);

            List<Book> result = repo.GetAll();
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(books.ToList()[i].Title, result[i].Title);
                Assert.AreEqual(books.ToList()[i].Author, result[i].Author);
                Assert.AreEqual(books.ToList()[i].Description, result[i].Description);
                Assert.AreEqual(books.ToList()[i].Picture, result[i].Picture);
            }
        }

        [TestMethod]
        public void GetBookById()
        {
            IQueryable<Book> Books = new List<Book>
            {
                new Book()
                {
                    Id = 1,
                    Title = "Some book",
                    Author = "Jack",
                    Picture = "SomePicture",
                    Description = "Some decription",
                },
            }.AsQueryable();
            MockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(Books.Provider);
            MockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(Books.Expression);
            MockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(Books.ElementType);
            MockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => Books.GetEnumerator());
            MockContext.Setup(x => x.Books).Returns(MockSet.Object);
            BooksRepository repo = new BooksRepository(MockContext.Object);
            Book result = repo.GetById(1);
            Assert.AreEqual(Books.ToList()[0].Title, result.Title);
            Assert.AreEqual(Books.ToList()[0].Author, result.Author);
            Assert.AreEqual(Books.ToList()[0].Description, result.Description);
            Assert.AreEqual(Books.ToList()[0].Picture, result.Picture);

        }
        [TestMethod]
        public void GetByFilter()
        {
            IQueryable<Book> Books = new List<Book>
            {
                new Book()
                {
                    Id = 1,
                    Title = "ASP.NET book",
                    Author = "Kevin",
                    Picture = "SomePictureASP",
                    Description = "Some decriptionASP",
                },
                 new Book()
                {
                    Id = 2,
                    Title = "T-SQL book",
                    Author = "Samantha",
                    Picture = "SomePicture",
                    Description = "Some decription",
                },
                  new Book()
                {
                    Id = 3,
                    Title = "ASP.NET book2",
                    Author = "Jack",
                    Picture = "SomePictureASP2",
                    Description = "Some decriptionASP2",
                },
                    new Book()
                {
                    Id = 4,
                    Title = "T-SQL book2",
                    Author = "Jessica",
                    Picture = "SomePictureT-SQL2",
                    Description = "Some decriptionT-SQL2",
                }
            }.AsQueryable();
            MockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(Books.Provider);
            MockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(Books.Expression);
            MockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(Books.ElementType);
            MockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => Books.GetEnumerator());
            MockContext.Setup(x => x.Books).Returns(MockSet.Object);
            BooksRepository repo = new BooksRepository(MockContext.Object);
            List<Book> expected = new List<Book>
            {
                new Book()
                {
                    Id = 1,
                    Title = "ASP.NET book",
                    Author = "Kevin",
                    Picture = "SomePictureASP",
                    Description = "Some decriptionASP",
                },
                
                  new Book()
                {
                    Id = 3,
                    Title = "ASP.NET book2",
                    Author = "Jack",
                    Picture = "SomePictureASP2",
                    Description = "Some decriptionASP2",
                }};
            List<Book> results = repo.GetByFilter("ASP").OrderBy(x=>x.Id).ToList();
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected[i].Title, results[i].Title);
                Assert.AreEqual(expected[i].Author, results[i].Author);
                Assert.AreEqual(expected[i].Description, results[i].Description);
                Assert.AreEqual(expected[i].Picture, results[i].Picture);
            }
        }
    }
}
