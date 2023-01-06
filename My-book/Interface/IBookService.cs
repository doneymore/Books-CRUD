using My_book.Data.Models;
using System.Threading.Tasks;
using static My_book.Service.BookService;

namespace My_book.Service
{
    public interface IBookService
    {
        Task<dynamic> AddBookAsync(Book newBook);
        Task<dynamic> ReadData();
        AppResponse ComparingArrays();
        dynamic ComparingArray();
        AppResponse ComparingArr();
    }
}