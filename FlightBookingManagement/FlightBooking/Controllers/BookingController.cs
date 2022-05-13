using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingRepository _repository;
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allBookings = _repository.GetBookingDetail();
                if (allBookings != null)
                    return new OkObjectResult(allBookings);
                else
                    return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }

        [HttpPost]
        [Route("{flightid}")]
        public string Post([FromBody] BookingPassengerDetails passengerDetail)
        {
            using (var scope = new TransactionScope())
            {
                var res = _repository.AddPassengerBookingDetail(passengerDetail);
                scope.Complete();
                return res;
            }

        }


        [HttpGet]
        [Route("[Action]/{emailId}")]
        public IActionResult History(string emailId)
        {
            try
            {
                var history = _repository.GetUserHistory(emailId);
                if (history != null)
                    return new OkObjectResult(history);
                else
                    return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }


        [HttpDelete]
        [Route("[Action]/{pnr}")]
        public IActionResult Cancel(string pnr)
        {
            try
            {
                _repository.CancelBooking(pnr);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }

        [HttpGet]
        [Route("[Action]/{pnr}")]
        public IActionResult Ticket(string pnr)
        {
            try
            {
                var result = _repository.GetBookingDetailFromPNR(pnr);
                if (result != null)
                    return new OkObjectResult(result);
                else
                    return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }
    }
}
