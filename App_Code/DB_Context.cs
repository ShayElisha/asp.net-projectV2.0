using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;




namespace DATA
{
    public class DB_Context
    {
        public string connStr {  get; set; }
        public SqlConnection conn{ get; set; }
        public DB_Context() 
        {
            connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();

        }
        public void Close()
        {
            conn.Close();
        }
        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

        public DataTable Execute(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataAdapter Da= new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);//מילוי טבלת הנתונים בתוצאות השאילתה 
            return Dt;// החזרת טבלת הנתונים 
        }
    }
}