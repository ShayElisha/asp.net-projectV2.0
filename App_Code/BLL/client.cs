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
        public client Save(client Client)
        {
            clientDAL Dal = new clientDAL();
            return Dal.Save(Client);
        }
    }
}
