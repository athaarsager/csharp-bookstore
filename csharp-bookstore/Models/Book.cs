// Got namespace name from project name
namespace csharp_bookstore.Models;

// book table
public class Book
{
    public int Id {get; set;}
    public string? Title { get; set; }
    public string? Author { get; set; }
    // 1-5
    public int Rating { get; set; }
}