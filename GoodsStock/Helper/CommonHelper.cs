using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodsStock.Helper
{
    public class CommonHelper
    {
        public static void SetDataTableCaption(DataTable dataTable) {
            foreach (DataColumn col in dataTable.Columns) {
                switch (col.ColumnName.ToLower()) {
                    case "name":
                        col.Caption = "名称";
                        break;
                    case "disable":
                        col.Caption = "是否禁用";
                        break;
                    case "code":
                        col.Caption = "编码";
                        break;
                    case "spec":
                        col.Caption = "规格";
                        break;
                    case "amount":
                        col.Caption = "数量";
                        break;
                    case "unit":
                        col.Caption = "最小单位数";
                        break;
                    case "remark":
                        col.Caption = "备注";
                        break;
                    case "quantity":
                        col.Caption = "库存量";
                        break;
                    case "raw_quantity":
                        col.Caption = "原库存量";
                        break;
                    case "check_time":
                        col.Caption = "盘点时间";
                        break;
                    default:
                        break;
                }
            }
        }
        public static void SetHideIdColumnByDataTable(DataGridView dataGridView,DataTable dataTable) {
            SetDataTableCaption(dataTable);
            foreach (DataColumn col in dataTable.Columns) {
                dataGridView.Columns[col.ColumnName].HeaderText = col.Caption;
                if (col.ColumnName.ToLower().Contains("id")) {
                    dataGridView.Columns[col.ColumnName].Visible = false;
                }
            }
        }

        public static T SetModelByDataRow<T>(DataRow row) where T:new() {
            T t = new T();
            Type type = t.GetType();
            PropertyInfo[] infos = type.GetProperties();
            DataColumnCollection dcc = row.Table.Columns;
            foreach (PropertyInfo property in infos) {
                if (dcc.Contains(property.Name)) {
                    object value = row[property.Name];
                    if (!property.PropertyType.IsGenericType) {
                        //非泛型
                        property.SetValue(t, Convert.ChangeType(value, property.PropertyType), null);
                    } else {
                        //泛型Nullable<>
                        Type genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>)) {
                            property.SetValue(t, Convert.ChangeType(value, Nullable.GetUnderlyingType(property.PropertyType)), null);
                        }
                    }
                }
            }
            return t;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DataOperateAttribute : Attribute
    {
        /// <summary>
        /// 数据库字段名
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 是否需要跟新数据库表值
        /// </summary>
        public bool IsWrite { get; set; } = true;
        public DataOperateAttribute() { }
        
    }
}
