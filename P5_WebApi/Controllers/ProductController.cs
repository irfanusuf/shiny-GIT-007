
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P5_WebApi.Data;
using P5_WebApi.Middlewares;
using P5_WebApi.Models.DomainModels;


namespace P5_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private readonly SqlDbContext sqlDb;

        public ProductController(SqlDbContext dbContext)
        {
            sqlDb = dbContext;
        }


        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = "All the product data is required !" });
                }

                await sqlDb.Products.AddAsync(product);
                await sqlDb.SaveChangesAsync();
                return Ok(new
                {
                    message = "Product added to the list succesfully !"
                });

            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Internal server Error" });
            }

        }

        [Authorize]
        [HttpGet("archive")]
        public async Task<IActionResult> ArchiveProduct(Guid productId)
        {
            try
            {
                var product = await sqlDb.Products.FindAsync(productId);
                if (product == null)
                {
                    return NotFound(new { message = "product not found !", productId });
                }

                if (product.IsArchived == false && product.IsAvailable == true)
                {
                    product.IsArchived = true;
                    product.IsAvailable = false;

                    product.UpdatedAt = DateTime.Now;

                    await sqlDb.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = "Product is already in archive !" });
                }



                return Ok(new
                {
                    message = "product archived !",
                    payload = product
                });
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [Authorize]
        [HttpGet("unarchive")]
        public async Task<IActionResult> UnArchiveProduct(Guid productId)
        {
            try
            {
                var product = await sqlDb.Products.FindAsync(productId);
                if (product == null)
                {
                    return NotFound(new { message = "product not found !" });
                }

                if (product.IsArchived == true && product.IsAvailable == false)
                {
                    product.IsArchived = false;
                    product.IsAvailable = true;

                    product.UpdatedAt = DateTime.Now;

                    await sqlDb.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = "Product is already in Unarchived list !" });
                }



                return Ok(new
                {
                    message = "product Unarchived !",
                    payload = product
                });
            }
            catch (System.Exception)
            {

                throw;
            }

        }
       
        [Authorize]
        [HttpGet("delete")]
        public async Task<ActionResult> DeleteProduct(Guid productId)
        {
            
            try
            {

                 var product = await sqlDb.Products.FindAsync(productId);
                if (product == null)
                {
                    return NotFound(new { message = "product not found !", productId });
                }

                 if (product.IsArchived == true && product.IsAvailable == false)
                {
                    product.IsArchived = false;
                    product.UpdatedAt = DateTime.Now;

                    await sqlDb.SaveChangesAsync();
                }
                else
                {
                    return BadRequest(new { message = "Product is shifted to recycle bin !" });
                }




                return Ok();
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
      
        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(Guid productId, Product product)
        {
            try
            {
                var existingproduct = await sqlDb.Products.FindAsync(productId);

                if (existingproduct == null)
                {
                    return NotFound(new { message = "product not found !" });
                }
                // product.UpdatedAt = DateTime.Now;

                existingproduct.ProductName = product.ProductName;
                existingproduct.ProductDescription = product.ProductDescription;
                existingproduct.ProductImage = product.ProductImage;
                existingproduct.ProductStock = product.ProductStock;
                existingproduct.ProductPrice = product.ProductPrice;
                existingproduct.Size = product.Size;
                existingproduct.Color = product.Color;
                existingproduct.Weight = product.Weight;
                existingproduct.Category = product.Category;
                existingproduct.UpdatedAt = DateTime.Now;

                // need some changes

                await sqlDb.SaveChangesAsync();


                return Ok(new { message = "product updated Succesfully !", payload = existingproduct });
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var products = await sqlDb.Products.Where(p => p.IsAvailable == true).ToListAsync();

                return Ok(new { message = $"{products.Count} products are found !", payload = products });
            }
            catch (System.Exception)
            {

                throw;
            }

        }


        [HttpGet("getById")]
        public async Task<ActionResult> GetProductById(Guid productId)
        {

            try
            {

                var product = await sqlDb.Products.FindAsync(productId);
                return Ok(new {message = "1 product found !" , payload =product});
                
            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }
}
