﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _0auth.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _0auth.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DbTradeContext _context;
        public ProductsController()
        {
            _context = new DbTradeContext();
        }

        // GET: API/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await Program.context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("ProductsTypes")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            try
            {
                var productTypes = await _context.ProductTypes.ToListAsync();

                if (productTypes == null || productTypes.Count == 0)
                {
                    return NotFound("Типы продуктов не найдены.");
                }

                return Ok(productTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }
    }
}