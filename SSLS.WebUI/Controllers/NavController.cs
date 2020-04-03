using SSLS.Domain.Abstract;
using SSLS.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSLS.WebUI.Controllers
{
    public class NavController : Controller
    {
        //
        // GET: /Nav/
        private IBooksRepository repository;
        // GET: Nav
        public NavController(IBooksRepository partitionResolver)
        {
            this.repository = partitionResolver;
        }
        public PartialViewResult Menu(int categoryId = 0)
        {
            ViewBag.CurrentCategoryId = categoryId;
            IEnumerable<Category> Categorys = repository.Categorys.ToList();


            return PartialView(Categorys);
        }
	}
}