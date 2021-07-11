using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BaiTapAsp.Models
{
    public class DBConnection
    {
        string strCon;
        string s;
        public DBConnection()
        {
            s = @"Data Source=DESKTOP-7HOLHB6\SQLEXPRESS;Initial Catalog=WebsiteQuanLy;Integrated Security=True";
            strCon = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(s);
        }
    }
}