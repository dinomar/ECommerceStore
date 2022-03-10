using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.ViewModels
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }
        public IFormFile Image { get; set; }
    }
}
