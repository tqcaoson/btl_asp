using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MusicManagement.Models
{
    public class NhacSiDAO
    {
        DBConnection db;
        public NhacSiDAO()
        {
            db = new DBConnection();
        }

        public List<NhacSi> getAllNhacSi()
        {

            string sql = "select * from NhacSi";
            List<NhacSi> listNhacSi = new List<NhacSi>();
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            NhacSi ns;
            for(int i=0; i<dt.Rows.Count; i++)
            {
                int ID = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                String fullName = dt.Rows[i]["name"].ToString();
                String dateOfBirth = dt.Rows[i]["dateofbirth"].ToString();
                String address = dt.Rows[i]["address"].ToString();
                String image = dt.Rows[i]["image"].ToString();
                ns = new NhacSi(ID, fullName, image, dateOfBirth, address);
                listNhacSi.Add(ns);
            }
            return listNhacSi;
        }

        public void insertNhacSi(NhacSi ns)
        {
            string sql = "insert into NhacSi (name, dateofbirth, address, image) values (N'"+ns.fullName+"', N'"+ns.dateofbirth+"', N'"+ns.address+"', N'"+ns.image+"')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void updateNhacSi(NhacSi ns)
        {
            string sql = "update NhacSi set name = N'" + ns.fullName + "', dateofbirth = N'" + ns.dateofbirth + "', address = N'" + ns.address + "', image = N'" + ns.image + "' where id = " + ns.id;
            
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public NhacSi getNhacSiByID(int id)
        {
            string sql = "select * from NhacSi where id = "+id;
            DataTable dt = new DataTable();
            SqlConnection con = db.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            NhacSi ns;
            int i = 0;
                int ID = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                String fullName = dt.Rows[i]["name"].ToString();
                String dateOfBirth = dt.Rows[i]["dateofbirth"].ToString();
                String address = dt.Rows[i]["address"].ToString();
                String image = dt.Rows[i]["image"].ToString();
                ns = new NhacSi(ID, fullName, image, dateOfBirth, address);
                
           
            return ns;

        }

        public List<NhacSi> getNhacSiByName(string name)
        {
            string sql = "select * from NhacSi where name like '%"+name+"%'";
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
                String fullName = dt.Rows[i]["name"].ToString();
                String dateOfBirth = dt.Rows[i]["dateofbirth"].ToString();
                String address = dt.Rows[i]["address"].ToString();
                String image = dt.Rows[i]["image"].ToString();
                ns = new NhacSi(ID, fullName, image, dateOfBirth, address);
                listNhacSi.Add(ns);
            }
            return listNhacSi;
        }
      

        public void deleteNhacSi(NhacSi ns)
        {
            string sql = "delete from NhacSi where id =" + ns.id;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

    }
}