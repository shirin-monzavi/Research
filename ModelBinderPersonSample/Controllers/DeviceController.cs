using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinderPersonSample.Models;

namespace ModelBinderPersonSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        [HttpPost]
        public IActionResult Test([FromBody] Device dto)
        {
            if (dto is Laptop)
            {
                return Ok("Laptop");
            }

            if (dto is SmartPhone)
            {
                return Ok("SmartPhone");
            }
            throw new Exception("Sub type has not been found");
        }
    }
}
