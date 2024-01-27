using Microsoft.AspNetCore.Mvc;

namespace CitiesManagerWebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        
    }
}
