public class Query
{
    public string Hello(string name = "World")
        => $"Hello, {name}!";

   public IEnumerable<Book> GetBooks()
   {
       var author = new Author("Jon Skeet");
       yield return new Book("C# in Depth", author);
       yield return new Book("C# in Depth 2nd Edition", author);
   }
}

public record Author(string Name);

public record Book(string Title, Author Author);
