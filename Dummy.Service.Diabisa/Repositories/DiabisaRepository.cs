using Dummy.Service.Diabisa.Common;
using Dummy.Service.Diabisa.Models;
using Dummy.Service.Diabisa.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Repositories
{
    public class DiabisaRepository : DatabaseConfig, IDiabisaRepository
    {

        private readonly DatabaseContext myContext;

        public DiabisaRepository() : base() { }

        public DiabisaRepository(DatabaseContext Context) : base(Context)
        {
            myContext = Context;
        }

        public DiabisaItem CreateDiabisa(DiabisaItem create_param)
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

        public IEnumerable<DiabisaItem> GetAll_diabisa()
        {
            DataSet dt = new DataSet();
            IEnumerable<DiabisaItem> result;

            try
            {
                using (SqlConnection con = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "spGetDataDiabisa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    result = (from DataRow dr in dt.Tables[0].Rows
                              select new DiabisaItem()
                              {
                                  id = (int)dr["id"],
                                  method = dr["method"].ToString(),
                                  method_details = dr["method_details"].ToString(),
                                  period = dr["period"].ToString(),
                                  value = (int)dr["value"],
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
