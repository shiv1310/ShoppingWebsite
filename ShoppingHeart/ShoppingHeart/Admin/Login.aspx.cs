using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace ShoppingHeart.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {   string LoginID=WebConfigurationManager.AppSettings["AdminLoginID"];
            string password = WebConfigurationManager.AppSettings["AdminPassword"];
            if (TextBox1.Text == LoginID && TextBox2.Text == password)
            {
                Session["ShoppingHeartAdmin"] = "ShoppingHeartAdmin";
                Response.Redirect("~/Admin/AddNewProduct.aspx");
            }
            else
            {
                Label1.Text = "Incorrect loginID/Password"; 
            }
        }
    }
}