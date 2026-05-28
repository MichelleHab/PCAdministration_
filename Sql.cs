using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace PCAdministration_
{
    internal class Sql
    {
        public static DataTable Query(string request, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(ConnectionStringBuilding.ConnectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand(request, mySqlConnection))
                    {
                        if (parameters != null)
                            mySqlCommand.Parameters.AddRange(parameters);

                        using (DataTable dt = new DataTable())
                        {
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(mySqlCommand))
                            {
                                adapter.Fill(dt);
                            }
                            return dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    SqlRequestErrors(ex);
                    return null;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        public static object QueryOneReturn(string request, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(ConnectionStringBuilding.ConnectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand(request, mySqlConnection))
                    {
                        if (parameters != null)
                            mySqlCommand.Parameters.AddRange(parameters);

                        using (MySqlDataReader rdr = mySqlCommand.ExecuteReader())
                        {
                            if (rdr.Read())
                                return rdr[0];
                            else
                                return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    SqlRequestErrors(ex);
                    return null;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        public static bool QueryNonReturns(string request, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(ConnectionStringBuilding.ConnectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand(request, mySqlConnection))
                    {
                        if (parameters != null)
                            mySqlCommand.Parameters.AddRange(parameters);

                        int rowsAffected = mySqlCommand.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    SqlRequestErrors(ex);
                    return false;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }
        public static string SqlRequestErrors(Exception ex)
        {
            var result = "Message: " + ex.Message;
#if DEBUG
            /*if (MessageBox.Show(result, "!SqlRequest! -> exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Environment.Exit(0);*/
#endif
            return result;
        }
        public static MySqlConnectionStringBuilder ConnectionStringBuilding = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "",
            Database = "mysql",
            ConnectionTimeout = 5,
            CharacterSet = "utf8mb4"
        };
    }
}
