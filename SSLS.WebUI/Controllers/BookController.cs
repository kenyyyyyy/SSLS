using SSLS.WebUI.Models;
using SSLS.Domain.Abstract;
using SSLS.Domain.Concrete;
using SSLS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSLS.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBooksRepository repository;
        public int PageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        public BookController(IBooksRepository ProductsRepository)
        {
            this.repository = ProductsRepository;
        }
        public ActionResult Detail()
        {
            int Id = int.Parse(Request.QueryString["Id"]);
            Book booksList = repository.Books.FirstOrDefault(b => b.ID == Id);

            BooksViewModel viewModel = new BooksViewModel
            {
                Book = booksList,
                Url = Url.Action("List", new { categoryId = Request.QueryString["categoryId"], Page = Request.QueryString["Page"], Id = Request.QueryString["Id"], SearchString = Request.QueryString["SearchString"] }),

            };

            return View(viewModel);
        }
        //
        // GET: /Product/
        [HttpGet]
        public ActionResult List(string SearchString, int categoryId = 0, int page = 1)
        {
            IEnumerable<Book> booksList = repository.Books;
            if (categoryId > 0)
            {
                booksList = repository.Books.Where(p => p.Category_ID == categoryId);
            }
            if (SearchString != null)
            {
                booksList = repository.Books.Where(p => p.Name.Contains(SearchString));
            }
            if (booksList.Count() == 0) return View("Empty");
            else
            {
                BooksListViewModel viewModel = new BooksListViewModel
                {
                    Books = booksList.OrderBy(p => p.ID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    pagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = booksList.Count()
                    },
                    CurrentCategoryId = categoryId,
                    SearchString = SearchString
                };


                return View(viewModel);
            }
        }
    }
}