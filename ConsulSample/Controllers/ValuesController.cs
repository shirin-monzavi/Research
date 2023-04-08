using Microsoft.AspNetCore.Mvc;

namespace ConsulSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET api/values  
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //to show the result of different usges   
            return new string[] { _configuration["FeatureManagement:Beta"] };
        }

    }
}
