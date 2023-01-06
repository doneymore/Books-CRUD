using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_book.Data.Dto.RequestDto
{
    public class NewBookRequest
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
       
       
    }
}
