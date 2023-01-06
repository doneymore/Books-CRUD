using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_book.Data.Models;
using My_book.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace My_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public readonly IBookService _bookService;


        [HttpPost, Route("AddBook")]
        public async Task<IActionResult> AddBook(Book books)
        {
            var response = await _bookService.AddBookAsync(books);
            return Ok(response);
        }



        [HttpGet, Route("ReadData")]
        public async Task<IActionResult> ReadData()
        {
            var result = await _bookService.ReadData();
            return Ok(result);
        }

        [HttpGet, Route("Compare")]

        public IActionResult Compare()
        {
            var result = _bookService.ComparingArrays();
            return Ok(result);
        } 
        [HttpGet, Route("Compares")]

        public IActionResult Compares()
        {
            var result = _bookService.ComparingArray();
            return Ok(result);
        }

        [HttpGet, Route("ComparesArr")]

        public IActionResult ComparesArr()
        {
            var result = _bookService.ComparingArr();
            return Ok(result);
        }
    }
}
