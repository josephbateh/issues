using Microsoft.EntityFrameworkCore;

namespace Issues.Models
{
  public class IssueContext : DbContext
  {
    public IssueContext(DbContextOptions<IssueContext> options)
      : base(options)
    {
    }

    public DbSet<Issue> Issues { get; set; }
  }
}
