using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Smart.Models;

namespace Smart.Models
{
    public class SizeHeadDBHandle
    {
        private SqlConnection con;
        private  DateTime dt1;


        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<SizeHeadModel> List()
        {
            Connection();
            List<SizeHeadModel> slist = new List<SizeHeadModel>();

            SqlCommand cmd = new SqlCommand("select * from SizeHead", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow rdr in dt.Rows)
            {
                DateTime dt1;
                if (rdr.IsNull("ModifiedDateTime"))
                    dt1 = DateTime.MinValue;
                else
                {
                    if (!DateTime.TryParse(rdr["ModifiedDateTime"].ToString(), out dt1))
                        dt1 = DateTime.MinValue;
                }

                slist.Add(
                    new SizeHeadModel
                    {
                        SizeId = rdr.IsNull("SizeId") ? 0 : Convert.ToInt32(rdr["SizeId"]),
                        SizeName = rdr.IsNull("SizeName") ? string.Empty : rdr["SizeName"].ToString(),
                        UniqueName = rdr.IsNull("UniqueName") ? string.Empty : rdr["UniqueName"].ToString(),
                        ModifiedDateTime = dt1,
                    });
            }
            return slist;
        }

        public bool Add(SizeHeadModel SHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("SizeHeadAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SizeName", SHDB.SizeName);
            cmd.Parameters.AddWithValue("@UniqueName", SHDB.UniqueName);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update(SizeHeadModel SHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("SizeHeadUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SizeId", SHDB.SizeId);
            cmd.Parameters.AddWithValue("@SizeName", SHDB.SizeName);
            cmd.Parameters.AddWithValue("@UniqueName", SHDB.UniqueName);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Delete(int SizeId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("SizeHeadDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SizeId", SizeId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}