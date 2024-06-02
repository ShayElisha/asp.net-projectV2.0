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
    public class product
    {
        public int Pid { get; set; }
        public string pName { get; set; }
        public string pDesc { get; set; }
        public float price { get; set; }
        public string PicName { get; set; }
        public int Cid { get; set; }
        public int status { get; set; }
        public string addDate { get; set; }
        public static List<product> GetAll()
        {
            return productDAL.GetAll();
        }
        public static product GetById(int Id)
        {
            return productDAL.GetById(Id);
        }
        public product Save(product Product)
        {
            productDAL Dal = new productDAL();
            return Dal.Save(Product);
        }
    }
}
    
