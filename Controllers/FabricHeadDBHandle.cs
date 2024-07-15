using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Smart.Models;

namespace Smart.Models
{
    public class FabricHeadDBHandle
    {
        private SqlConnection con;
        private DateTime dt1;


        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<FabricHeadModel> List()
        {
            Connection();
            List<FabricHeadModel> slist = new List<FabricHeadModel>();

            SqlCommand cmd = new SqlCommand("select * from FabricHead", con);
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
                    new FabricHeadModel
                    {
                        FabricId = rdr.IsNull("FabricId") ? 0 : Convert.ToInt32(rdr["FabricId"]),
                        FabricName = rdr.IsNull("FabricName") ? string.Empty : rdr["FabricName"].ToString(),
                        UniqueName = rdr.IsNull("UniqueName") ? string.Empty : rdr["UniqueName"].ToString(),
                        ModifiedDateTime = dt1,
                    });
            }
            return slist;
        }

        public bool Add(FabricHeadModel FHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("FabricHeadAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FabricName", FHDB.FabricName);
            cmd.Parameters.AddWithValue("@UniqueName", FHDB.UniqueName);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update(FabricHeadModel FHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("FabricHeadUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FabricId", FHDB.FabricId);
            cmd.Parameters.AddWithValue("@FabricName", FHDB.FabricName);
            cmd.Parameters.AddWithValue("@UniqueName", FHDB.UniqueName);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Delete(int FabricId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("FabricHeadDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FabricId", FabricId);
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