using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShoppingHeart.BussinessLayer;

namespace ShoppingHeart.Admin
{
    public partial class AddNewProct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ShoppingCart k =new ShoppingCart();
            k.CategoryName = TextBox1.Text;
            k.AddNewCategory();
            TextBox1.Text=string.Empty;
            Response.Redirect("~/Admin/AddNewProduct.aspx");
        }
    }
}