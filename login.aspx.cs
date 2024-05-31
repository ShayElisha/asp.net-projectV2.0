using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web09052024
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "SELECT * FROM T_Client";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                if (UserEmail.Text == Dr["cusMail"].ToString() && UserPass.Text == Dr["cusPassword"].ToString())
                {
                    // ניצור סשן ונשמור את האובייקט של המשתמש 
                    Session["Login"] = Dr;
                    // נעביר את המשתמש לעמוד מוצרים
                    Response.Redirect("/AdminMenage/productsList.aspx");
                }
            }
            LtlMsg.Text = "מייל או סיסמה אינם תקינים";
            
          

        }
    }
}