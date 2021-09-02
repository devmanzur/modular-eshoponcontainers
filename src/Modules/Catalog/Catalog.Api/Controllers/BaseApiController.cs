using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        
    }
}