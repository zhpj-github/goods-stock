using GoodsStock.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.Model
{
    public class CheckListDetail
    {
        #region 构造函数
        /// <summary>
        /// 实体 盘点明细
        /// </summary>
        public CheckListDetail() { }

        #endregion
        #region 私有变量
        #endregion

        #region 公共属性
        /// <summary>
        /// 主键 id(NOT NULL)
        /// </summary>
        public Int32 Id { set; get; }
        /// <summary>
        /// 单据ID(NOT NULL)
        /// </summary>
        [DataOperate()]
        public Int32 Bill_id { set; get; }
        /// <summary>
        /// 商品ID(NOT NULL)
        /// </summary>
        [DataOperate()]
        public Int32 Goods_id { set; get; }
        /// <summary>
        /// 当前盘点库存
        /// </summary>
        [DataOperate()]
        public decimal Quantity { set; get; }
        /// <summary>
        /// 原库存
        /// </summary>
        [DataOperate()]
        public decimal Raw_quantity { set; get; }
        #endregion

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 盘点明细
        /// </summary>
        public static readonly string TableName = "check_list_detail";
        #endregion
    }
}
