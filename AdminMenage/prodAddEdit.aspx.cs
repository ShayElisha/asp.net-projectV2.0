using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BLL;

namespace web09052024.AdminMenage
{
    public partial class prodAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string Pid = Request["Pid"] + "";
                if (string.IsNullOrEmpty(Pid))
                {
                    Pid = "-1";
                }
                else
                {
                    int pid= int.Parse(Pid);

                    product Tmp = product.GetById(pid);
                    if (Tmp != null)
                    {
                        TxtPname.Text = Tmp.pName;
                        TxtPrice.Text = Tmp.price + "";
                        TxtDesc.Text = Tmp.pDesc;
                        ImgPic.ImageUrl = "/uploads/pic/PicProduct/" + Tmp.PicName;
                        hidPid.Value = Pid;
                    }
                    
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        { 
            string picName = "";
            if (uploadPic.HasFile)
            {
                picName = GlobFunc.getRundStr(8);
                string OriginFileName=uploadPic.FileName;
                int index=OriginFileName.LastIndexOf(".");
                string Ext = OriginFileName.Substring(index);
                picName += Ext;
                string FullPath=Server.MapPath("/uploads/pic/PicProduct/");
                uploadPic.SaveAs(FullPath+picName);
            }
            else
            {
                picName=ImgPic.ImageUrl.Substring(ImgPic.ImageUrl.LastIndexOf("/")+1);
            }
            product Product = new product();

            // קביעת המזהה והשם של המוצר מהטופס
            if (hidPid.Value == "-1")
            {
                Product.Pid = -1;
            }
            else
            {
                Product.Pid = int.Parse(hidPid.Value);
            }
            Product.pName = TxtPname.Text;
            Product.pDesc = TxtDesc.Text;
            Product.price = float.Parse(TxtPrice.Text);
            Product.PicName = picName;

            // שמירת העיר
            Product.Save(Product);
            /*string sql = "";
            if (hidPid.Value == "-1")
            {
                sql = "insert into T_Product(pName,price,pDesc,PicName) values ";
                sql += $"( N'{TxtPname.Text}',N'{TxtPrice.Text}',N'{TxtDesc.Text}',N'{PicName}')";
            }
            else
            {
                sql = "update T_Product set ";
                sql += $" pName=N'{TxtPname.Text}',";
                sql += $" price='{TxtPrice.Text}',";
                sql += $" pDesc=N'{TxtDesc.Text}',";
                sql += $" PicName=N'{PicName}'";
                sql += $" where Pid='{hidPid.Value}'";
            }
            
            

            string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();

            List<product> products = new List<product>();
            sql = "select * from T_Product";
            cmd.CommandText = sql;
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                product Tmp3 = new product()
                {
                    Pid = int.Parse(Dr["Pid"] + ""),
                    pName = Dr["pName"] + "",
                    price = float.Parse(Dr["price"] + ""),
                    pDesc = Dr["pDesc"] + "",
                    PicName = Dr["PicName"] + ""
                };
                products.Add(Tmp3);
            }
            conn.Close();

            Application["Prods"] = products;
            Response.Redirect("productsList.aspx");*/
        }
    }
}