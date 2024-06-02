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
        public void Save(product Product)
        {
            string sql = "";
            if (Product.Pid == -1)
            {
                sql = "INSERT INTO T_Product (pName, pDesc, price, PicName) VALUES ";
                sql += $"(N'{Product.pName}', N'{Product.pDesc}', {Product.price}, N'{Product.PicName}')";
            }
            else
            {
                sql = "UPDATE T_Product SET ";
                sql += $"pName = N'{Product.pName}', ";
                sql += $"pDesc = N'{Product.pDesc}', ";
                sql += $"price = {Product.price}, ";
                sql += $"PicName = N'{Product.PicName}' ";
                sql += $"WHERE Pid = {Product.Pid}";
            }

            DB_Context Db = new DB_Context();
            Db.ExecuteNonQuery(sql);
            GetAll();
            
        }
    }
}
    
