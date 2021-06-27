using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
	public class DongNhacDAO
	{
		DBConnection db;
		public DongNhacDAO()
		{
			db = new DBConnection();
		}

        public List<DongNhac> getAllDongNhac()
        {
            List<DongNhac> listNhacSi = new List<DongNhac>();
            try
            {
                string sql = "select * from DongNhac";           
                DataTable dt = new DataTable();
                SqlConnection con = db.getConnection();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                con.Open();
                da.Fill(dt);
                con.Close();
                DongNhac ns;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ID = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                    String tenDongNhac = dt.Rows[i]["tendongnhac"].ToString();
                    ns = new DongNhac(ID, tenDongNhac);
                    listNhacSi.Add(ns);
                }
            }catch (SqlException ex)
			{
                Console.WriteLine("error getAllDongNhac: " + ex.Message);
            }
            return listNhacSi;
    }
    }
}