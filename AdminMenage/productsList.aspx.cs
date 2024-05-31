﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web09052024.AdminMenage
{
    public partial class productsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<product> LstProd = (List<product>)Application["Prods"];
            RptProd.DataSource = LstProd;
            RptProd.DataBind();

        }
    }
}