using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvoxSolutions.WebApi.Data;
using EvoxSolutions.WebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvoxSolutions.WebApi.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        [EnableCors("AllowSpecific")]
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(c => c.Category).ToListAsync();
            return products;
        }

        [EnableCors("AllowSpecific")]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [EnableCors("AllowSpecific")]
        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetBycategory([FromServices] DataContext context, int id)
        {
            var products = await context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToListAsync();

            return products;
        }

        [EnableCors("AllowSpecific")]
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
                return BadRequest(ModelState);
        }
    }
}