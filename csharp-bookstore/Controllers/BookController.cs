using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csharp_bookstore.Models;
using System.Diagnostics.CodeAnalysis;

namespace csharp_bookstore.Controllers;

// From Chat GPT:
// These lines are attributes applied to the BookController class. 
// [ApiController] indicates that the controller is responsible for handling HTTP API requests. 
// [Route("/api/[controller]")] specifies the route template for the controller. 
// The [controller] token in the route template is replaced with the controller name, which in this case is Book.

[ApiController]
[Route("/api/[controller]")]

// ControllerBase is provided by AspNetCore
public class BookController : ControllerBase
{
    private readonly ApplicationContext context;

    public BookController(ApplicationContext c)
    {
        context = c;
    }

    [HttpGet] // Get all books

    public IActionResult GetBooks()
    {
        List<Book> Books = context.Book.ToList();

        // Ok(Books) returns an OkObjectResult, 
        // which represents an HTTP 200 response with a JSON object containing the list of books.
        return Ok(Books);
    }

    // Get a book by id. Just using this for the return in the Post
    // That way, the 201 message after the Post queries and returns the id of the book created
    [HttpGet("{BookId}")] 

    public IActionResult GetBook(int BookId)
    {
        Book Book = context.Book.SingleOrDefault(book => book.Id == BookId);

        return Ok(Book);
    }

    [HttpPost] // Post a new book

    public IActionResult AddBook(Book Book)
    {
        context.Book.Add(Book);
        context.SaveChanges();

        // parameters are: string actionName, object routeValues (that is, where to look),
        // object value
        return CreatedAtAction(nameof(GetBook), new { Id = Book.Id}, Book);
    }

}