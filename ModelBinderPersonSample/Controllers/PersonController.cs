using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinderPersonSample.Models;

namespace ModelBinderPersonSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetPerson([FromBody]Person person)
        {
            if (person is Teacher)
            {
                return Ok("It is teacher");
            }
            if (person is Student)
            {
                return Ok("It is Student");
            }

            return Ok(person);
        }
    }
}
