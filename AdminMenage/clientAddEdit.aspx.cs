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
    public partial class clientAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CusId = Request["CusId"] + "";
                if (string.IsNullOrEmpty(CusId))
                {
                    CusId = "-1";
                }
                else
                {
                    int cusId = int.Parse(CusId);
                    List<client> Client = (List<client>)Application["Clients"];
                    for (int i = 0; i < Client.Count; i++)
                    {
                        if (Client[i].CusId == cusId)
                        {
                            cusFullName.Text = Client[i].CusFullName;
                            CusAddress.Text = Client[i].cusAddress;
                            CusCityCode.Text = Client[i].cusCityCode+"";
                            CusPhone.Text = Client[i].cusPhone;
                            CusMail.Text = Client[i].cusMail;
                            CusPassword.Text = Client[i].cusPassword;
                            hidCus.Value = CusId;
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            client Client = new client();

            // קביעת המזהה והשם של הלקוחות מהטופס
            if (hidCus.Value == "-1")
            {
                Client.CusId = -1;
            }
            else
            {
                Client.CusId = int.Parse(hidCus.Value);
            }
            Client.CusFullName = cusFullName.Text;
            Client.cusAddress = CusAddress.Text;
            Client.cusCityCode = int.Parse(CusCityCode.Text);
            Client.cusPhone = CusPhone.Text;
            Client.cusMail = CusMail.Text;
            Client.cusPassword = CusPassword.Text;
            // שמירת העיר
            Client.Save(Client);
            // עדכון ה-Application עם הרשימה החדשה
            Application["Clients"] = client.GetAll();

            // הפנייה לדף הרשימה
            Response.Redirect("ClientList.aspx");
            /*string sql = "";
            if (hidCid.Value == "-1")
            {
                sql = "insert into T_Client (CusFullName, cusAddress, cusCityCode, cusPhone, cusMail, cusPassword) values ";
                sql += $"(N'{cusFullName.Text}', N'{CusAddress.Text}', N'{CusCityCode.Text}', N'{CusPhone.Text}', N'{CusMail.Text}', N'{CusPassword.Text}')";
            }
            else
            {
                sql = "update T_Client set ";
                sql += $"CusFullName = N'{cusFullName.Text}', ";
                sql += $"cusAddress = N'{CusAddress.Text}', ";
                sql += $"cusCityCode = N'{CusCityCode.Text}', ";
                sql += $"cusPhone = N'{CusPhone.Text}', ";
                sql += $"cusMail = N'{CusMail.Text}', ";
                sql += $"cusPassword = N'{CusPassword.Text}' ";
                sql += $"where CusId = '{hidCid.Value}'";
                string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                List<client> Clients = new List<client>();
                sql = "select * from T_Client";
                cmd.CommandText = sql;
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    client Tmp3 = new client()
                    {
                        CusId = int.Parse(Dr["CusId"] + ""),
                        CusFullName = Dr["CusFullName"] + "",
                        cusAddress = Dr["cusAddress"] + "",
                        cusCityCode = int.Parse(Dr["cusCityCode"] + ""),
                        cusPhone = Dr["cusPhone"] + "",
                        cusMail = Dr["cusMail"] + "",
                        cusPassword = Dr["CusPassword"] + "",
                    };
                    Clients.Add(Tmp3);
                }
                conn.Close();

                Application["Clients"] = Clients;
                Response.Redirect("ClientList.aspx");*/

        }
    }
}