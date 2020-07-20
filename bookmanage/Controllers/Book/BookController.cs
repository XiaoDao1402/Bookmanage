using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Book;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace BookManage.Controllers.Book{

    
    /// <summary>
    /// 图书管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController:ControllerBase
    {
        BookBLL bookBll =null;

        public BookController() {
            bookBll = new BookBLL();
        }

        /// <summary>
        /// 新增图书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookEntity book)
        {
            try
            {
                bookBll.AddBook(book);
                return Ok(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// 根据主键Id删除图书
        /// </summary>
        /// <param name="bookId"></param>
        [HttpGet("DeleteBook")]
        public int DeleteBook(int bookId) {
            try
            {
                int result=bookBll.DeleteBook(bookId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据主键Id修改图书信息
        /// </summary>
        /// <param name="book"></param>
        /// <param name="bookId"></param>
        [HttpPost("UpdateBook")]
        public int UpdateBook(BookEntity book,int bookId) {
            try
            {
               int result=bookBll.UpdateBook(book,bookId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询图书
        /// </summary>
        /// <returns></returns>
        [HttpGet("QueryBook")]
        public List<BookEntity> QueryBook()
        {
            try
            {
                List<BookEntity> list = bookBll.QueryBook();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
