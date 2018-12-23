using GoodsStock.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.Model
{
    public class GoodsType
    {
        
        public int Id { get; set; }
        [DataOperate()]
        public string Name { get; set; }
        [DataOperate()]
        public string Spec { get; set; }
        [DataOperate()]
        public bool Disable { get; set; }

        public static readonly string TableName = "goods_type";
        public GoodsType() { }

    }
}
