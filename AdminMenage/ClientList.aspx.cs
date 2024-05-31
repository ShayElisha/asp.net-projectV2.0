using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web09052024.AdminMenage
{
    public partial class ClientList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<client> lsCclient = (List<client>)Application["Clients"];
            RptProd.DataSource = lsCclient;
            RptProd.DataBind();
        }
    }
}