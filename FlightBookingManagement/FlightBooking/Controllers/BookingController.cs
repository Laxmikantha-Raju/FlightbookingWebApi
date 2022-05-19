using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace FlightBooking.Controllers
{
    //[Authorize]
    [Route("api/v1.0/flight/airline/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingRepository _repository;
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllBooking")]
        public IActionResult GetAllBooking()
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
        //[Route("{flightid}")]
        [Route("BookTicket")]
        public string BookTicket([FromBody] BookingPassengerDetails passengerDetail)
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
        [HttpPut]
        [Route("[Action]/{Id}")]
        public IActionResult CancelById(int Id)
        {
            try
            {
                _repository.CancelById(Id);
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
        [HttpGet]
        [Route("discount")]
        public async Task<IActionResult> GetDiscountList(int id)
        {
            var discountList = await _repository.GetDiscountList();

            return Ok(discountList);

        }
        //[HttpGet]
        //[Route("[Action]/{id}")]
        //public IActionResult GetAllBookingById(int id)
        //{
        //    try
        //    {
        //        var result = _repository.GetAllBookingById(id);
        //        if (result != null)
        //            return new OkObjectResult(result);
        //        else
        //            return new NotFoundResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
        //    }
        //}
    }
}
