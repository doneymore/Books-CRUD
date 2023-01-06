using Microsoft.EntityFrameworkCore;
using My_book.Data.Dto.RequestDto;
using My_book.Data.Dto.ResponseDto;
using My_book.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace My_book.Service
{
    public class BookService : IBookService
    {
        private const bool NotSame = false;
        public readonly AppDbContext _dbContext;
        public BookService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class AppResponse
        {
            //public object Data { get; set; }
            //public object Data2 { get; set; }
            //public DateTime Date { get; set; }
            public string ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public bool ResponseBoolMessage { get; set; }
        }

        public async Task<dynamic> AddBookAsync(Book newBook)
        {
            try
            {
                using (_dbContext)
                {
                    var rex = await _dbContext.Book.Where(x => x.Title.Equals(newBook.Title)).FirstOrDefaultAsync();
                    if (rex == null)
                    {
                        var newRecord = new Book
                        {
                            Title = newBook.Title,
                            Author = newBook.Author,
                            DateAdded = newBook.DateAdded,
                            DateRead = newBook.DateRead,
                            Description = newBook.Description,
                            Genre = newBook.Genre,
                            IsRead = newBook.IsRead,
                            Rate = newBook.Rate
                        };
                        _dbContext.Add(newRecord);
                        _dbContext.SaveChanges();
                        return new { responseCode = 00, responseMessage = "Successfully Created" };
                    }
                    else
                    {
                        return new { responseCode = 90, responseMessage = "Duplicate Record Exist" };
                    }
                }
            }
            catch (Exception es)
            {

                throw;
            }
        }

        public async Task<Response>AddBookAsync(NewBookRequest newBook)
        {
            return null;
        }

        public async Task<dynamic> ReadData()
        {
            var text = @"c:\Users\cazunna\Desktop\batchUpload.txt";
            var result = File.ReadAllText(text);
            return result;
        }

        public  AppResponse ComparingArrays()
        {
            int[] aValues = new int[] { 1, 2, 34, 4, 10, 6, 7, 81, 90, 20 };
            int[] bValues = new int[] { 11, 21, 3, 40, 12, 16, 7, 8, 9, 2 };

            
            var _ConcatArr = aValues.Union(bValues).ToArray();
            var pickDuplicate = _ConcatArr.GroupBy(x => x).Where(y => y.Count() > 1).Select(z => z.Key).ToList();
            foreach (var item in _ConcatArr)
            {
                return new AppResponse { ResponseBoolMessage = true, ResponseMessage = $"{item}" };
            }

            return new AppResponse { ResponseCode = "00" };
        }





        public AppResponse ComparingArr()
        {
            int[] aValues = new int[] { 1, 2, 34, 4, 10, 6, 7, 81, 90, 20 };
            int[] bValues = new int[] { 1, 2, 34, 4, 10, 6, 7, 81, 90, 20 };

            int countFilter = 0;
            if (aValues.Length == bValues.Length)
                return new AppResponse { ResponseBoolMessage = false, ResponseCode = "00" };
            for (int i = 0; i < aValues.Length; i++)
            {
                if (aValues[i] == bValues[i])

                    countFilter += aValues[i];
                return new AppResponse { ResponseBoolMessage = false, ResponseMessage = $"This {countFilter - bValues[1]} did not pass!!!" };

            }
            return new AppResponse { ResponseBoolMessage = false, ResponseCode = "00" };

        }


        public dynamic ComparingArray()
            {
            int[] aValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            //int[] bValues =   { 1, 2, 34, 4, 10, 6, 7, 81, 90, 20 };
            int[] bValues = { 5, 15, 3, 19, 35, 50, -1, 0 };

            List<string> obj = new List<string>();
            foreach (var item in bValues)
            {
                if (aValues.Contains(item))
                {
                    obj.Add($"{item}: True");
                }
                else
                {
                    obj.Add($"{item}: False");
                }
            }
            return obj;
            //var vals =  aValues.SequenceEqual(bValues);
            //return vals;

        }




        public dynamic ComparingArray0()
        {
            int[] aValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] bValues = { 5, 15, 3, 19, 35, 50, -1, 0 };

            HashSet<int> obj = new HashSet<int>(aValues);
            List<string> obj1 = new List<string>();

            foreach (int item in bValues)
            {
                if (obj.Contains(item))
                {
                    obj1.Add($"{item}: True");
                }
                else
                {
                    obj1.Add($"{item}: False");
                }
            }
            return obj1;
        }


    }
}
