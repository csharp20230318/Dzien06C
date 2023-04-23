// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{
    var posts = context.Posts.Include(o => o.Author).ToList();
    foreach (var item in posts)
    {
        Console.WriteLine($"{item.Title}, {item.Author.Name}");
    }
}

using (var context = new BlogDataContext())
{
    Author author1 = new Author { Name = "Henryk Sienkiewicz", Email = "hs@wp.pl" };
    context.Authors.Add(author1);

    Author author2 = new Author { Name = "Bolek Prus", Email = "bp@wp.pl" };
    context.Authors.Add(author2);

    var post1 = new Post
    {
        Title = "Ogniem i mieczem", Content="Polska szlachecka w pełni", Author=author1
    };
    var post2 = new Post
    {
        Title = "Lalka",
        Content = "Niedobra Iza",
        Author = author2
    };
    context.Posts.Add(post1);
    context.Posts.Add(post2);

    context.SaveChanges();

}



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
