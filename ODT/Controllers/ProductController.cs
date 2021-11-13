using Microsoft.AspNetCore.Mvc;
using ODT.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODT.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepositoy productRepository;
        public ProductController(IProductRepositoy _productRepository)
        {
            productRepository = _productRepository;
        }
        
        [Route("ProductList")]
        public async Task<IActionResult> ProductList()
        {
            return View(await productRepository.GetAllProductsDetails());
        }
    }
}
