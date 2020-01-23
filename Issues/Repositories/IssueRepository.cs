using System.Threading.Tasks;
using Issues.Models;

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
  }
}
