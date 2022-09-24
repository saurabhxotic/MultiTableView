using MultiTableView.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace MultiTableView.Repos
{
    public class db
    {
        private readonly AppSettings _appSettings;

        public db(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public DataTable GetData(string proc)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_appSettings.MyLocal))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(cmd);
                    objSqlDataAdapter.Fill(dt);
                    return dt;

                }
                catch (Exception ex)
                {
                    return dt;
                }
            }
        }

        public DataTable GetData(string proc, Dictionary<string, object> parameter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_appSettings.MyLocal))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in parameter.Keys)
                    {
                        cmd.Parameters.AddWithValue(item, parameter[item]);
                    }

                    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(cmd);
                    objSqlDataAdapter.Fill(dt);
                    return dt;

                }
                catch (Exception ex)
                {
                    return dt;
                }
            }
        }

        public DataTable GetData(string proc, List<SqlParameter> sqlParameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_appSettings.MyLocal))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters.ToArray());
                    SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(cmd);
                    objSqlDataAdapter.Fill(dt);
                    return dt;

                }
                catch (Exception ex)
                {
                    return dt;
                }
            }
        }
        public bool PostData(string proc, Dictionary<string, object> parameter)
        {
            using (SqlConnection con = new SqlConnection(_appSettings.MyLocal))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in parameter.Keys)
                    {
                        cmd.Parameters.AddWithValue(item, parameter[item]);
                    }

                    int res = cmd.ExecuteNonQuery();  // 1 if inserted 
                    if (res > 0)
                        return true;
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool PostData(string proc, List<SqlParameter> sqlParameters)
        {
            using (SqlConnection con = new SqlConnection(_appSettings.MyLocal))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters.ToArray()); 
                    int res = cmd.ExecuteNonQuery();  // 1 if inserted 
                    if (res > 0)
                        return true;
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool PostBulkData(string proc, SqlParameter sqlParameter)
        {
            using (SqlConnection con = new SqlConnection(_appSettings.MyLocal))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(sqlParameter);

                    int res = cmd.ExecuteNonQuery();  // 1 if inserted 
                    if (res > 0)
                        return true;
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool DeleteData(string proc, int id)
        {
            using (SqlConnection con = new SqlConnection(_appSettings.MyLocal))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(proc, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);

                    int res = cmd.ExecuteNonQuery();  // 1 if inserted 
                    if (res > 0)
                        return true;
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
