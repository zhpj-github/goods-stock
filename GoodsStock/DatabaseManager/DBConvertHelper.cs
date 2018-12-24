using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.DatabaseManager
{
    public class DBConvertHelper
    {
        private static readonly string databaseType = ConfigurationManager.AppSettings["databaseType"];
        public static DataTable LoadDataTable(string commondText,params DbParameter[] dbParameters) {
            DataTable dt = null;
            switch (databaseType.ToLower()) {
                case "mysql":
                    MySqlParameter[] mysqls = ConvertParamType<MySqlParameter>(dbParameters);
                    dt = DBHelper.SelectDataTable(commondText, mysqls);
                    break;
                case "sqlite":
                    SQLiteParameter[] sQLites = ConvertParamType<SQLiteParameter>(dbParameters);
                    dt = DBSQLiteHelper.SelectDataTable(commondText, sQLites);
                    break;
                case "access":
                    OleDbParameter[] oleDbs = ConvertParamType<OleDbParameter>(dbParameters);
                    dt = DBAccessHelper.SelectDataTable(commondText, oleDbs);
                    break;
            }
            return dt;
        }
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params DbParameter[] commandParameters) {
            int result = -1;
            switch (databaseType.ToLower()) {
                case "mysql":
                    MySqlParameter[] mysqls = ConvertParamType<MySqlParameter>(commandParameters);
                    result = DBHelper.ExecuteNonQuery(cmdType,cmdText, mysqls);
                    break;
                case "sqlite":
                    SQLiteParameter[] sQLites = ConvertParamType<SQLiteParameter>(commandParameters);
                    result = DBSQLiteHelper.ExecuteNonQuery(cmdType, cmdText, sQLites);
                    break;
                case "access":
                    OleDbParameter[] oleDbs = ConvertParamType<OleDbParameter>(commandParameters);
                    result = DBAccessHelper.ExecuteNonQuery(cmdType, cmdText, oleDbs);
                    break;
            }
            return result;
        }
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters) {
            object result = null;
            switch (databaseType.ToLower()) {
                case "mysql":
                    MySqlParameter[] mysqls = ConvertParamType<MySqlParameter>(commandParameters);
                    result = DBHelper.ExecuteScalar(cmdType, cmdText, mysqls);
                    break;
                case "sqlite":
                    SQLiteParameter[] sQLites = ConvertParamType<SQLiteParameter>(commandParameters);
                    result = DBSQLiteHelper.ExecuteScalar(cmdType, cmdText, sQLites);
                    break;
                case "access":
                    OleDbParameter[] oleDbs = ConvertParamType<OleDbParameter>(commandParameters);
                    result = DBAccessHelper.ExecuteScalar(cmdType, cmdText, oleDbs);
                    break;
            }
            return result;
        }

        private static T[] ConvertParamType<T>(params DbParameter[] dbParameters) where T : new() {
            if (dbParameters == null || dbParameters.Length <= 0) {
                return default(T[]);
            }
            T[] t = new T[dbParameters.Length];
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();
            Type pType = typeof(DbParameter);
            PropertyInfo[] pInfos = pType.GetProperties();
            foreach (PropertyInfo prop in propertyInfos) {
                PropertyInfo info = pInfos.FirstOrDefault(p => p.Name == prop.Name);
                if (info != null) {
                    for (int i = 0; i < t.Length; i++) {
                        if (t[i] == null) {
                            t[i] = new T();
                        }
                        object value = info.GetValue(dbParameters[i]);
                        if (string.Equals("access", databaseType, StringComparison.OrdinalIgnoreCase)) {
                            if (value.GetType() == typeof(DateTime)) {
                                value = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                        prop.SetValue(t[i], value, null);
                    }
                }
            }
            return t;
        }
    }
}
