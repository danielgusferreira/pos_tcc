using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlySneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected int? GetCurrentUserId()
        {
            var sid = this.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sid");
            if (sid != null)
            {
                return int.Parse(sid.Value);
            }

            return null;
        }
    }
}
