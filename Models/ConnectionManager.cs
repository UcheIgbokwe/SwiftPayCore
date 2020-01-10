using NLog;
using Sybase.Data.AseClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SwiftPayCore.Models
{
    public class ConnectionManager
    {
        public static AseConnection GetAseConnection()
        {

            AseConnection conn = null;
            string Constr = null;
            try
            {
                Constr = ConfigurationManager.ConnectionStrings["LIVEDB"].ConnectionString;
                conn = new AseConnection(Constr);
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch (Exception ex)
            {
                Log.Logger.Log(LogLevel.Error, "Error in GetAseConnection method :" + ex.Message + "// " + ex.InnerException + "/n" + ex.StackTrace + "/n" + DateTime.Now);

            }


            return conn;


        }
        public static bool getOfflineStatus()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["IBANK"].ConnectionString;
            bool offline = false;
            try
            {
                using (AseConnection conn = new AseConnection(ConnectionString))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    using (AseCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select dbo.zsf_is_offline() as flag";
                        using (AseDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (reader["flag"].ToString().Trim() == "Y")
                                    {
                                        offline = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Log(LogLevel.Error, "Error calling getOfflineStatus 1 :" + ex.Message + "// " + ex.InnerException + "/n" + ex.StackTrace + "/n" + DateTime.Now);

                offline = true;
            }

            return offline;
        }
        
    }
}