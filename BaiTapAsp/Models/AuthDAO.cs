using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
    public class AuthDAO
    {
        DBConnection db;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        public AuthDAO()
        {
            db = new DBConnection();
        }
        public bool login(String username, String password)
        {
            try
            {
                string sql = "select * from users where username = N'"+ username + "' and password = N'" + password + "'";
                con = db.getConnection();
                con.Open();
                da = new SqlDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables["Table"].Rows.Count == 0) return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
                return false;
            }
            return true;
        }
        public bool checkunique(String username)
        {
            try
            {
                string sql1 = "select * from users where username = N'" + username + "'";
                con = db.getConnection();
                con.Open();
                da = new SqlDataAdapter(sql1, con);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables["Table"].Rows.Count != 0) return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("error : " + ex.Message);
                return false;
            }
            return true;
        }
        public bool signin(String username, String password)
        {
            try
            {
                string sql = "insert into users(username, password) values (@username, @password)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("error : " + ex.Message);
                return false;
            }
            return true;
        }
    }
}