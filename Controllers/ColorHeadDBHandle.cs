using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Smart.Models;

namespace Smart.Models
{
    public class ColorHeadDBHandle
    {
        private SqlConnection con;
        private DateTime dt1;


        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<ColorHeadModel> List()
        {
            Connection();
            List<ColorHeadModel> slist = new List<ColorHeadModel>();

            SqlCommand cmd = new SqlCommand("select * from ColorHead", con);
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
                    new ColorHeadModel
                    {
                        ColorId = rdr.IsNull("ColorId") ? 0 : Convert.ToInt32(rdr["ColorId"]),
                        ColorName = rdr.IsNull("ColorName") ? string.Empty : rdr["ColorName"].ToString(),
                        UniqueName = rdr.IsNull("UniqueName") ? string.Empty : rdr["UniqueName"].ToString(),
                        ModifiedDateTime = dt1,
                    });
            }
            return slist;
        }

        public bool Add(ColorHeadModel CHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ColorHeadAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ColorName", CHDB.ColorName);
            cmd.Parameters.AddWithValue("@UniqueName", CHDB.UniqueName);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update(ColorHeadModel CHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ColorHeadUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ColorId", CHDB.ColorId);
            cmd.Parameters.AddWithValue("@ColorName", CHDB.ColorName);
            cmd.Parameters.AddWithValue("@UniqueName", CHDB.UniqueName);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Delete(int ColorId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("ColorHeadDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ColorId", ColorId);
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