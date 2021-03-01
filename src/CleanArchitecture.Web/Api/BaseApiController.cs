using Microsoft.AspNetCore.Mvc;

namespace Rel.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
