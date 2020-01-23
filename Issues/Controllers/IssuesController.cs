using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Issues.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IssuesController : ControllerBase
  {
    private readonly ILogger<IssuesController> _logger;

    public IssuesController(ILogger<IssuesController> logger)
    {
      _logger = logger;
    }
  }
}
