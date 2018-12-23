using GoodsStock.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.Model
{
    public class Stock
    {
        #region 构造函数
        /// <summary>
        /// 实体 库存表
        /// </summary>
        public Stock() { }

        #endregion

        #region 公共属性
        /// <summary>
        /// 主键 id(NOT NULL)
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 商品ID(NOT NULL)
        /// </summary>
        [DataOperate()]
        public int Goods_id { set; get; }
        /// <summary>
        /// 库存数量
        /// </summary>
        [DataOperate()]
        public decimal Amount { set; get; }
        #endregion

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 库存表
        /// </summary>
        public static readonly string TableName = "stock";
        #endregion
    }
}
