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
    [ApiController]
    public class SalespersonsApiController : Controller
    {
        ISalespersonsRepository _SalespersonsRepository;
        ILogger _Logger;

        public SalespersonsApiController(ISalespersonsRepository salespersonsRepo, ILoggerFactory loggerFactory)
        {
            _SalespersonsRepository = salespersonsRepo;
            _Logger = loggerFactory.CreateLogger(nameof(SalespersonsApiController));
        }

        // GET api/salespersons
        [Route("api/salespersons")]
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<Salesperson>), 200)]
        [ProducesResponseType(typeof(ApiResponse<Salesperson>), 400)]
        public async Task<ActionResult> Salespersons()
        {
            try
            {
                var salespersons = await _SalespersonsRepository.GetSalespersonsAsync();
                return Ok(salespersons);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse<Salesperson> { Status = false });
            }
        }

        [Route("api/salespersons/report")]
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<Salesperson>), 200)]
        [ProducesResponseType(typeof(ApiResponse<Salesperson>), 400)]
        public async Task<ActionResult> SalespersonsReport()
        {
            try
            {
                var salespersons = await _SalespersonsRepository.GetSalespersonsReportAsync();
                return Ok(salespersons);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse<Salesperson> { Status = false });
            }
        }

        // GET api/customers/5
        [Route("api/salespersons/{id}")]
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(Salesperson), 200)]
        [ProducesResponseType(typeof(ApiResponse<Salesperson>), 400)]
        public async Task<ActionResult> Salespersons(int id)
        {
            try
            {
                var customer = await _SalespersonsRepository.GetSalespersonAsync(id);
                return Ok(customer);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse<Salesperson> { Status = false });
            }
        }
    }
}
