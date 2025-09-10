
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P5_WebApi.Data;
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

        [HttpGet("archive")]

        public async Task<IActionResult> ArchiveProduct(Guid productId)
        {
            try
            {
                var product = await sqlDb.Products.FindAsync(productId);
                if (product == null)
                {
                    return NotFound(new { message = "product not found !" , productId});
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


        [HttpPut("update")]

        public async Task<IActionResult> UpdateProduct(Guid productId , Product product)
        {
            try
            {
                var existingproduct = await sqlDb.Products.FindAsync(productId);


                if (existingproduct == null)
                {
                    return NotFound(new { message = "product not found !" });
                }
                // product.UpdatedAt = DateTime.Now;

                existingproduct = product;

                // need some changes
                
                await sqlDb.SaveChangesAsync();


                return Ok(new {message = "product updated Succesfully !" , payload = existingproduct});
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }

    }
}
