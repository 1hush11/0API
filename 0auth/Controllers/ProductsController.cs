using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _0auth.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _0auth.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private DbTradeContext context;
        public ProductsController(DbTradeContext _context)
        {
            context = _context;
        }
        // GET: API/Products
        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await context.Products.ToListAsync();
            if (products == null || products.Count == 0)
            {
                return NotFound("Продукты не найдены.");
            }
            return Ok(products);
        }
        [HttpGet("GetProductTypes")]
        public Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            try
            {
                using (var context = new DbTradeContext())
                {
                    var productTypes = context.ProductTypes.ToList();

                    if (productTypes == null || productTypes.Count == 0)
                    {
                        return Task.FromResult<ActionResult<List<ProductType>>>(NotFound("Типы продуктов не найдены."));
                    }

                    return Task.FromResult<ActionResult<List<ProductType>>>(Ok(productTypes));
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult<ActionResult<List<ProductType>>>(StatusCode(500, $"Произошла ошибка: {ex.Message}"));
            }
        }

        [HttpGet("GetSuppliers")]
        public Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var suppliers = context.Suppliers.ToList();
            return Task.FromResult<ActionResult<IEnumerable<Supplier>>>(Ok(suppliers));
        }

        [HttpGet("GetManufacturers")]
        public Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturers()
        {
            var manufacturers = context.Manufacturers.ToList();
            return Task.FromResult<ActionResult<IEnumerable<Manufacturer>>>(Ok(manufacturers));
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> AddProduct([FromBody] ProductDTO newProductDTO)
        {
            if (newProductDTO == null)
            {
                return BadRequest("Неверные данные продукта.");
            }

            var existingProduct = context.Products.FirstOrDefault(p => p.ProductArticleNumber == newProductDTO.ProductArticleNumber);
            if (existingProduct != null) { return Conflict("Продукт с таким артикулом уже существует"); }

            try
            {

                var newProduct = new Product
                {
                    ProductArticleNumber = newProductDTO.ProductArticleNumber,
                    NameProduct = newProductDTO.NameProduct,
                    MeasureProduct = newProductDTO.MeasureProduct,
                    CostProduct = newProductDTO.CostProduct,
                    DescriptionProduct = newProductDTO.DescriptionProduct,
                    IdProductType = newProductDTO.IdProductType,
                    PhotoProduct = newProductDTO.PhotoProduct,
                    IdSupplier = newProductDTO.IdSupplier,
                    MaxDiscount = newProductDTO.MaxDiscount,
                    IdManufacturer = newProductDTO.IdManufacturer,
                    CurrentDiscount = newProductDTO.CurrentDiscount,
                    StatusProduct = newProductDTO.StatusProduct,
                    QuantityInStock = newProductDTO.QuantityInStock
                };

                context.Products.Add(newProduct);
                context.SaveChanges();

                return StatusCode(201, newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Произошла ошибка: {ex.Message}");
            }
        }

        // PUT: API/Products/UpdateProduct
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product updatedProduct)
        {
            if (updatedProduct == null || string.IsNullOrWhiteSpace(updatedProduct.ProductArticleNumber))
            {
                return BadRequest("Некорректные данные для обновления продукта");
            }

            var product = await context.Products.FirstOrDefaultAsync(p => p.ProductArticleNumber == updatedProduct.ProductArticleNumber);
            if (product == null)
            {
                return NotFound($"Продукт с артикулом {updatedProduct.ProductArticleNumber} не найден");
            }

            product.NameProduct = updatedProduct.NameProduct ?? product.NameProduct;
            product.MeasureProduct = updatedProduct.MeasureProduct ?? product.MeasureProduct;
            product.CostProduct = updatedProduct.CostProduct != 0 ? updatedProduct.CostProduct : product.CostProduct;
            product.DescriptionProduct = updatedProduct.DescriptionProduct ?? product.DescriptionProduct;
            product.IdProductType = updatedProduct.IdProductType != 0 ? updatedProduct.IdProductType : product.IdProductType;
            product.PhotoProduct = updatedProduct.PhotoProduct ?? product.PhotoProduct;
            product.IdSupplier = updatedProduct.IdSupplier != 0 ? updatedProduct.IdSupplier : product.IdSupplier;
            product.MaxDiscount = updatedProduct.MaxDiscount ?? product.MaxDiscount;
            product.CurrentDiscount = updatedProduct.CurrentDiscount ?? product.CurrentDiscount;
            product.IdManufacturer = updatedProduct.IdManufacturer != 0 ? updatedProduct.IdManufacturer : product.IdManufacturer;
            product.QuantityInStock = updatedProduct.QuantityInStock != 0 ? updatedProduct.QuantityInStock : product.QuantityInStock;
            product.StatusProduct = updatedProduct.StatusProduct ?? product.StatusProduct;

            try
            {
                await context.SaveChangesAsync();
                return Ok("Продукт успешно обновлен");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Ошибка при обновлении продукта: {ex.Message}");
            }
        }
        [HttpPut("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] string id)
        {
            var existingProduct = context.Products.FirstOrDefault(p => p.ProductArticleNumber == id);
            if (existingProduct != null)
            {
                context.Products.Remove(existingProduct);
                await context.SaveChangesAsync();
                return Ok($"Товар с артикулом {id} удалён");
            }
            else
                return StatusCode(500, "Ошибка при удалении продукта.");
        }
    }
}