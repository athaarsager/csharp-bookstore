using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csharp_bookstore.Models;

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

        return Ok(Books);
    }

}