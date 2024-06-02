using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BLL;

namespace DAL
{
    public class productDAL
    {
        public static List<product>GetAll()
        {
            DB_Context Db = new DB_Context();//יצירת אובייקט מסוג גישה לבסיס נתנים
            string sql = "select * from T_Product";//הגדרת משפט שאילתה
            DataTable Dt = Db.Execute(sql);// הפעלת השאילתה וקבלת התוצאות לטבלת נתטנים
            List<product> products = new List<product>();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                product T = new product()
                {
                    Pid = int.Parse(Dt.Rows[i]["Pid"] + ""),
                    pName = Dt.Rows[i]["pName"] + "",
                    price = float.Parse(Dt.Rows[i]["price"] + ""),
                    pDesc = Dt.Rows[i]["pDesc"] + "",
                    PicName = Dt.Rows[i]["PicName"] + "",
                };
                products.Add(T);
            }
            Db.Close();
            return products;
        }
        public static product GetById(int Id)
        {
            DB_Context Db = new DB_Context();//יצירת אובייקט מסוג גישה לבסיס נתנים
            string sql = $"select * from T_Product where Pid={Id}";//הגדרת משפט שאילתה
            DataTable Dt = Db.Execute(sql);// הפעלת השאילתה וקבלת התוצאות לטבלת נתטנים
            product product =null;
            if(Dt.Rows.Count > 0)
            {
                product = new product()
                {
                    Pid = int.Parse(Dt.Rows[0]["Pid"] + ""),
                    pName = Dt.Rows[0]["pName"] + "",
                    price = float.Parse(Dt.Rows[0]["price"] + ""),
                    pDesc = Dt.Rows[0]["pDesc"] + "",
                    PicName = Dt.Rows[0]["PicName"] + "",
                    Cid = int.Parse(Dt.Rows[0]["Cid"] + "")
                };
            }
            Db.Close();
            return product;   
        }
        public product Save(product Product)
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
            return Product;
        }
    }
   
    
}