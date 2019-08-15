using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeSpokedBikes.Infrastructure;
using BeSpokedBikes.Models;
using BeSpokedBikes.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeSpokedBikes.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsApiController : Controller
    {
        IProductsRepository _ProductsRepository;
        ILogger _Logger;

        public ProductsApiController(IProductsRepository productsRepo, ILoggerFactory loggerFactory)
        {
            _ProductsRepository = productsRepo;
            _Logger = loggerFactory.CreateLogger(nameof(ProductsApiController));
        }

        // GET api/products
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<Product>), 200)]
        [ProducesResponseType(typeof(ApiResponse<Product>), 400)]
        public async Task<ActionResult> Products()
        {
            try
            {
                var products = await _ProductsRepository.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse<Product> { Status = false });
            }
        }
    }
}