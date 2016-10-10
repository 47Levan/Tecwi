using BookShop.Models;
using BookShop.Models.Entities;
using BookShop.Models.Repositories;

namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BooksDbContext>
    {
        private IBook booksRepo = new BooksRepository();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        
        protected override void Seed(BooksDbContext context)
        {
            booksRepo.AddFew(new Book{
                         Title = "JavaScript: The Definitive Guide: Activate " +
                                 "Your Web Pages (Definitive Guides)",
                         Author = "David Flanagan",
                         Picture = "https://images-na.ssl-images-amazon.com/images/I/51WD-F3GobL._SX379_BO1,204,203,200_.jpg",
                         Description = "<p>Since 1996, <i>JavaScript: The Definitive Guide</i> " +
                                       "has been the bible for JavaScript programmers—a programmer's" +
                                       " guide and comprehensive reference to the core language " +
                                       "and to the client-side JavaScript APIs defined by web " +
                                       "browsers.</p><p>The 6th edition covers HTML5 and ECMAScript " +
                                       "5. Many chapters have been completely rewritten to bring them " +
                                       "in line with today's best web development practices." +
                                       " New chapters in this edition document jQuery and server " +
                                       "side JavaScript. It's recommended for experienced programmers" +
                                       " who want to learn the programming language of the Web, and " +
                                       "for current JavaScript programmers who want to master it.</p>" +
                                       "<p>A must - have reference for expert JavaScript " +
                                       "programmers...well - organized and detailed.<br>—Brendan Eich," +
                                       " creator of JavaScript, CTO of Mozilla</p><p>" +
                                       "I made a career of what I learned from < i > JavaScript:" +
                                       " The Definitive Guide </ i >.”< br >—Andrew Hedges, Tapulous " +
                                       "</ p > "
                     }, new Book
                     {
                         Title = "T-SQL Fundamentals (3rd Edition)",
                         Author = "Itzik Ben-Gan",
                         Picture = "https://images-na.ssl-images-amazon.com/images/I/41VK7fjd7KL._SX408_BO1,204,203,200_.jpg",
                         Description = "<p> <b>Effectively query and modify data " +
                                       "using Transact-SQL</b> <br>Master T-SQL fundamentals " +
                                       "and write robust code for Microsoft SQL Server and " +
                                       "Azure SQL Database. Itzik Ben-Gan explains key T-SQL " +
                                       "concepts and helps you apply your knowledge with hands-on" +
                                       " exercises. The book first introduces T-SQL’s roots and " +
                                       "underlying logic. Next, it walks you through core topics" +
                                       " such as single-table queries, joins, subqueries, table " +
                                       "expressions, and set operators. Then the book covers " +
                                       "more-advanced data-query topics such as window functions," +
                                       " pivoting, and grouping sets. The book also explains how " +
                                       "to modify data, work with temporal tables, and handle " +
                                       "transactions, and provides an overview of programmable" +
                                       " objects.</p> <p> <b> <br> </b> </p> <p>" +
                                       " <b>Microsoft Data Platform MVP Itzik Ben-Gan shows you how" +
                                       " to:</b> </p> <ul> <li>Review core SQL concepts and its " +
                                       "mathematical roots</li> <li>Create tables and enforce data " +
                                       "integrity</li> <li>Perform effective single-table queries by " +
                                       "using the SELECT statement</li> <li>Query multiple tables by" +
                                       " using joins, subqueries, table expressions, and set " +
                                       "operators</li> <li>Use advanced query techniques such " +
                                       "as window functions, pivoting, and grouping sets</li>" +
                                       " <li>Insert, update, delete, and merge data</li> " +
                                       "<li>Use transactions in a concurrent environment</li> " +
                                       "<li>Get started with programmable objects–from variables" +
                                       " and batches to user-defined functions, stored procedures," +
                                       " triggers, and dynamic SQL</li> </ul>"
                     },
                     new Book
                     {
                         Title = "Professional ASP.NET MVC 5",
                         Author = " Jon Galloway",
                         Picture = "https://images-na.ssl-images-amazon.com/images/I/51JKF1rpL3L._SX397_BO1,204,203,200_.jpg",
                         Description = "<p><b>ASP.NET MVC insiders cover the latest updates " +
                                       "to the technology in this popular Wrox reference</b></p>" +
                                       " <p>MVC 5 is the newest update to the popular Microsoft" +
                                       " technology that enables you to build dynamic, data-driven" +
                                       " websites. Like previous versions, this guide shows " +
                                       "you step-by-step techniques on using MVC to best advantage," +
                                       " with plenty of practical tutorials to illustrate the " +
                                       "concepts. It covers controllers, views, and models; forms" +
                                       " and HTML helpers; data annotation and validation;" +
                                       " membership, authorization, and security.</p> <ul> <li>" +
                                       "MVC 5, the latest version of MVC, adds sophisticated" +
                                       " features such as single page applications, mobile " +
                                       "optimization, and adaptive rendering</li> <li>A team of" +
                                       " top Microsoft MVP experts, along with visionaries in the" +
                                       " field, provide practical advice on basic and advanced" +
                                       " MVC topics</li> <li>Covers controllers, views, models," +
                                       " forms, data annotations, authorization and security," +
                                       " Ajax, routing, ASP.NET web API, dependency injection, " +
                                       "unit testing, real-world application, and much more</li>" +
                                       " </ul> <p><i>Professional ASP.NET MVC 5</i> is the" +
                                       " comprehensive resource you need to make the best use" +
                                       " of the updated Model-View-Controller technology.</p>"
                     },
                     new Book
                     {
                         Title = "ASP.NET MVC 5 with Bootstrap and Knockout.js",
                         Author = "Jamie Munro ",
                         Picture = "https://images-na.ssl-images-amazon.com/images/I/517yImP8zeL._SX379_BO1,204,203,200_.jpg",
                         Description = "<p>Bring dynamic server-side web content and " +
                                       "responsive web design together to build websites " +
                                       "that work and display well on any resolution, desktop " +
                                       "or mobile. With this practical book, you’ll learn how" +
                                       " by combining the ASP.NET MVC server-side language," +
                                       " the Bootstrap front-end framework, and Knockout.js—the " +
                                       "JavaScript implementation of the Model-View-ViewModel" +
                                       " pattern.</p><p>Author Jamie Munro introduces these and " +
                                       "other related technologies by having you work with " +
                                       "sophisticated web forms. At the end of the book, experienced " +
                                       "and aspiring web developers alike will learn how to build a" +
                                       " complete shopping cart that demonstrates how these" +
                                       " technologies interact with each other in a sleek, dynamic," +
                                       " and responsive web application.</p><ul><li>" +
                                       "Build well-organized, easy-to-maintain web applications " +
                                       "by letting ASP.NET MVC 5, Bootstrap, and Knockout.js " +
                                       "do the heavy lifting</li><li>Use ASP.NET MVC 5 to build " +
                                       "server-side web applications, interact with a database, " +
                                       "and dynamically render HTML</li><li>Create responsive " +
                                       "views with Bootstrap that render on a variety of modern " +
                                       "devices; you may never code with CSS again</li><li>" +
                                       "Add Knockout.js to enhance responsive web design with snappy" +
                                       " client-side interactions driven by your server-side web" +
                                       " application</li></ul>"
                     });
        }
    }
}
