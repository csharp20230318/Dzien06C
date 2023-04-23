// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

Console.WriteLine("Hello, World!");

public class BlogDataContext : DbContext
{
    static readonly string connectionString = "server=localhost;port=3306;user=root;password=root;database=blog;";

    public DbSet<Author> Authors { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

}

public class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public Author Author { get; set; }

}

public class Author
{
    public int AuthorId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public List<Post>? Posts { get; set; }
}
