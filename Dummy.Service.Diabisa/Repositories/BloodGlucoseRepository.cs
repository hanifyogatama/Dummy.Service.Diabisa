using Dummy.Service.Diabisa.Common;
using Dummy.Service.Diabisa.Models;
using Dummy.Service.Diabisa.Models.ViewModels;
using Dummy.Service.Diabisa.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Repositories
{
    public class BloodGlucoseRepository : DatabaseConfig, IBloodGlucoseRepository
    {

        private readonly DatabaseContext myContext;

        public BloodGlucoseRepository() : base() { }

        public BloodGlucoseRepository(DatabaseContext Context) : base(Context)
        {
            myContext = Context;
        }

        public ParamAddBloodGlucose AddData_BloodGlucose(ParamAddBloodGlucose create_param)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "spAddDiabisa";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("method", create_param.method));
                    cmd.Parameters.Add(new SqlParameter("method_details", create_param.method_details));
                    cmd.Parameters.Add(new SqlParameter("period", create_param.period));
                    cmd.Parameters.Add(new SqlParameter("value", create_param.value));
                    cmd.Parameters.Add(new SqlParameter("status", create_param.status));
                    cmd.Parameters.Add(new SqlParameter("target", create_param.target));
        

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return create_param;
        }

        public IEnumerable<BloodGlucoseItem> GetAll_BloodGlucose()
        {
            DataSet dt = new DataSet();
            IEnumerable<BloodGlucoseItem> result;

            try
            {
                using (SqlConnection con = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "spGet_BloodGlucose";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    result = (from DataRow dr in dt.Tables[0].Rows
                              select new BloodGlucoseItem()
                              {
                                  id = (int)dr["id"],
                                  type = dr["type"].ToString(),
                                  method = dr["method"].ToString(),
                                  method_details = dr["method_details"].ToString(),
                                  period = dr["period"].ToString(),
                                  value = Convert.ToSingle(dr["value"]),
                                  status = dr["status"].ToString(),
                                  target = dr["target"].ToString(),
                                  check_date = dr["check_date"].ToString(),
                                  check_time = dr["check_time"].ToString(),
                                  created_date = DateTime.Parse(dr["created_date"].ToString())
                              }).ToList();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public IEnumerable<BloodGlucoseItem> Filter_BloodGlucose(ParamFilterBloodGlucose filter_param)
        {
            DataSet dt = new DataSet();
            IEnumerable<BloodGlucoseItem> result;

            try
            {
                using(SqlConnection con = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "spFilter_BloodGlucose_DateTypeMethodStatus";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add(new SqlParameter("start_date", filter_param.start_date));
                    cmd.Parameters.Add(new SqlParameter("end_date", filter_param.end_date));
                    cmd.Parameters.Add(new SqlParameter("type_1", filter_param.type_1));
                    cmd.Parameters.Add(new SqlParameter("type_2", filter_param.type_2));

                    cmd.Parameters.Add(new SqlParameter("method_1", filter_param.method_1));
                    cmd.Parameters.Add(new SqlParameter("method_2", filter_param.method_2));
                    cmd.Parameters.Add(new SqlParameter("method_3", filter_param.method_3));
                    cmd.Parameters.Add(new SqlParameter("method_4", filter_param.method_4));
                    cmd.Parameters.Add(new SqlParameter("method_5", filter_param.method_5));
                    cmd.Parameters.Add(new SqlParameter("method_6", filter_param.method_6));
                    cmd.Parameters.Add(new SqlParameter("method_7", filter_param.method_7));

                    cmd.Parameters.Add(new SqlParameter("status_1", filter_param.status_1));
                    cmd.Parameters.Add(new SqlParameter("status_2", filter_param.status_2));
                    cmd.Parameters.Add(new SqlParameter("status_3", filter_param.status_3));
                    cmd.Parameters.Add(new SqlParameter("status_4", filter_param.status_4));
                    cmd.Parameters.Add(new SqlParameter("status_5", filter_param.status_5));

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    result = (from DataRow dr in dt.Tables[0].Rows
                              select new BloodGlucoseItem()
                              {
                                  id = (int)dr["id"],
                                  type = dr["type"].ToString(),
                                  method = dr["method"].ToString(),
                                  method_details = dr["method_details"].ToString(),
                                  period = dr["period"].ToString(),
                                  value = Convert.ToSingle(dr["value"]),
                                  status = dr["status"].ToString(),
                                  target = dr["target"].ToString(),
                                  check_date = dr["check_date"].ToString(),
                                  check_time = dr["check_time"].ToString(),
                                  created_date = DateTime.Parse(dr["created_date"].ToString())
                              }).ToList();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public IEnumerable<BloodGlucoseItem> Filter_BloodGlucose_ByDate(ParamFilterDateRange param_date)
        {
            DataSet dt = new DataSet();
            IEnumerable<BloodGlucoseItem> result;

            //var start_date = startDate;
            //var start_date = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            //var end_date = new DateTime(endDate.Year, endDate.Month, endDate.Day);
            //var end_date = endDate.Date;
          
            try
            {
                using (SqlConnection con = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "spFilter_BloodGlucose_ByDate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add(new SqlParameter("start_date", param_date.start_date));
                    cmd.Parameters.Add(new SqlParameter("end_date", param_date.end_date));
                   

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    result = (from DataRow dr in dt.Tables[0].Rows
                              select new BloodGlucoseItem()
                              {
                                  id = (int)dr["id"],
                                  type = dr["type"].ToString(),
                                  method = dr["method"].ToString(),
                                  method_details = dr["method_details"].ToString(),
                                  period = dr["period"].ToString(),
                                  value = Convert.ToSingle(dr["value"]),
                                  status = dr["status"].ToString(),
                                  target = dr["target"].ToString(),
                                  check_date = dr["check_date"].ToString(),
                                  check_time = dr["check_time"].ToString(),
                                  created_date = DateTime.Parse(dr["created_date"].ToString())
                              }).ToList();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
