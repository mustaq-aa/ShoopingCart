using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApi.Data;
using ShoppingApi.Models;
using System.Net.Http;

namespace ShoppingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductContext.Products;
        }


        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;            
        }
    }
}
