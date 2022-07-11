using Adminmicroservices.Services;
using Adminmicroservices.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminmicroservices.Controllers
{
    [Route("api/1.0/flight/admin")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        IJWTMangerRepository iJWTMangerRepository;

        public LoginController(IJWTMangerRepository _iJWTMangerRepository)
        {

            iJWTMangerRepository = _iJWTMangerRepository;
        }
        [HttpPost]
        [Route("login")]

        public IActionResult Login(AdminLoginViewModel adminLoginViewModel)
        {
            var token = iJWTMangerRepository.Authenticate(adminLoginViewModel, false);
            if (token == null)
            {
                return Unauthorized();

            }
            return Ok(token);
        }
        [HttpPost]

        public IActionResult Register(AdminLoginViewModel loginViewModel)
        {
            var token = iJWTMangerRepository.Authenticate(loginViewModel, true);
            if (token == null)
            {
                return Unauthorized();

            }
            return Ok(token);
        }
        [HttpGet("findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(iJWTMangerRepository.FindAll());

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}





