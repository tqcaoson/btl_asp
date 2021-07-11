using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
    public class BaiHatDAO
    {
        DBConnection db;
        public BaiHatDAO ()
        {
            db = new DBConnection();
        }

        public List<BaiHat> GetBaiHats ()
        {
            string sql = "select * from Bai_hat";
            List<BaiHat> baiHats = new List<BaiHat>();
            DataTable data = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(data);
            con.Close();
            BaiHat baiHat;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int iD = Convert.ToInt32(data.Rows[i]["Id"].ToString());
                int id_nhacsi = Convert.ToInt32(data.Rows[i]["Id_nhacsi"].ToString());
                int id_dongnhac = Convert.ToInt32(data.Rows[i]["Id_dongnhac"].ToString());
                string ten_bai_hat = data.Rows[i]["Ten_bai_hat"].ToString();
                DateTime ngayDang = Convert.ToDateTime(data.Rows[i]["NgayDang"].ToString());
                int luotNghe = Convert.ToInt32(data.Rows[i]["LuotNghe"].ToString());
                baiHat = new BaiHat(iD, id_nhacsi, id_dongnhac, ten_bai_hat, ngayDang, luotNghe);
                baiHats.Add(baiHat);
            }
            return baiHats;
        }

        public void insertBH (BaiHat bh)
        {
            string sql = "insert into Bai_hat (Id_nhacsi, Id_dongnhac, Ten_bai_hat, NgayDang, LuotNghe) values (N'" + bh.Id_nhacsi + "', N'" + bh.Id_dongnhac + "', N'" + bh.Ten_bai_hat + "', N'" + bh.NgayDang + "', N'" + bh.LuotNghe + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void UpdateBH(BaiHat bh)
        {
            string sql = "Update Bai_hat SET Id_nhacsi = @idNS, Id_dongnhac = @idDN, Ten_bai_hat = @tenBH, NgayDang = @ND, LuotNghe = @LN where Id = @id";
            SqlConnection con =  db.getConnection();
            SqlCommand cmm = new SqlCommand(sql, con);
            cmm.Parameters.AddWithValue("@idNS", bh.Id_nhacsi);
            cmm.Parameters.AddWithValue("@idDN", bh.Id_dongnhac);
            cmm.Parameters.AddWithValue("@tenBH", bh.Ten_bai_hat);
            cmm.Parameters.AddWithValue("@ND", bh.NgayDang);
            cmm.Parameters.AddWithValue("@LN", bh.LuotNghe);
            cmm.Parameters.AddWithValue("@id", bh.Id);
            con.Open();
            cmm.ExecuteNonQuery();
            con.Close();
        }

        public BaiHat getBaiHatByID (int id)
        {
            string sql = "select * from Bai_hat where id = " + id;
            DataTable data = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(data);
            con.Close();
            BaiHat bh;
            int i = 0;
            int iD = Convert.ToInt32(data.Rows[i]["Id"].ToString());
            int id_nhacsi = Convert.ToInt32(data.Rows[i]["Id_nhacsi"].ToString());
            int id_dongnhac = Convert.ToInt32(data.Rows[i]["Id_dongnhac"].ToString());
            string ten_bai_hat = data.Rows[i]["Ten_bai_hat"].ToString();
            DateTime ngayDang = Convert.ToDateTime(data.Rows[i]["NgayDang"].ToString());
            int luotNghe = Convert.ToInt32(data.Rows[i]["LuotNghe"].ToString());
            bh = new BaiHat(iD, id_nhacsi, id_dongnhac, ten_bai_hat, ngayDang, luotNghe);
           
            return bh;

        }

        public void Delete(int id)
        {
            string sql = "Delete From Bai_hat where Id = @id";
            SqlConnection con = db.getConnection();
            SqlCommand cmm = new SqlCommand(sql, con);
            cmm.Parameters.AddWithValue("@id", id);
            con.Open();
            cmm.ExecuteNonQuery();
            con.Close();
        }

        public List<BaiHat> SearchBaiHat (string name)
        {
            string sql = "select * from Bai_hat where Ten_bai_hat = " + name;
            List<BaiHat> baiHats = new List<BaiHat>();
            DataTable data = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(data);
            con.Close();
            BaiHat baiHat;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int iD = Convert.ToInt32(data.Rows[i]["Id"].ToString());
                int id_nhacsi = Convert.ToInt32(data.Rows[i]["Id_nhacsi"].ToString());
                int id_dongnhac = Convert.ToInt32(data.Rows[i]["Id_dongnhac"].ToString());
                string ten_bai_hat = data.Rows[i]["Ten_bai_hat"].ToString();
                DateTime ngayDang = Convert.ToDateTime(data.Rows[i]["NgayDang"].ToString());
                int luotNghe = Convert.ToInt32(data.Rows[i]["LuotNghe"].ToString());
                baiHat = new BaiHat(iD, id_nhacsi, id_dongnhac, ten_bai_hat, ngayDang, luotNghe);
                baiHats.Add(baiHat);
            }
            return baiHats;
        }
    }
}