using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Configuration;
using System.Data.SqlClient;

namespace web09052024
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<cities> cities = (List<cities>)Application["cities"];
                for (int i = 0; i < cities.Count; i++)
                {
                    DDlCity.Items.Add(new ListItem(cities[i].CityName, cities[i].CityId + ""));
                }

            }
        }
        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            bool check = true;
            List<client> clients = (List<client>)Application["Clients"];
            if (!string.IsNullOrEmpty(UserName.Text) &&
                !string.IsNullOrEmpty(UserPass.Text) &&
                !string.IsNullOrEmpty(validPass.Text) &&
                !string.IsNullOrEmpty(DDlCity.Text))
            {
                if (UserPass.Text == validPass.Text)
                {
                    // בדיקה האם קיים לקוח עם אותה כתובת אימייל כבר ברשימה
                    if (clients.Exists(c => c.cusMail == Email.Text))
                    {
                        check = false;
                        Warning.Text = "המשתמש קיים במערכת";
                    }
                    string sql = "";
                    if (check)
                    {
                        sql = "INSERT INTO T_Client (CusFullName, cusMail, cusPassword, cusCityCode, cusAddress, cusPhone) VALUES ";
                        sql += $"(N'{UserName.Text}', N'{Email.Text}', N'{UserPass.Text}', N'{DDlCity.SelectedValue}', N'{Address.Text}', N'{Phone.Text}')";

                        string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                        SqlConnection conn = new SqlConnection(connStr);
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        Response.Redirect("Login.aspx");
                        conn.Close();
                    }
                }
                else
                {
                    Warning.Text = "הסיסמאות לא תואמות";
                }
            }
            else
            {
                Warning.Text = "מלא את כל השדות ";
            }
        }
    }
}