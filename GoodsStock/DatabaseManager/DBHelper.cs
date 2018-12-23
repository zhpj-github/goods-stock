using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.DatabaseManager
{
    public class DBHelper
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public DBHelper() { }

        public static DataTable SelectDataTable(string commandText, params MySqlParameter[] pms) {
            DataTable dataTable = null;
            try {
                using (MySqlConnection conn = new MySqlConnection(connString)) {
                    using (MySqlCommand command = new MySqlCommand()) {
                        PrepareCommand(command, conn, null, CommandType.Text, commandText, pms);
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        command.Parameters.Clear();
                    }
                }
            }catch (Exception ex) {
                throw ex;
            }
            return dataTable;
        }
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters) {
            
            using (MySqlConnection connection = new MySqlConnection(connString)) {
                using (MySqlCommand cmd = new MySqlCommand()) {
                    PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters) {
            
            using (MySqlConnection conn = new MySqlConnection(connString)) {
                using (MySqlCommand cmd = new MySqlCommand()) {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }
        public static int ExecuteNonQuery(MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters) {

            using (MySqlCommand cmd = new MySqlCommand()) {
                PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms) {
            if (conn.State != ConnectionState.Open) {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null) {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null) {
                foreach (MySqlParameter parm in cmdParms) {
                    if ((parm.Direction == ParameterDirection.InputOutput || parm.Direction == ParameterDirection.Input) &&
                                    (parm.Value == null)) {
                        parm.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parm);
                }
            }
        }
    }
}
