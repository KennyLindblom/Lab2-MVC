using Microsoft.AspNetCore.Mvc;
using NewLab1_MinimalAPI.Models;

using Newtonsoft.Json;
using System.Collections.Generic;
using Web_Book.Models;
using Web_Book.Services;

namespace Web_Book.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        public async Task<IActionResult> ViewBooks()
        {
            //List<Book> list = new List<Book>();

            //var response = await _bookService.GetAllBooks<ResponseDTO>();
            //if (response != null && response.IsSuccess)
            //{
            //    list = JsonConvert.DeserializeObject<List<Book>>(Convert.ToString(response.Result));
            //    return View(list);
            //}
            //return View(list);
            var response = await _bookService.GetAllBooks<List<Book>>();
            if (response != null)
            {
                return View(response);

            }
            return View(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> ViewOneBook(int id)
        {
            //var response = await _bookService.GetBookById<List<Book>>(id);
            //if(response != null)
            //{
            //    return View(response);
            //}
            //return View(response);

            var book = await _bookService.GetBookById<Book>(id);

            if (book != null)
            {
                return View(book);
            }
            else
            {
                // Optionally, you can handle the case where the book is not found,
                // such as returning a different view or a "not found" message.
                Console.WriteLine("Igen bok");
                return View();
            }
        }

        
        [HttpGet]
        public IActionResult AddBook()
        {
            return View("AddBook");
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var response = await _bookService.CreateBook<Book>(book);
            if (response != null)
            {
                return RedirectToAction(nameof(ViewBooks));
            }
            return View("AddBook");
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook<Book>(id);
            if (response != null)
            {
                return RedirectToAction(nameof(ViewBooks));
            }
            return RedirectToAction(nameof(ViewBooks));
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var response = await _bookService.GetBookById<Book>(id);
            return View("UpdateBook", response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book book)
        {

            var response = await _bookService.UpdateBook<Book>(book);
            if (response != null)
            {
                return RedirectToAction(nameof(ViewBooks));
            }
            return RedirectToAction(nameof(ViewBooks));
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchBook(string searchString)
        {
            var response = await _bookService.SearchBook<List<Book>>(searchString);
            if (response != null)
            {
                return View("SearchBook", response);
            }
            return View("SearchBook");
        }
    }
}
