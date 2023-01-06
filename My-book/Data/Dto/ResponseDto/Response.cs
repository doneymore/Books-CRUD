using My_book.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_book.Data.Dto.ResponseDto
{
    public class Response
    {
        public object Data { get; set; }
        public Book BookData { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public DateTime Date { get; set; }
    }
}
