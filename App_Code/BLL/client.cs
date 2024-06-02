using DAL;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using DAL;
using System.Configuration;
using System.Data.SqlClient;
using DATA;

namespace BLL
{
    public class client
    {
        public int CusId { get; set; }
        public string CusFullName { get; set; }
        public string cusAddress { get; set; }
        public int cusCityCode { get; set; }
        public string cusPhone { get; set; }
        public string cusMail { get; set; }
        public string cusPassword { get; set; }
        public int status { get; set; }
        public string AddDate { get; set; }
        public static List<client> GetAll()
        {
            return clientDAL.GetAll();
        }
        public static client GetById(int Id)
        {
            return clientDAL.GetById(Id);
        }
        public void Save(client Client)
        {
            string sql = "";
            if (Client.CusId == -1)
            {
                sql = "insert into T_Client(CusFullName,cusAddress,cusCityCode,cusPhone,cusMail,cusPassword) values ";
                sql += $" (N'{Client.CusFullName}',N'{Client.cusAddress}',N'{Client.cusCityCode}',N'{Client.cusPhone}',N'{Client.cusMail}',N'{Client.cusPassword}')";
            }
            else
            {
                sql = "update T_Client set ";
                sql += $" CusFullName=N'{Client.CusFullName}',";
                sql += $" cusAddress=N'{Client.cusAddress}',";
                sql += $" cusCityCode=N'{Client.cusCityCode}',";
                sql += $" cusPhone=N'{Client.cusPhone}',";
                sql += $" cusMail=N'{Client.cusMail}',";
                sql += $" cusPassword=N'{Client.cusPassword}'";
                sql += $" where CusId='{Client.CusId}'";
            }

            DB_Context Db = new DB_Context();
            Db.ExecuteNonQuery(sql);
            GetAll();
        }
    }
}
