using BLL;
using DAL;
using DATA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class citiesDAL:cities
    {
        public static List<cities> GetAll()
        {
            DB_Context Db = new DB_Context();//יצירת אובייקט מסוג גישה לבסיס נתנים
            string sql = "select * from T_Cities";//הגדרת משפט שאילתה
            DataTable Dt = Db.Execute(sql);// הפעלת השאילתה וקבלת התוצאות לטבלת נתטנים
            List<cities> city = new List<cities>();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                cities C = new cities()
                {
                    CityId = int.Parse(Dt.Rows[i]["CityId"] + ""),
                    CityName = Dt.Rows[i]["CityName"] + ""
                };
                city.Add(C);
            }
            Db.Close();
            return city;
        }
        public static cities GetById(int Id)
        {
            DB_Context Db = new DB_Context();//יצירת אובייקט מסוג גישה לבסיס נתנים
            string sql = $"select * from T_Cities where CityId={Id}";//הגדרת משפט שאילתה
            DataTable Dt = Db.Execute(sql);// הפעלת השאילתה וקבלת התוצאות לטבלת נתטנים
            cities city = null;
            if (Dt.Rows.Count > 0)
            {
                city = new cities()
                {
                    CityId = int.Parse(Dt.Rows[0]["CityId"] + ""),
                    CityName = Dt.Rows[0]["CityName"] + "",
                };
            }
            Db.Close();
            return city;
        }
        public static  cities Save(cities city)
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

            DB_Context Db = new DB_Context();
            Db.ExecuteNonQuery(sql);
            GetAll();
            return city;
        }
    }
}