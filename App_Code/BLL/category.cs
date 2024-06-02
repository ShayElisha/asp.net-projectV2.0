using DAL;
using DATA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BLL
{
    public class category
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string CDesc { get; set; }
        public string CPic { get; set; }
        public int ParentCid { get; set; }
        public string status { get; set; }
        public string AddDate { get; set; }
        public static List<category> GetAll()
        {
            return categoryDAL.GetAll();
        }
        public static category GetById(int Id)
        {
            return categoryDAL.GetById(Id);
        }
        public category Save(category Category)
        {
             return categoryDAL.Save(Category);
        }
    }
}
