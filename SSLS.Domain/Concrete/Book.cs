//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSLS.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.Borrow = new HashSet<Borrow>();
        }
    
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Press { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int Category_ID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Borrow> Borrow { get; set; }
    }
}
