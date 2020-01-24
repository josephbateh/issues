using System;
using System.Collections.Generic;
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

    [HttpGet]
    public async Task<ActionResult<List<Issue>>> GetAll()
    {
      return Ok(await _repository.GetAll());
    }

    [HttpPost]
    public async Task<ActionResult<Issue>> Post([FromBody] string name)
    {
      var issue = new Issue {Name = name, Added = DateTime.UtcNow, Count = 0, Id = Guid.NewGuid()};
      return Ok(await _repository.Insert(issue));
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<Issue>> Increment(Guid id)
    {
      return Ok(await _repository.Increment(id));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Issue>> GetOne(Guid id)
    {
      return Ok(await _repository.GetOne(id));
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Issue>> DeleteOne(Guid id)
    {
      return Ok(await _repository.DeleteOne(id));
    }
  }
}
