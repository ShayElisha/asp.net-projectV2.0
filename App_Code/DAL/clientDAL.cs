﻿using BLL;
using DAL;
using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL
{
    public class clientDAL
    {
        public static List<client> GetAll()
        {
            DB_Context Db = new DB_Context();//יצירת אובייקט מסוג גישה לבסיס נתנים
            string sql = "select * from T_Client";//הגדרת משפט שאילתה
            DataTable Dt = Db.Execute(sql);// הפעלת השאילתה וקבלת התוצאות לטבלת נתטנים
            List<client> Clients = new List<client>();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                client Cus = new client()
                {
                    CusId = int.Parse(Dt.Rows[i]["CusId"] + ""),
                    CusFullName = Dt.Rows[i]["CusFullName"] + "",
                    cusAddress = Dt.Rows[i]["cusAddress"] + "",
                    cusCityCode = int.Parse(Dt.Rows[i]["cusCityCode"] + ""),
                    cusPhone = Dt.Rows[i]["cusPhone"] + "",
                    cusMail = Dt.Rows[i]["cusMail"] + "",
                    cusPassword = Dt.Rows[i]["cusPassword"] + ""
                };
                Clients.Add(Cus);
            }
            Db.Close();
            return Clients;
        }
        public static client GetById(int Id)
        {
            DB_Context Db = new DB_Context();//יצירת אובייקט מסוג גישה לבסיס נתנים
            string sql = $"select * from T_Client where CusId={Id}";//הגדרת משפט שאילתה
            DataTable Dt = Db.Execute(sql);// הפעלת השאילתה וקבלת התוצאות לטבלת נתטנים
            client Clients = null;
            if (Dt.Rows.Count > 0)
            {
                client Cus = new client()
                {
                    CusId = int.Parse(Dt.Rows[0]["Pid"] + ""),
                    CusFullName = Dt.Rows[0]["pName"] + "",
                    cusAddress = Dt.Rows[0]["price"] + "",
                    cusPhone = Dt.Rows[0]["pDesc"] + "",
                    cusMail = Dt.Rows[0]["PicName"] + "",
                    cusPassword = Dt.Rows[0]["Cid"] + ""
                };
            }
            Db.Close();
            return Clients ;
        }
        public client Save(client Client)
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
            return Client;
        }
    }
}