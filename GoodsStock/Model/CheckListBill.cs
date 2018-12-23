using GoodsStock.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.Model
{
    public class CheckListBill
    {
        #region 构造函数
        /// <summary>
        /// 实体 盘点单
        /// </summary>
        public CheckListBill() { }

        #endregion

        #region 公共属性
        /// <summary>
        /// 主键 id(NOT NULL)
        /// </summary>
        public Int32 Id { set; get; }
        /// <summary>
        /// 盘点时间(NOT NULL)
        /// </summary>
        [DataOperate(IsWrite =false)]
        public DateTime Check_time { set; get; } = DateTime.Now;
        /// <summary>
        /// 备注
        /// </summary>
        [DataOperate()]
        public string Remark { set; get; }
        /// <summary>
        /// 单据明细
        /// </summary>
        public DataTable BillDetail { set; get; }
        #endregion

        #region 公共静态只读属性
        /// <summary>
        /// 表名 表原信息描述: 盘点单
        /// </summary>
        public static readonly string TableName = "check_list_bill";
        #endregion
    }
}
