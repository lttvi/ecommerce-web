using Ecom.WebAPI.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebAPI.Controllers
{
    [Authorize(Roles = UserRoles.Customer)]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("info")]
        public Task<IActionResult> GetCustomerInfo()
        {
            throw new NotImplementedException();
        }

       
    }
}
