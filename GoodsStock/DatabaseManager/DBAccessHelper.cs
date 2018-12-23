using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.DatabaseManager
{
    public class DBAccessHelper
    {
        private static readonly string connString = ConfigurationManager.AppSettings["connectionString"];

        public DBAccessHelper() { }

        public static DataTable SelectDataTable(string commandText, params OleDbParameter[] pms) {
            DataTable dataTable = null;
            try {
                using (OleDbConnection conn = new OleDbConnection(connString)) {
                    using (OleDbCommand command = new OleDbCommand()) {
                        PrepareCommand(command, conn, null, CommandType.Text, commandText, pms);
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
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
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters) {
            
            using (OleDbConnection connection = new OleDbConnection(connString)) {
                using (OleDbCommand cmd = new OleDbCommand()) {
                    PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters) {
            
            using (OleDbConnection conn = new OleDbConnection(connString)) {
                using (OleDbCommand cmd = new OleDbCommand()) {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }
        public static int ExecuteNonQuery(OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters) {

            using (OleDbCommand cmd = new OleDbCommand()) {
                PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms) {
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
                foreach (OleDbParameter parm in cmdParms) {
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
