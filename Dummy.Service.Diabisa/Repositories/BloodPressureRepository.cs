using Dummy.Service.Diabisa.Common;
using Dummy.Service.Diabisa.Models;
using Dummy.Service.Diabisa.Models.ViewModels;
using Dummy.Service.Diabisa.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Repositories
{
    public class BloodPressureRepository : DatabaseConfig, IBloodPressureRepository
    {
        private readonly DatabaseContext myContext;

        public BloodPressureRepository() : base() { }

        public BloodPressureRepository(DatabaseContext Context) : base(Context)
        {
            myContext = Context;
        }

        public IEnumerable<BloodPressureItem> GetAll_BloodPressure()
        {
            DataSet dt = new DataSet();
            IEnumerable<BloodPressureItem> result;

            try
            {
                using (SqlConnection con = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "spGet_BloodPressure";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    result = (from DataRow dr in dt.Tables[0].Rows
                              select new BloodPressureItem()
                              {
                                  id = (int)dr["id"],
                                  patient_id = (int)dr["patient_id"],
                                  type = dr["type"].ToString(),
                                  method = dr["method"].ToString(),
                                  method_details = dr["method_details"].ToString(),
                                  systole = Convert.ToSingle(dr["systole"]),
                                  diastole = Convert.ToSingle(dr["diastole"]),
                                  status = dr["status"].ToString(),
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

        public IEnumerable<BloodPressureItem> Filter_BloodPressure_ByDate(ParamFilterDateRange param_date)
        {
            DataSet dt = new DataSet();
            IEnumerable<BloodPressureItem> result;

            try
            {
                using (SqlConnection con = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "spFilter_BloodPressure_ByDate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add(new SqlParameter("start_date", param_date.start_date));
                    cmd.Parameters.Add(new SqlParameter("end_date", param_date.end_date));

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    result = (from DataRow dr in dt.Tables[0].Rows
                              select new BloodPressureItem()
                              {
                                  id = (int)dr["id"],
                                  patient_id = (int)dr["patient_id"],
                                  type = dr["type"].ToString(),
                                  method = dr["method"].ToString(),
                                  method_details = dr["method_details"].ToString(),
                                  systole = Convert.ToSingle(dr["systole"]),
                                  diastole = Convert.ToSingle(dr["diastole"]),
                                  status = dr["status"].ToString(),
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

        public IEnumerable<BloodPressureItem> GetData_BloodPressure_ByPatient(int patient_id)
        {
            DataSet dt = new DataSet();
            IEnumerable<BloodPressureItem> result;

            try
            {
                using (SqlConnection con = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "spGet_BloodPressure_ByPatient";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add(new SqlParameter("patient_id", patient_id));

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    result = (from DataRow dr in dt.Tables[0].Rows
                              select new BloodPressureItem()
                              {
                                  id = (int)dr["id"],
                                  patient_id = (int)dr["patient_id"],
                                  type = dr["type"].ToString(),
                                  method = dr["method"].ToString(),
                                  method_details = dr["method_details"].ToString(),
                                  systole = Convert.ToSingle(dr["systole"]),
                                  diastole = Convert.ToSingle(dr["diastole"]),
                                  status = dr["status"].ToString(),
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
