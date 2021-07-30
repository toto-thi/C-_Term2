using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tok_Rent
{
    class dbconnect
    { 
            private SqlConnection conn = new SqlConnection("Data Source=TotoThii\\SQLEXPRESS;Initial Catalog=Y3T2;Integrated Security=True");
            private SqlCommand cmd;

            public SqlDataAdapter da;
            public DataTable dt;
            public DataSet ds;
            //public DataRow dr;

            //query parameter
            public List<SqlParameter> Params = new List<SqlParameter>();

            //record count
            public int RecordCount;

            public void EXE(string query)
            {
                RecordCount = 0;

                try
                {
                    conn.Open();
                    cmd = new SqlCommand(query, conn);

                    //add parameters to query command
                    Params.ForEach(p => cmd.Parameters.Add(p));
                    Params.Clear();

                    //excute command and fill dataset
                    dt = new DataTable();
                    ds = new DataSet();
                    da = new SqlDataAdapter(cmd);

                    RecordCount = da.Fill(dt);

                }
                catch
                {

                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            //add parameters
            public void addParams(string name, string value)
            {
                SqlParameter NewParams = new SqlParameter(name, value);
                Params.Add(NewParams);
            }
        
    }
}
