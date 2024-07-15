using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Smart.Models;

namespace Smart.Models
{
    public class MillHeadDBHandle
    {
        private SqlConnection con;
        private DateTime dt1;


        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<MillHeadModel> List()
        {
            Connection();
            List<MillHeadModel> slist = new List<MillHeadModel>();

            SqlCommand cmd = new SqlCommand("select * from MillHead", con);
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
                    new MillHeadModel
                    {
                        MillId = rdr.IsNull("MillId") ? 0 : Convert.ToInt32(rdr["MillId"]),
                        MillName = rdr.IsNull("MillName") ? string.Empty : rdr["MillName"].ToString(),
                        UniqueName = rdr.IsNull("UniqueName") ? string.Empty : rdr["UniqueName"].ToString(),
                        ModifiedDateTime = dt1,
                    });
            }
            return slist;
        }

        public bool Add(MillHeadModel MHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("MillHeadAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MillName", MHDB.MillName);
            cmd.Parameters.AddWithValue("@UniqueName", MHDB.UniqueName);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update(MillHeadModel MHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("MillHeadUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MillId", MHDB.MillId);
            cmd.Parameters.AddWithValue("@MillName", MHDB.MillName);
            cmd.Parameters.AddWithValue("@UniqueName", MHDB.UniqueName);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Delete(int MillId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("MillHeadDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MillId", MillId);
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