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
        public cities Save()
        {
            return citiesDAL.Save(this);
        }
    }
}

