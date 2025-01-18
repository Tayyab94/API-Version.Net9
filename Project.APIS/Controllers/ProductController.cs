using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using Project.APIS.Features;
using Project.APIS.Models;

namespace Project.APIS.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly ProductDbContext _context;
        private readonly IFeatureManager featureManager;



        public ProductController(ILogger<ProductController> logger,
            ProductDbContext context, IFeatureManager featureManager)
        {
            _logger = logger;
            this.featureManager = featureManager;
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductV1>>>GetProducts()
        {
            if(! await featureManager.IsEnabledAsync(APIFeatures.UseApiV1Product))
            {
                return NotFound();
            }
            var res = await this._context.ProductsV1.Select(s => new ProductV1()
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();

            return Ok(res);
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("1")]
        [FeatureGate(APIFeatures.UseApiV1Product)]
        public async Task<ActionResult<ProductV1>> GetProductByIdV1(int id)
        {

            //if (!await featureManager.IsEnabledAsync(APIFeatures.UseApiV1Product))
            //{
            //    return NotFound();
            //}  we can use Action filter  ( FeatureGate) written above


            var res = await this._context.ProductsV1.Where(s=>s.Id==id).Select(s => new ProductV1()
            {
                Id = s.Id,
                Name = s.Name
            }).FirstOrDefaultAsync();

            if (res is null)
                return NotFound();

            return Ok(res);
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("2")]
        [FeatureGate(APIFeatures.UseApiV2Product)]
        public async Task<ActionResult<ProductV2>> GetProductByIdV2(int id)
        {

            //if (!await featureManager.IsEnabledAsync(APIFeatures.UseApiV2Product))
            //{
            //    return NotFound();
            //}


            var res = await this._context.ProductsV1.Where(s => s.Id == id).Select(s => new ProductV2()
            {
                Id = s.Id,
                Name = s.Name,
                ProductPrice = new ProductPrice
                {
                    Amount= 12M,
                    Currency= "USD"
                }
            }).FirstOrDefaultAsync();

            if (res is null)
                return NotFound();

            return Ok(res);
        }
        


    }
}
