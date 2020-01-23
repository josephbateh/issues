using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Issues.Models;

namespace Issues.Repositories
{
  public interface IIssueRepository
  {
    Task<Issue> Insert(Issue issue);

    Task<List<Issue>> GetAll();
    
    Task<Issue> GetOne(Guid id);

    Task<Issue> Increment(Guid id);
  }
}
