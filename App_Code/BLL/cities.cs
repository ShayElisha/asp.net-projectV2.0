using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace BLL
{
    public class cities
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string status { get; set; }
        public string AddDate { get; set; }
        public static List<cities> GetAll()
        {
            return citiesDAL.GetAll();
        }
        public void Save(cities city)
        {
            string sql;
            if (city.CityId == -1)
            {
                sql = "INSERT INTO T_Cities (CityName) VALUES ";
                sql += $"(N'{city.CityName}')";
            }
            else
            {
                sql = "UPDATE T_Cities SET ";
                sql += $"CityName = N'{city.CityName}' ";
                sql += $"WHERE CityId = {city.CityId}";
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
            List<cities> allCities = new List<cities>();
            conn = new SqlConnection(connStr);
            conn.Open();
            sql = "SELECT * FROM T_Cities";
            cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cities c = new cities()
                {
                    CityId = int.Parse(reader["CityId"].ToString()),
                    CityName = reader["CityName"].ToString(),
                };
                allCities.Add(c);
            }
            conn.Close();
            // עדכון ה-Application עם הרשימה החדשה
            HttpContext.Current.Application["cities"] = allCities;

            // הפנייה לדף הרשימה
            HttpContext.Current.Response.Redirect("citiesList.aspx");
        }
    }
}

