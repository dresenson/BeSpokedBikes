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
    [Route("api/sales")]
    [ApiController]
    public class SalesApiController : Controller
    {
        ISalesRepository _SalesRepository;
        ILogger _Logger;

        public SalesApiController(ISalesRepository salesRepo, ILoggerFactory loggerFactory)
        {
            _SalesRepository = salesRepo;
            _Logger = loggerFactory.CreateLogger(nameof(SalesApiController));
        }

        // GET api/sales
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<Sale>), 200)]
        [ProducesResponseType(typeof(ApiResponse<Sale>), 400)]
        public async Task<ActionResult> Sales()
        {
            try
            {
                var sales = await _SalesRepository.GetSalesAsync();
                return Ok(sales);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse<Sale> { Status = false });
            }
        }
    }
}
