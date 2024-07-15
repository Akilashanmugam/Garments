using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Smart.Models;

namespace Smart.Models
{
    public class CompanyHeadDBHandle
    {
        private SqlConnection con;
        private DateTime dt1;


        private void Connection()

        {
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constring);

        }

        public List<CompanyHeadModel> List()
        {
            Connection();
            List<CompanyHeadModel> clist = new List<CompanyHeadModel>();

            SqlCommand cmd = new SqlCommand("select * from CompanyHead", con);
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

                clist.Add(
                    new CompanyHeadModel
                    {
                        CompanyId = rdr.IsNull("CompanyId") ? 0 : Convert.ToInt32(rdr["CompanyId"]),
                        CompanyName = rdr.IsNull("CompanyName") ? string.Empty : rdr["CompanyName"].ToString(),
                        UniqueName = rdr.IsNull("UniqueName") ? string.Empty : rdr["UniqueName"].ToString(),
                        CompanyPrintName = rdr.IsNull("CompanyPrintName") ? string.Empty : rdr["CompanyPrintName"].ToString(),
                        CompanyCode = rdr.IsNull("CompanyCode") ? string.Empty : rdr["CompanyCode"].ToString(),
                        CompanyAddress1 = rdr.IsNull("CompanyAddress1") ? string.Empty : rdr["CompanyAddress1"].ToString(),
                        CompanyAddress2 = rdr.IsNull("CompanyAddress2") ? string.Empty : rdr["CompanyAddress2"].ToString(),
                        CompanyAddress3 = rdr.IsNull("CompanyAddress3") ? string.Empty : rdr["CompanyAddress3"].ToString(),
                        CompanyAddress4 = rdr.IsNull("CompanyAddress4") ? string.Empty : rdr["CompanyAddress4"].ToString(),
                        CompanyPhoneNo = rdr.IsNull("CompanyPhoneNo") ? string.Empty : rdr["CompanyPhoneNo"].ToString(),
                        CompanyFaxNo = rdr.IsNull("CompanyFaxNo") ? string.Empty : rdr["CompanyFaxNo"].ToString(),
                        CompanyEmailid = rdr.IsNull("CompanyEmailid") ? string.Empty : rdr["CompanyEmailid"].ToString(),
                        companywebsite = rdr.IsNull("companywebsite") ? string.Empty : rdr["companywebsite"].ToString(),
                        CompanyTinNo = rdr.IsNull("CompanyTinNo") ? string.Empty : rdr["CompanyTinNo"].ToString(),
                        CompanyCstNo = rdr.IsNull("CompanyCstNo") ? string.Empty : rdr["CompanyCstNo"].ToString(),
                        CompanyType = rdr.IsNull("CompanyType") ? string.Empty : rdr["CompanyType"].ToString(),
                        CompanyPanNo = rdr.IsNull("CompanyPanNo") ? string.Empty : rdr["CompanyPanNo"].ToString(),
                        ModifiedDateTime = dt1,
                    });
            }
            return clist;
        }
        public bool Add(CompanyHeadModel CHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyHeadAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyName", CHDB.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyPrintName", CHDB.CompanyPrintName);
            cmd.Parameters.AddWithValue("@UniqueName", CHDB.UniqueName);
            cmd.Parameters.AddWithValue("@CompanyCode", CHDB.CompanyCode);
            cmd.Parameters.AddWithValue("@CompanyAddress1", CHDB.CompanyAddress1);
            cmd.Parameters.AddWithValue("@CompanyAddress2", CHDB.CompanyAddress2);
            cmd.Parameters.AddWithValue("@CompanyAddress3", CHDB.CompanyAddress3);
            cmd.Parameters.AddWithValue("@CompanyAddress4", CHDB.CompanyAddress4);
            cmd.Parameters.AddWithValue("@CompanyPhoneNo", CHDB.CompanyPhoneNo);
            cmd.Parameters.AddWithValue("@CompanyFaxNo", CHDB.CompanyFaxNo);
            cmd.Parameters.AddWithValue("@CompanyEmailid", CHDB.CompanyEmailid);
            cmd.Parameters.AddWithValue("@companywebsite", CHDB.companywebsite);
            cmd.Parameters.AddWithValue("@CompanyTinNo", CHDB.CompanyTinNo);
            cmd.Parameters.AddWithValue("@CompanyCstNo", CHDB.CompanyCstNo);
            cmd.Parameters.AddWithValue("@CompanyType", CHDB.CompanyType);
            cmd.Parameters.AddWithValue("@CompanyPanNo", CHDB.CompanyPanNo);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Update(CompanyHeadModel CHDB)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyHeadUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", CHDB.CompanyId);
            cmd.Parameters.AddWithValue("@CompanyName", CHDB.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyPrintName", CHDB.CompanyPrintName);
            cmd.Parameters.AddWithValue("@UniqueName", CHDB.UniqueName);
            cmd.Parameters.AddWithValue("@CompanyCode", CHDB.CompanyCode);
            cmd.Parameters.AddWithValue("@CompanyAddress1", CHDB.CompanyAddress1);
            cmd.Parameters.AddWithValue("@CompanyAddress2", CHDB.CompanyAddress2);
            cmd.Parameters.AddWithValue("@CompanyAddress3", CHDB.CompanyAddress3);
            cmd.Parameters.AddWithValue("@CompanyAddress4", CHDB.CompanyAddress4);
            cmd.Parameters.AddWithValue("@CompanyPhoneNo", CHDB.CompanyPhoneNo);
            cmd.Parameters.AddWithValue("@CompanyFaxNo", CHDB.CompanyFaxNo);
            cmd.Parameters.AddWithValue("@CompanyEmailid", CHDB.CompanyEmailid);
            cmd.Parameters.AddWithValue("@companywebsite", CHDB.companywebsite);
            cmd.Parameters.AddWithValue("@CompanyTinNo", CHDB.CompanyTinNo);
            cmd.Parameters.AddWithValue("@CompanyCstNo", CHDB.CompanyCstNo);
            cmd.Parameters.AddWithValue("@CompanyType", CHDB.CompanyType);
            cmd.Parameters.AddWithValue("@CompanyPanNo", CHDB.CompanyPanNo);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Today);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public bool Delete(int CompanyId)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("CompanyHeadDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", CompanyId);
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