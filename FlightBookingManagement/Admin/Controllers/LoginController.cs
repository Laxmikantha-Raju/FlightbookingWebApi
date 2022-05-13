using DAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    //[Route("api/v1.0/flight/admin/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;
        private readonly FlightTicketBookingDBContext _dbContext;
        public LoginController(IJWTManagerRepository jWTManager, FlightTicketBookingDBContext dbContext)
        {
            iJWTManager = jWTManager;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(TblUserDetail user)
        {
            try
            {
                IEnumerable<TblUserDetail> tblusr = _dbContext.TblUserDetails.Where(x => x.UserEmailid == user.UserEmailid && x.UserPassword == user.UserPassword);
                if (tblusr.ToList().Count == 0)
                {
                    return Unauthorized();
                }
                var token = iJWTManager.Authenticate(user);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(TblUserDetail tblUserdetail)
        {
            try
            {
                IEnumerable<TblUserDetail> tblusr = _dbContext.TblUserDetails.Where(x => x.UserEmailid == tblUserdetail.UserEmailid && x.UserPassword == tblUserdetail.UserPassword);
                if (tblusr.ToList().Count == 0)
                {
                    return Unauthorized();
                }
                var token = iJWTManager.Authenticate(tblUserdetail);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Response = "Error", ResponseMessage = ex.Message });
            }
        }
    }
}
