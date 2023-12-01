# Sample

## How do I get started
```csharp
class Program
{
  static void Main(string[] args)
  {
    var serviceCollection = new ServiceCollection();
    serviceCollection.AddDeepDiff(typeof(Program).Assembly);
  ...
  }
}
```
