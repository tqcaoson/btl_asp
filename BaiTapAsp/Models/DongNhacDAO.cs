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
				string sql = "select * from Dong_nhac";
				DataTable dt = new DataTable();
				SqlConnection con = db.getConnection();
				SqlDataAdapter da = new SqlDataAdapter(sql, con);
				con.Open();
				da.Fill(dt);
				con.Close();
				DongNhac ns;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					int ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
					String tenDongNhac = dt.Rows[i]["Ten_dongnhac"].ToString();
					ns = new DongNhac(ID, tenDongNhac);
					listNhacSi.Add(ns);
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error getAllDongNhac: " + ex.Message);
			}
			return listNhacSi;
		}

		public List<DongNhac> findDongNhacByName(string name)
		{
			Console.WriteLine("findDongNhacByName: " + name);
			List<DongNhac> listNhacSi = new List<DongNhac>();
			try
			{
				string sql = "select * from Dong_nhac where Ten_dongnhac LIKE N'%" + name + "%'";
				DataTable dt = new DataTable();
				SqlConnection con = db.getConnection();
				SqlDataAdapter da = new SqlDataAdapter(sql, con);
				con.Open();
				da.Fill(dt);
				con.Close();
				DongNhac ns;
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					int ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
					String tenDongNhac = dt.Rows[i]["Ten_dongnhac"].ToString();
					ns = new DongNhac(ID, tenDongNhac);
					listNhacSi.Add(ns);
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error findDongNhacByName: " + ex.Message);
			}
			return listNhacSi;
		}

		public bool insertDongNhac(DongNhac dn)
		{
			string sql = "insert into Dong_nhac (Ten_dongnhac) values (N'" + dn.TenDongNhac + "')";
			try
			{
				SqlConnection con = db.getConnection();
				SqlCommand cmd = new SqlCommand(sql, con);
				con.Open();
				cmd.ExecuteNonQuery();
				return true;
				cmd.Dispose();
				con.Close();
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error insertDongNhac: " + ex.Message);
				return false;
			}
		}

		public bool updateDongNhac(DongNhac ns)
		{
			string sql = "update Dong_nhac set Ten_dongnhac = N'" + ns.TenDongNhac + "' where Id = " + ns.Id;
			try
			{
				SqlConnection con = db.getConnection();
				SqlCommand cmd = new SqlCommand(sql, con);
				con.Open();
				cmd.ExecuteNonQuery();
				return true;
				cmd.Dispose();
				con.Close();
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error updateDongNhac: " + ex.Message);
				return false;
			}
		}

		public DongNhac getDongNhacByID(int id)
		{
			string sql = "select * from Dong_nhac where Id = " + id;
			DataTable dt = new DataTable();
			SqlConnection con = db.getConnection();
			SqlDataAdapter da = new SqlDataAdapter(sql, con);
			con.Open();
			da.Fill(dt);
			con.Close();
			DongNhac dn;
			int i = 0;
			int ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
			String TenDongNhac = dt.Rows[i]["Ten_dongnhac"].ToString();
			dn = new DongNhac(ID, TenDongNhac);
			return dn;

		}

		public bool deleteDongNhac(int id)
		{
			string sql = "delete from Dong_nhac where Id =" + id;
			try
			{
				SqlConnection con = db.getConnection();
				SqlCommand cmd = new SqlCommand(sql, con);
				con.Open();
				cmd.ExecuteNonQuery();
				return true;
				cmd.Dispose();
				con.Close();
			}
			catch (SqlException ex)
			{
				Console.WriteLine("error deleteDongNhac: " + ex.Message);
				return false;
			}
		}
	}
}