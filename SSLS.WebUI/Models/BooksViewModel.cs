using SSLS.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSLS.WebUI.Models
{
    public class BooksViewModel
    {
        public Book Book { get; set; }

        public string Url { get; set; }
    }
}