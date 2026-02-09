public class TempClass
{
  public int Id { get; init; }
  public string Name { get; init; }

  public TempClass(int Id, string name)
  {
    this.Id = Id;     // BUG FIX
    this.Name = name;
  }
}

public record Temp
{
  public int Id { get; init; }
  public string Name { get; init; }

  public struct TempStruct
  {
    public int Id { get; init; }
    public string Name { get; init; }
  }
}
