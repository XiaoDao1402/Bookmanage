using System;

namespace Entity {
    /// <summary>
    /// 图书实体
    /// </summary>
    [SqlSugar.SugarTable("t_book")]
    public class BookEntity {
        /// <summary>
        /// 图书主键
        /// </summary>
        public int BookId { get; set; }
        
        /// <summary>
        /// 图书名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图书价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifyDate { get; set; }
    }
}
