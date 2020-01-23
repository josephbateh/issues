using System.Threading.Tasks;
using Issues.Models;

namespace Issues.Repositories
{
  public interface IIssueRepository
  {
    Task<Issue> Insert(Issue issue);
  }
}
