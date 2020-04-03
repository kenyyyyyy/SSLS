using SSLS.Domain.Concrete;
using System.Collections.Generic;

namespace SSLS.WebUI.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo pagingInfo { get; set; }
        public int CurrentCategoryId { get; set; }
        public string SearchString { get; set; }
      
    }
}