using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using System.Transactions;
using DAL;

namespace FlightInventory.Controllers
{
    [Authorize]
    [Route("api/v1.0/flight/airline/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _InventorydbContext;
        public InventoryController(IInventoryRepository dbContext)
        {
            _InventorydbContext = dbContext;
        }

        [HttpPost]
        [Route("AddAirline")]
        public IActionResult AddAirLine([FromBody] TblAirLine tblAirLine)
        {
            using (var scope = new TransactionScope())
            {
                _InventorydbContext.AddAirlines(tblAirLine);
                scope.Complete();
                return Created("api/airline/inventory/", tblAirLine);
            }
        }

        [HttpPut]
        [Route("UpdateAirline")]
        public IActionResult UpdateAirline([FromBody] TblAirLine tblAirLine)
        {
            try
            {
                if (tblAirLine != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _InventorydbContext.BlockAirline(tblAirLine);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }


        [HttpPut]
        [Route("BlockAirline")]
        public IActionResult BlockAirline([FromBody] TblAirLine tblAirLine)
        {
            try
            {
                if (tblAirLine != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _InventorydbContext.BlockAirline(tblAirLine);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }


        [HttpPost]
        [Route("addInventory")]
        public IActionResult AddInventory([FromBody] TblInventory tblInventory)
        {
            using (var scope = new TransactionScope())
            {
                _InventorydbContext.AddInventory(tblInventory);
                scope.Complete();
                return Created("api/airline/inventory/", tblInventory);
            }
        }

    }
}
