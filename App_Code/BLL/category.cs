using DAL;
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
        public void Save(category Category)
        {
            string sql = "";
            if (Category.Cid == -1)
            {
                sql = "insert into T_Categort(Cname,CDesc,CPic) values ";
                sql += $" N'{Category.Cname}',N'{Category.CDesc}',N'{Category.CPic}'";
            }
            else
            {
                sql = "update T_Categort set ";
                sql += $" Cname=N'{Category.Cname}',";
                sql += $" CDesc=N'{Category.CDesc}',";
                sql += $" CPic=N'{Category.CPic}'";
                sql += $" where Cid='{Category.Cid}'";
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
            List<category> allCategories = new List<category>();
            conn = new SqlConnection(connStr);
            conn.Open();
            sql = "SELECT * FROM T_Categort";
            cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                category c = new category()
                {
                    Cid = int.Parse(reader["Cid"].ToString()),
                    Cname = reader["Cname"].ToString(),
                    CDesc = reader["CDesc"].ToString(),
                    CPic = reader["CPic"].ToString(),
                };
                allCategories.Add(c);
            }
            conn.Close();
            // עדכון ה-Application עם הרשימה החדשה
            HttpContext.Current.Application["categories"] = allCategories;

            // הפנייה לדף הרשימה
            HttpContext.Current.Response.Redirect("CategoryList.aspx");
        }
    }
}
