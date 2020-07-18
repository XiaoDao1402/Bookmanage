using Bll;
using Entity;
using System;
using System.Collections.Generic;


namespace BLL.Book
{
    public class BookBLL : BaseBLL
    {
        #region 新增

        /// <summary>
        /// 新增图书
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(BookEntity book)
        {
            try
            {
                dal.TEntity<BookEntity>().AsInsertable(book).ExecuteReturnEntity();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据主键id删除图书
        /// </summary>
        /// <param name="bookId"></param>
        public int DeleteBook(int bookId)
        {
            try
            {
                int result = dal.TEntity<BookEntity>()
                    .AsDeleteable()
                    .Where(it => it.BookId == bookId)
                    .ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 修改

        /// <summary>
        /// 根据主键id修改图书信息
        /// </summary>
        /// <param name="book"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public int UpdateBook(BookEntity book, int bookId)
        {
            try
            {
                int result = dal.TEntity<BookEntity>()
                    .AsUpdateable(book)
                    .Where(it => it.BookId == bookId)
                    .ExecuteCommand();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询图书
        /// </summary>
        /// <returns></returns>
        public List<BookEntity> QueryBook()
        {
            try
            {
                List<BookEntity> list = dal.TEntity<BookEntity>().AsQueryable().ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
