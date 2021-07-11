using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
    public class NhacSiDAO
    {
        DBConnection db;
        public NhacSiDAO ()
        {
            db = new DBConnection();
        }

        public List<NhacSi> getAllNhacSi ()
        {

            string sql = "select * from Nhac_si";
            List<NhacSi> listNhacSi = new List<NhacSi>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            NhacSi ns;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                String fullTen_nhacsi = dt.Rows[i]["Ten_nhacsi"].ToString();
                String Ngaysinh = dt.Rows[i]["Ngaysinh"].ToString();
                String Diachi = dt.Rows[i]["Diachi"].ToString();
                String Hinh = dt.Rows[i]["Hinh"].ToString();
                ns = new NhacSi(ID, fullTen_nhacsi, Hinh, Ngaysinh, Diachi);
                listNhacSi.Add(ns);
            }
            return listNhacSi;
        }

        public void insertNhacSi (NhacSi ns)
        {

            string sql = "insert into Nhac_si (Ten_nhacsi, Ngaysinh, Diachi, Hinh) values (N'" + ns.fullName + "', N'" + ns.dateofbirth + "', N'" + ns.address + "', N'" + ns.image + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void updateNhacSi (NhacSi ns)
        {
            string sql = "update Nhac_si set Ten_nhacsi = N'" + ns.fullName + "', Ngaysinh = N'" + ns.dateofbirth + "', Diachi = N'" + ns.address + "', Hinh = N'" + ns.image + "' where id = " + ns.id;

            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public NhacSi getNhacSiByID (int id)
        {
            string sql = "select * from Nhac_si where id = " + id;
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            NhacSi ns;
            int i = 0;
            int ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
            String fullTen_nhacsi = dt.Rows[i]["Ten_nhacsi"].ToString();
            String Ngaysinh = dt.Rows[i]["Ngaysinh"].ToString();
            String Diachi = dt.Rows[i]["Diachi"].ToString();
            String Hinh = dt.Rows[i]["Hinh"].ToString();
            ns = new NhacSi(ID, fullTen_nhacsi, Hinh, Ngaysinh, Diachi);


            return ns;

        }

        public List<NhacSi> getNhacSiByTen_nhacsi (string Ten_nhacsi)
        {
            string sql = "select * from Nhac_si where Ten_nhacsi like '%" + Ten_nhacsi + "%'";
            List<NhacSi> listNhacSi = new List<NhacSi>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            NhacSi ns;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ID = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                String fullTen_nhacsi = dt.Rows[i]["Ten_nhacsi"].ToString();
                String Ngaysinh = dt.Rows[i]["Ngaysinh"].ToString();
                String Diachi = dt.Rows[i]["Diachi"].ToString();
                String Hinh = dt.Rows[i]["Hinh"].ToString();
                ns = new NhacSi(ID, fullTen_nhacsi, Hinh, Ngaysinh, Diachi);
                listNhacSi.Add(ns);
            }
            return listNhacSi;
        }


        public bool deleteNhacSi (NhacSi ns)
        {
            string sql = "delete from Nhac_si where id =" + ns.id;
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