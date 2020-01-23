using System;
using System.Threading.Tasks;
using Issues.Models;
using Issues.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Issues.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IssuesController : ControllerBase
  {
    private readonly IIssueRepository _repository;
    private readonly ILogger<IssuesController> _logger;

    public IssuesController(IIssueRepository repository, ILogger<IssuesController> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<Issue>> Post([FromBody] string name)
    {
      var issue = new Issue {Name = name, Added = DateTime.UtcNow, Count = 0, Id = Guid.NewGuid()};
      return Ok(await _repository.Insert(issue));
    }
  }
}
