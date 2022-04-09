using Pc.Core.Entities.Product;
using System.Collections.Generic;

namespace Pc.Core.DTO
{
    public class ProductWithPaging
    {
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public List<Product> Products { get; set; }
        public int Pages { get; set; }
    }
}