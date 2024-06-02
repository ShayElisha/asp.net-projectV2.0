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

            DB_Context Db = new DB_Context();
            Db.ExecuteNonQuery(sql);
            GetAll();
            
        }
    }
}
