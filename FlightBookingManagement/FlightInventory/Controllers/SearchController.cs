using DAL.Models;
using System.Transactions;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FlightInventory.Controllers
{
    [Authorize]
    [Route("api/v1.0/flight/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;
        public SearchController(IInventoryRepository repository)
        {
            _inventoryRepository = repository;
        }


        [HttpGet]
        public IActionResult Get(string fromplace, string toplace)
        {
            var flights = _inventoryRepository.GetAllFlightBasedOnPlaces(fromplace, toplace);
            if (flights.Count() == 0)
                return new NoContentResult();
            else
                return new OkObjectResult(flights);
        }
    }
}
