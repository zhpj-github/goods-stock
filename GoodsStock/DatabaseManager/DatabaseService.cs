using GoodsStock.Helper;
using GoodsStock.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;

namespace GoodsStock.DatabaseManager
{
    public class DatabaseService
    {
        public DataTable GetCheckListBill() {
            string strSql = "select * from "+CheckListBill.TableName +" order by id desc";
            
            return DBConvertHelper.LoadDataTable(strSql);
        }
        public DataTable GetCheckBillDetail(int billId) {
            string strSql = @"
select A.id,C.code,C.name,C.unit,D.name as 类型名称,D.spec,A.raw_quantity,A.quantity 
from ((check_list_detail A left join check_list_bill as B on A.bill_id=B.id)
left join goods as C on A.goods_id=C.id)
left join goods_type as D on C.spec_id=D.id
where A.bill_id = "+billId;
            return DBConvertHelper.LoadDataTable(strSql);
        }
        public DataTable GetInitCheckDetail() {
            string strSql = @"
select A.id,a.id as goods_id,A.code,A.name,A.unit,B.name as 类型名称,B.spec,A.quantity as raw_quantity,0 as quantity
from goods A 
left join goods_type B on A.spec_id=B.id;
";
            return DBConvertHelper.LoadDataTable(strSql);
        }
        /// <summary>
        /// 获取商品清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetGoods() {
            string strSql = "select * from "+Goods.TableName;
            strSql = @"SELECT A.*,B.name as 规格 FROM goods A 
left join goods_type B on A.spec_id=B.id;";
            return DBConvertHelper.LoadDataTable(strSql);
        }
        /// <summary>
        /// 获取商品库存
        /// </summary>
        /// <returns></returns>
        public DataTable GetGoodsStock() {
            string strSql = "select * from stock";
            strSql = @"SELECT A.id,A.name as 品名,B.name as 类型,B.spec,A.quantity 
FROM goods A 
left join goods_type B on A.spec_id=B.id;";
            return DBConvertHelper.LoadDataTable(strSql);
        }
        /// <summary>
        /// 获取规格型号
        /// </summary>
        /// <returns></returns>
        public DataTable GetGoodsType() {
            string strSql = "select * from goods_type";
            return DBConvertHelper.LoadDataTable(strSql);
        }

        public int SaveCheckBill(CheckListBill bill) {
                string commandText = GetCommandText(bill, CheckListBill.TableName, out List<OleDbParameter> sqlParameters);
                int result = DBConvertHelper.ExecuteNonQuery(CommandType.Text, commandText, sqlParameters.ToArray());
                if (result > 0) {
                    string strSql = "select Max(id) from " + CheckListBill.TableName;
                    object objId = DBConvertHelper.ExecuteScalar(CommandType.Text, strSql);
                    int.TryParse(objId.ToString(), out int id);
                    foreach (DataRow row in bill.BillDetail.Rows) {
                        CheckListDetail detail = CommonHelper.SetModelByDataRow<CheckListDetail>(row);
                        detail.Id = -1;
                        detail.Bill_id = id;
                        commandText = GetCommandText(detail, CheckListDetail.TableName, out List<OleDbParameter> parameters);
                        int count = DBConvertHelper.ExecuteNonQuery(CommandType.Text, commandText, parameters.ToArray());
                        if (count > 0) {
                            Goods stock = new Goods {
                                Id = detail.Goods_id,
                                Quantity = detail.Quantity
                            };
                            commandText = GetCommandText(stock, Goods.TableName, out List<OleDbParameter> paras, "Quantity");
                            DBConvertHelper.ExecuteNonQuery(CommandType.Text, commandText, paras.ToArray());
                        }
                        result += count;
                    }
                }
                return result;
        }

        /// <summary>
        /// 保存规格型号
        /// </summary>
        /// <param name="goodsType"></param>
        /// <returns></returns>
        public int SaveGoodsType(GoodsType goodsType) {
            string commandText = GetCommandText(goodsType, GoodsType.TableName, out List<OleDbParameter> sqlParameters);
            return DBConvertHelper.ExecuteNonQuery(CommandType.Text, commandText, sqlParameters.ToArray());
        }
        /// <summary>
        /// 保存商品信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public int SaveGoods(Goods goods) {
            string commandText = GetCommandText(goods, Goods.TableName, out List<OleDbParameter> sqlParameters);
            return DBConvertHelper.ExecuteNonQuery(CommandType.Text, commandText, sqlParameters.ToArray());
        }

        public string GetCommandText<T,K>(T t, string tableName, out List<K> sqlParameters, params string[] fields) where K:new() {
            sqlParameters = new List<K>();
            Type type = t.GetType();
            PropertyInfo keyInfo = type.GetProperty("Id");
            object key = keyInfo.GetValue(t);
            int.TryParse(key.ToString(), out int id);

            string strSql = "insert into " + tableName + "(";
            string strValues = "Values (";
            if (id > 0) {
                strSql = "update " + tableName + " set ";
            }
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props) {
                DataOperateAttribute dataOperate = prop.GetCustomAttribute<DataOperateAttribute>();
                if (dataOperate == null) {
                    continue;
                }
                if (!dataOperate.IsWrite) {
                    continue;
                }
                if (fields != null && fields.Length > 0) {
                    if (!fields.Contains(prop.Name)) {
                        continue;
                    }
                }
                string fieldName = prop.Name;
                if (!string.IsNullOrWhiteSpace(dataOperate.FieldName)) {
                    fieldName = dataOperate.FieldName;
                }
                if (id > 0) {
                    if (string.Equals("id", fieldName, StringComparison.OrdinalIgnoreCase)) {
                        continue;
                    }
                    string concatStr = " {0}=@{0},";
                    concatStr = string.Format(concatStr, fieldName);
                    strSql += concatStr;
                } else {
                    string concatName = " {0},";
                    string concatValues = " @{0},";
                    concatName = string.Format(concatName, fieldName);
                    concatValues = string.Format(concatValues, fieldName);
                    strSql += concatName;
                    strValues += concatValues;
                }
                K parameter = new K();
                Type kType = typeof(K);
                PropertyInfo[] kInfos = kType.GetProperties();
                PropertyInfo infoName = kType.GetProperty("ParameterName");
                PropertyInfo infoValue = kType.GetProperty("Value");
                if (infoName != null&&infoValue!=null) {
                    infoName.SetValue(parameter, fieldName, null);
                    infoValue.SetValue(parameter, prop.GetValue(t), null);
                    sqlParameters.Add(parameter);
                }
            }
            strSql = strSql.Trim(',');
            strValues = strValues.Trim(',');
            if (id > 0) {
                strSql = strSql + " where id = " + id;
            } else {
                strSql = strSql + ")" + strValues + ")";
            }
            return strSql;
        }
    }
}
