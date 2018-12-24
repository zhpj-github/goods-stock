using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStock.DatabaseManager
{
    public class DBSQLiteHelper
    {
        private static readonly string connString = ConfigurationManager.AppSettings["sqliteConnString"];

        static DBSQLiteHelper() {
            try {
                using (SQLiteConnection conn = new SQLiteConnection(connString)) {
                    conn.Open();
                    using(SQLiteCommand cmmd=new SQLiteCommand()) {
                        cmmd.CommandText = "SELECT COUNT(*) FROM sqlite_master where type='table'";
                        cmmd.CommandType = CommandType.Text;
                        cmmd.Connection = conn;
                        object obj = cmmd.ExecuteScalar();
                        if ((long)obj<=0) {
                            string path = AppDomain.CurrentDomain.BaseDirectory + @"Helper\sql.sql";
                            string createSql = File.ReadAllText(path);
                            cmmd.CommandText = createSql;
                            int count = cmmd.ExecuteNonQuery();
                        }
                    }
                }
            }catch(Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static DataTable SelectDataTable(string commandText, params SQLiteParameter[] pms) {
            DataTable dataTable = null;
            try {
                using (SQLiteConnection conn = new SQLiteConnection(connString)) {
                    using (SQLiteCommand command = new SQLiteCommand()) {
                        PrepareCommand(command, conn, null, CommandType.Text, commandText, pms);
                        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
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
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters) {
            
            using (SQLiteConnection connection = new SQLiteConnection(connString)) {
                using (SQLiteCommand cmd = new SQLiteCommand()) {
                    PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                    object val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters) {
            
            using (SQLiteConnection conn = new SQLiteConnection(connString)) {
                using (SQLiteCommand cmd = new SQLiteCommand()) {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
            }
        }
        public static int ExecuteNonQuery(SQLiteConnection conn, SQLiteTransaction trans, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters) {

            using (SQLiteCommand cmd = new SQLiteCommand()) {
                PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, CommandType cmdType, string cmdText, SQLiteParameter[] cmdParms) {
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
                foreach (SQLiteParameter parm in cmdParms) {
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
