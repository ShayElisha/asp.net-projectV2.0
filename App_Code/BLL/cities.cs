using DAL;
using DATA;
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

            DB_Context Db = new DB_Context();
            Db.ExecuteNonQuery(sql);
            GetAll();

        }
    }
}

