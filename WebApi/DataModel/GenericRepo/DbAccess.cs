using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataModel.GenericRepo
{
    internal class DbAccess
    {
        private string _connection = ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString;
       
        public DataSet Submit(SqlCommand cmd)
        {
            var dataset = new DataSet();
            using (var con = new SqlConnection(_connection))
            {
                cmd.Connection = con;
                using (var da = new SqlDataAdapter(cmd))
                {
                    con.Open();
                    da.Fill(dataset, "data");
                    con.Close();
                }
            }

            return dataset;
        }
    }
}
