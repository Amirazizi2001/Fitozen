using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementLand.Domain.Entities;

public class RelatedProduct
{
   
        public int Id { get; set; }             // شناسه محصول مرتبط
        public int ProductId { get; set; }      // محصول اصلی
        public Product Product { get; set; }    // navigation property به محصول اصلی
        public string Name { get; set; }        // نام محصول مرتبط
        public decimal Price { get; set; }      // قیمت محصول مرتبط
        public List<Guid>? DocumentIds { get; set; }    // تصویر محصول مرتبط
    

}
