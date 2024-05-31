using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web09052024.AdminMenage
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<category> lsCategory  = (List<category>)Application["categories"];
            RptProd.DataSource = lsCategory;
            RptProd.DataBind();

        }
    }
}