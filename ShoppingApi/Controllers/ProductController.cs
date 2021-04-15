using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingApi.Data;
using ShoppingApi.Models;
using System.Net.Http;
using MongoDB.Driver;

namespace ShoppingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _context;
        
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }


        public ProductController(ILogger<ProductController> logger,ProductContext context)
        {
            _logger = logger;
            _context = context;
        }
    }
}
