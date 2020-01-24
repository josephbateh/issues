using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Issues.Models;
using Microsoft.EntityFrameworkCore;

namespace Issues.Repositories
{
  public class IssueRepository : IIssueRepository
  {
    private readonly IssueContext _context;

    public IssueRepository(IssueContext context)
    {
      _context = context;
    }

    public async Task<Issue> Insert(Issue issue)
    {
      _context.Add(issue);
      await _context.SaveChangesAsync();
      return issue;
    }

    public async Task<List<Issue>> GetAll()
    {
      return await _context.Issues.ToListAsync();
    }

    public async Task<Issue> GetOne(Guid id)
    {
      return await _context.Issues.FirstOrDefaultAsync(issue => issue.Id == id);
    }

    public async Task<Issue> Increment(Guid id)
    {
      var issue = await GetOne(id);
      issue.Count += 1;
      _context.Issues.Update(issue);
      await _context.SaveChangesAsync();
      return issue;
    }

    public async Task<Issue> DeleteOne(Guid id)
    {
      var issue = await GetOne(id);
      _context.Issues.Remove(issue);
      await _context.SaveChangesAsync();
      return issue;
    }
  }
}
