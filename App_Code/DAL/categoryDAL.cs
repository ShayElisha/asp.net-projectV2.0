using BLL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL
{
    public class categoryDAL
    {
        public static List<category> GetAll()
        {
            DB_Context Db = new DB_Context();//יצירת אובייקט מסוג גישה לבסיס נתנים
            string sql = "select * from T_Categort";//הגדרת משפט שאילתה
            DataTable Dt = Db.Execute(sql);// הפעלת השאילתה וקבלת התוצאות לטבלת נתטנים
            List<category> products = new List<category>();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                category C = new category()
                {
                    Cid = int.Parse(Dt.Rows[i]["Cid"] + ""),
                    Cname = Dt.Rows[i]["Cname"] + "",
                    CDesc = Dt.Rows[i]["CDesc"] + "",
                    CPic = Dt.Rows[i]["CPic"] + ""
                };
                products.Add(C);
            }
            Db.Close();
            return products;
        }
        public static category GetById(int Id)
        {
            DB_Context Db = new DB_Context();//יצירת אובייקט מסוג גישה לבסיס נתנים
            string sql = $"select * from T_Categort where Cid={Id}";//הגדרת משפט שאילתה
            DataTable Dt = Db.Execute(sql);// הפעלת השאילתה וקבלת התוצאות לטבלת נתטנים
            category Cat = null;
            if (Dt.Rows.Count > 0)
            {
                Cat = new category()
                {
                    Cid = int.Parse(Dt.Rows[0]["Cid"] + ""),
                    Cname = Dt.Rows[0]["Cname"] + "",
                    CDesc = Dt.Rows[0]["CDesc"] + "",
                    CPic = Dt.Rows[0]["CPic"] + ""
                };
            }
            Db.Close();
            return Cat;
        }
    }
}