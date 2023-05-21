using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get()
        {
            return 10;
        }
    }
}
