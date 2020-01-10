using SwiftPayCore.Log;
using SwiftPayCore.Models;
using Sybase.Data.AseClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftPayCore.Implementation
{
    public class CustomerImplementation
    {
        public static List<zib_mobil_custom_custs> GetCustomers()
        {
            List<zib_mobil_custom_custs> allCustomers = new List<zib_mobil_custom_custs>();

            try
            {
                using (AseConnection conn = ConnectionManager.GetAseConnection())
                {
                    using (AseCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = $"select * from zenbase..zib_mobil_custom_custs";
                        using (AseDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    zib_mobil_custom_custs profile = new zib_mobil_custom_custs();

                                    profile.customer_id = int.Parse(reader["customer_id"].ToString().Trim());
                                    profile.customer_name = reader["customer_name"].ToString() == null ? "NA" : reader["customer_name"].ToString().Trim();
                                    profile.empl_id = int.Parse(reader["empl_id"].ToString().Trim());
                                    profile.back_date_tran = char.Parse(reader["back_date_tran"].ToString()).Equals(' ') ? 'Y' : char.Parse(reader["back_date_tran"].ToString().Trim());
                                    profile.create_dt = DateTime.Parse(reader["create_dt"].ToString().Trim()) == null ? DateTime.Now : DateTime.Parse(reader["create_dt"].ToString().Trim());
                                    profile.enable_pooling = char.Parse(reader["enable_pooling"].ToString()).Equals(' ') ? 'N' : char.Parse(reader["enable_pooling"].ToString().Trim()) ;
                                    profile.last_pooling_dt = (reader["last_pooling_dt"]) == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["last_pooling_dt"].ToString().Trim());
                                    profile.pooling_cut_off = (reader["pooling_cut_off"] == DBNull.Value ? DateTime.Now : DateTime.Parse(reader["pooling_cut_off"].ToString().Trim()));
                                    profile.pooling_option = reader["pooling_option"].ToString() == null ? "NA" : reader["pooling_option"].ToString().Trim();
                                    profile.pool_acct_no = reader["pool_acct_no"].ToString() == null ? "NA" : reader["pool_acct_no"].ToString().Trim();
                                    profile.status = reader["status"].ToString() == null ? "NA" : reader["status"].ToString().Trim();

                                    allCustomers.Add(profile);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(NLog.LogLevel.Error, $"ERROR IN GetCustomers METHOD IN  CustomerImplementation CLASS. REASON{ex.Message}-----{DateTime.Now.ToString()}");
                List<zib_mobil_custom_custs> noCustomer = new List<zib_mobil_custom_custs>();
                return noCustomer;
            }



            return allCustomers;
        }
    }
}