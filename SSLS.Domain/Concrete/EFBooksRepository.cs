using SSLS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLS.Domain.Concrete
{
    public class EFBooksRepository : IBooksRepository
    {
        private SSLSEntities db = new SSLSEntities();
        public IEnumerable<Book> Books
        {
            get { return db.Book; }
        }

        public IEnumerable<Category> Categorys
        {
            get { return db.Category; }
        }

        public IEnumerable<Reader> Readers
        {
            get { return db.Reader; }
        }
    }
}
