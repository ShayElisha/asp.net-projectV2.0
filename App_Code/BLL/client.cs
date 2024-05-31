using DAL;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using DAL;
using System.Configuration;
using System.Data.SqlClient;

namespace BLL
{
    public class client
    {
        public int CusId { get; set; }
        public string CusFullName { get; set; }
        public string cusAddress { get; set; }
        public int cusCityCode { get; set; }
        public string cusPhone { get; set; }
        public string cusMail { get; set; }
        public string cusPassword { get; set; }
        public int status { get; set; }
        public string AddDate { get; set; }
        public static List<client> GetAll()
        {
            return clientDAL.GetAll();
        }
        public static client GetById(int Id)
        {
            return clientDAL.GetById(Id);
        }
        public void Save(client Client)
        {
            string sql = "";
            if (Client.CusId == -1)
            {
                sql = "insert into T_Client(CusFullName,cusAddress,cusCityCode,cusPhone,cusMail,cusPassword) values ";
                sql += $" N'{Client.CusFullName}',N'{Client.cusAddress}',N'{Client.cusCityCode}',N'{Client.cusPhone}',N'{Client.cusMail}',N'{Client.cusPassword}'";
            }
            else
            {
                sql = "update T_Categort set ";
                sql += $" CusFullName=N'{Client.CusFullName}',";
                sql += $" cusAddress=N'{Client.cusAddress}',";
                sql += $" cusCityCode=N'{Client.cusCityCode}'";
                sql += $" cusPhone=N'{Client.cusPhone}',";
                sql += $" cusMail=N'{Client.cusMail}',";
                sql += $" cusPassword=N'{Client.cusPassword}'";
                sql += $" where CusId='{Client.CusId}'";
            }

            string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
            // טעינת כל הערים לאחר עדכון/הוספה
            List<client> allClients = new List<client>();
            conn = new SqlConnection(connStr);
            conn.Open();
            sql = "SELECT * FROM T_Categort";
            cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                client c = new client()
                {
                    CusId = int.Parse(reader["CusId"].ToString()),
                    CusFullName = reader["CusFullName"].ToString(),
                    cusAddress = reader["cusAddress"].ToString(),
                    cusCityCode = (int)reader["cusCityCode"],
                    cusPhone = reader["cusPhone"].ToString(),
                    cusMail = reader["cusMail"].ToString(),
                    cusPassword = (string)reader["cusPassword"]
                };
                allClients.Add(c);
            }
            conn.Close();
            // עדכון ה-Application עם הרשימה החדשה
            HttpContext.Current.Application["Clients"] = allClients;

            // הפנייה לדף הרשימה
            HttpContext.Current.Response.Redirect("CategoryList.aspx");
        }
    }
}
