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
    [Route("api/customers")]
    [ApiController]
    public class CustomersApiController : Controller
    {
        ICustomersRepository _CustomersRepository;
        ILogger _Logger;

        public CustomersApiController(ICustomersRepository customersRepo, ILoggerFactory loggerFactory)
        {
            _CustomersRepository = customersRepo;
            _Logger = loggerFactory.CreateLogger(nameof(CustomersApiController));
        }

        // GET api/customers
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<Customer>), 200)]
        [ProducesResponseType(typeof(ApiResponse<Customer>), 400)]
        public async Task<ActionResult> Customers()
        {
            try
            {
                var customers = await _CustomersRepository.GetCustomersAsync();
                return Ok(customers);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse<Customer> { Status = false });
            }
        }
    }
}