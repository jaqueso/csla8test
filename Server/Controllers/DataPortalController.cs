using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPortalController : Csla.Server.Hosts.HttpPortalController
    {
        public DataPortalController(Csla.ApplicationContext context) : base(context)
        {
        }

        [HttpGet]
        public string Get()
        {
            return "Running";
        }

        public override Task PostAsync([FromQuery] string operation)
        {
            var result = base.PostAsync(operation);
            return result;
        }
    }
}
