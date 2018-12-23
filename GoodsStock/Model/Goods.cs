using GoodsStock.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.Model
{
    public class Goods
    {
        #region 构造函数
        /// <summary>
        /// 实体 商品清单
        /// </summary>
        public Goods() { }

        #endregion

        #region 公共属性
        /// <summary>
        /// 主键 主键(NOT NULL)
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 编码
        /// </summary>
        [DataOperate()]
        public string Code { set; get; }
        /// <summary>
        /// 商品名称(NOT NULL)
        /// </summary>
        [DataOperate()]
        public string Name { set; get; }
        /// <summary>
        /// 规格ID，即单位（箱、瓶等）(NOT NULL)
        /// </summary>
        [DataOperate()]
        public int Spec_id { set; get; }
        /// <summary>
        /// 最小单位
        /// </summary>
        [DataOperate()]
        public Int32 Unit { set; get; }
        /// <summary>
        /// remark
        /// </summary>
        [DataOperate()]
        public string Remark { set; get; }
        /// <summary>
        /// disable
        /// </summary>
        [DataOperate()]
        public bool Disable { set; get; }
        [DataOperate()]
        public decimal Quantity { set; get; }
        #endregion

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 商品清单
        /// </summary>
        public static readonly string TableName = "goods";
        #endregion
    }
}
