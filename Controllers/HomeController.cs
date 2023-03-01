using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09MitchskiBookStore.Models;
using Mission09_mitchski.Models;
using Mission09_mitchski.Models.ViewModels;

namespace Mission09MitchskiBookStore.Controllers
{
    public class HomeController : Controller
    {

        private IBookStoreRepository repo;

        public HomeController(IBookStoreRepository temp)
        {
            repo = temp;
        }

        //No longer referenceing the dbcontext class directly
        //private BookstoreContext context { get; set; }

        //public HomeController(BookstoreContext temp)
        //{
        //    context = temp;
        //}
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModels
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumOfBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            //var test = repo.Books
            //    .OrderBy(b => b.Author)
            //    .Skip((pageNum - 1) * pageNum)
            //    .Take(pageSize);
                // .Skip(5) You can use this to skip over some results
            //var test = context.Books.ToList();

            return View(x);
        }
    }
}
