using System;

namespace Issues.Models
{
  public class Issue
  {
    public string Name { get; set; }
    public Guid Id { get; set; }
    public DateTime Added { get; set; }
    public int Count { get; set; }
  }
}
