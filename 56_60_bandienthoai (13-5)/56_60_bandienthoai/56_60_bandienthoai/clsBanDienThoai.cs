using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _56_60_bandienthoai
{
    internal class clsBanDienThoai
    {
        SqlConnection con = new SqlConnection();
        
        void ketNoi()
        {
            con.ConnectionString = @"Data source=LAPTOP-BC47GUM4;Initial Catalog=qlBanDienThoai;integrated Security=True";
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public clsBanDienThoai()
        {
            ketNoi();
        }
        public void dongKetNoi()
        {
            con.Close();
        }

        public DataSet layDuLieu(string sql) { 
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);
            return ds;  
        }
        public int capNhatDuLieu(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }
    }
   
}
        
