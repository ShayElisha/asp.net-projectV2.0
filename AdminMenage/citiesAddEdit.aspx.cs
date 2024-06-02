using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web09052024.AdminMenage
{
    public partial class citiesAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cityId = Request["CityId"] + "";
                if (string.IsNullOrEmpty(cityId))
                {
                    cityId = "-1";
                }
                else
                {
                    int Cit= int.Parse(cityId);
                    List<cities> city = (List<cities>)Application["cities"];
                    for (int i = 0; i < city.Count; i++)
                    {
                        if (city[i].CityId == Cit)
                        {
                            TxtCname.Text = city[i].CityName;
                            hidCid.Value = cityId;
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            /*string sql = "";
            if (hidCid.Value == "-1")
            {
                sql = "INSERT INTO T_Cities (CityName) VALUES ";
                sql += $"(N'{TxtCname.Text}')";
            }
            else
            {
                sql = "update T_Cities set ";
                sql += $" CityName=N'{TxtCname.Text}' ";
                sql += $"where CityId='{hidCid.Value}'";
            }*/
            cities city = new cities();

            // קביעת המזהה והשם של העיר מהטופס
            if (hidCid.Value == "-1")
            {
                city.CityId =-1;
            }
            else
            {
                city.CityId = int.Parse(hidCid.Value);
            }
            city.CityName = TxtCname.Text;

            // שמירת העיר
            city.Save(city);
            // עדכון ה-Application עם הרשימה החדשה
            Application["cities"] = cities.GetAll() ;

            // הפנייה לדף הרשימה
            Response.Redirect("citiesList.aspx");


            /*
                        string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                        SqlConnection conn = new SqlConnection(connStr);
                        conn.Open();
                        string sql = "select * from T_Cities";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();

                        List<cities> cit = new List<cities>();
                        sql = "select * from T_Cities";
                        cmd.CommandText = sql;
                        SqlDataReader Dr = cmd.ExecuteReader();
                        while (Dr.Read())
                        {
                            cities C = new cities()
                            {
                                CityId = int.Parse(Dr["CityId"] + ""),
                                CityName = Dr["CityName"] + "",
                            };
                            cit.Add(C);
                        }
                        conn.Close();

                        Application["cities"] = cit;
                        Response.Redirect("citiesList.aspx");*/
        }
    }
}