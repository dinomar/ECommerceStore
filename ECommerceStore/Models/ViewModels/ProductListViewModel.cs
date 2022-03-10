using System.Collections;
using System.Collections.Generic;

namespace ECommerceStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<string> Catagories { get; set; }
        public string CurrentCatagory { get; set; }
    }
}
